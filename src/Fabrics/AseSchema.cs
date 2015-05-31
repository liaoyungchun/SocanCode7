using DBUtility;
using Model;
using System;
using System.Data;
using Sybase.Data.AseClient;

namespace Fabrics
{
    internal class AseSchema : ISchema
    {
        private DbHelper dbHelper = null;

        private void GetColumns(Table table)
        {
            DataSet set = this.dbHelper.ExecuteDataset(CommandType.Text, string.Format(@"select b.name as TableName,a.colid as Position,a.name as FieldName,c.name as FieldType,a.length as FieldLength,a.prec as FieldSize,a.scale as DecimalDigits,case isnull(a.status,0) when 0 then 'NOT NULL' else 'NULL' end as AllowNull from syscolumns a,sysobjects b,systypes c where a.id=b.id and a.usertype=c.usertype and b.name='{0}' order by object_name(a.id),a.colid", table.Name), null);
            foreach (DataRow row in set.Tables[0].Rows)
            {
                Field field = new Field();
                field.AllowNull = SchemaHelper.GetBool(row["AllowNull"]);
                field.DefaultValue = SchemaHelper.GetString(row["DecimalDigits"]);
                field.FieldType = SchemaHelper.GetString(row["FieldType"]);
                field.Length = SchemaHelper.GetInt(row["FieldLength"]);
                field.Name = SchemaHelper.GetString(row["FieldName"]);
                field.Pos = SchemaHelper.GetInt(row["Position"]);
                field.Size = SchemaHelper.GetInt(row["FieldSize"]);
                table.AddField(field);
            }
            DataSet set2 = this.dbHelper.ExecuteDataset(CommandType.Text, string.Format("select index_col(o.name, i.indid, 1), i.keycnt from sysindexes i join sysobjects o on o.id = i.id where o.name = '{0}' and i.keycnt > 1 and i.status & 2048 = 0", table.Name), null);
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
            DataSet dataSet = this.dbHelper.ExecuteDataset(CommandType.Text, "select distinct(name) from sysobjects where type='P'order by name", null);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                db.StoreProcedures.Add(SchemaHelper.GetString(dataRow[0]));
            }
        }
        public Database GetSchema(string connectionString, DatabaseTypes type)
        {
            Database database = new Database();
            database.ConnString = connectionString;
            database.Type = type;
            this.dbHelper = DbHelper.Create("Ase");
            dbHelper.ConnectionString = connectionString;
            this.GetTables(database);
            this.GetViews(database);
            this.GetProcedures(database);  //之前忘记加上去了，所以存储过程显示不了
            return database;
        }
        private void GetTables(Database db)
        {
            DataSet dataSet = this.dbHelper.ExecuteDataset(CommandType.Text, "select distinct(name) from sysobjects where type='U'order by name", null);
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
            DataSet dataSet = this.dbHelper.ExecuteDataset(CommandType.Text, "select distinct(name) from sysobjects where type='V'order by name", null);
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
