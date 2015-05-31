using DBUtility;
using Model;
using System;
using System.Data;
using Npgsql;

namespace Fabrics
{
    internal class PostgreSqlSchema : ISchema
    {
        private DbHelper dbHelper = null;
        private void GetColumns(Table table)
        {
            DataSet set = this.dbHelper.ExecuteDataset(CommandType.Text, string.Format(@"SELECT a.attnum,a.attname AS field,t.typname AS type,a.attlen AS length,a.atttypmod AS lengthvar,a.attnotnull AS notnull FROM pg_class c,pg_attribute a,pg_type t WHERE c.relname = '{0}' and a.attnum > 0 and a.attrelid = c.oid and a.atttypid = t.oid ORDER BY a.attnum", table.Name), null);
            foreach (DataRow row in set.Tables[0].Rows)
            {
                Field field = new Field();
                field.AllowNull = SchemaHelper.GetBool(row["notnull"]);
                field.FieldType = SchemaHelper.GetString(row["type"]);
                field.Length = SchemaHelper.GetInt(row["length"]);
                field.Name = SchemaHelper.GetString(row["field"]);
                field.Size = SchemaHelper.GetInt(row["lengthvar"]);
                //field.DefaultValue = SchemaHelper.GetString(row["DecimalDigits"]);
                //field.Pos = SchemaHelper.GetInt(row["Position"]);
                table.AddField(field);
            }
            DataSet set2 = this.dbHelper.ExecuteDataset(CommandType.Text, string.Format(@"select a.attname from pg_constraint c
join pg_attribute a on c.conrelid=a.attrelid and a.attnum = ANY (c.conkey) join pg_class tc on c.conrelid=tc.oid where c.contype = 'p' and tc.relname ='{0}' order by a.attnum", table.Name), null);
            foreach (DataRow row in set2.Tables[0].Rows)
            {
                string str = SchemaHelper.GetString(row[0]);
                foreach (Field field in table.Fields)
                {
                    if (field.Name.Equals(str, StringComparison.CurrentCultureIgnoreCase))
                    {
                        field.IsKey = true;
                    }
                }
            }
        }
        private void GetProcedures(Database db)
        {
          
        }
        public Database GetSchema(string connectionString, DatabaseTypes type)
        {
            Database database = new Database();
            database.ConnString = connectionString;
            database.Type = type;
            this.dbHelper = DbHelper.Create("PostgreSql");
            dbHelper.ConnectionString = connectionString;
            this.GetTables(database);
            this.GetViews(database);
            //this.GetProcedures(database);
            return database;
        }
        private void GetTables(Database db)
        {
            DataSet dataSet = this.dbHelper.ExecuteDataset(CommandType.Text, "select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'BASE TABLE' and TABLE_SCHEMA='public' order by TABLE_NAME", null);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Table table = new Table();
                table.Name = dataRow[0].ToString();
                this.GetColumns(table);
                table.Fields.Sort();
                db.AddTable(table);
            }
        }
        private void GetViews(Database db)
        {
            DataSet dataSet = this.dbHelper.ExecuteDataset(CommandType.Text, string.Format("select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'VIEW' and TABLE_SCHEMA='public' order by TABLE_NAME", db.Name), null);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Table table = new Table();
                table.Name = dataRow[0].ToString();
                this.GetColumns(table);
                table.Fields.Sort();
                db.AddView(table);
            }
        }
    }
}
