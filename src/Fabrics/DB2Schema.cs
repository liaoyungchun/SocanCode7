using DBUtility;
using Model;
using System;
using System.Data;
using IBM.Data.DB2;
using System.Collections;
using System.Collections.Generic;

namespace Fabrics
{
    internal class DB2Schema : ISchema
    {
        private DbHelper helper = null;
        private void GetColumns(Table table)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            DataRowCollection rows = this.helper.ExecuteDataset(CommandType.Text, "select * from SYSCAT.COLUMNS where TABNAME='" + table + "' ORDER BY COLNO", null).Tables[0].Rows;
            foreach (DataRow row2 in rows)
            {
                Model.Field fieldex = new Model.Field();
                fieldex.Name = row2["COLNAME"].ToString();
                fieldex.FieldType = SchemaHelper.GetString(row2["TYPENAME"]);
                if (dictionary.ContainsKey(fieldex.Name))
                {
                    fieldex.IsKey = true;
                }
                else
                {
                    fieldex.IsKey = false;
                }
                if (row2["NULLS"].ToString() == "N")
                {
                    fieldex.AllowNull = false;
                }
                else
                {
                    fieldex.AllowNull = true;
                }
                if (row2["IDENTITY"].ToString() == "Y")
                {
                    fieldex.IsId = true;
                }
                else
                {
                    fieldex.IsId = false;
                }
                fieldex.Pos = Convert.ToInt32(row2["COLNO"]);
                fieldex.Length = Convert.ToInt32(row2["LENGTH"]);
                fieldex.DefaultValue = row2["DEFAULT"].ToString();
                fieldex.Descn = fieldex.Name;
                table.AddField(fieldex);
            }
        }

        private void GetProcedures(Database db)
        {
        }

        public Database GetSchema(string connectionString, Model.DatabaseTypes type)
        {
            Database db = new Database();
            db.ConnString = connectionString;
            db.Type = type;
            this.helper = DbHelper.Create("DB2");
            this.helper.ConnectionString = connectionString;
            this.GetTables(db);
            this.GetViews(db);
            //this.GetProcedures(db);//‘›Œ¥≈‰÷√
            return db;
        }
        private void GetTables(Database db)
        {
            DataSet set = this.helper.ExecuteDataset(CommandType.Text, "select TABNAME from SYSCAT.TABLES where TYPE in ('T')", null);
            //DataSet set = this.helper.ExecuteDataset(CommandType.Text, "select TABNAME from SYSCAT.TABLES where TABSCHEMA = CURRENT_USER and  TYPE in ('T')", null);
            foreach (DataRow row in set.Tables[0].Rows)
            {
                Table table = new Table();
                table.Name = row["TABNAME"].ToString();
                this.GetColumns(table);
                table.Fields.Sort();
                db.AddTable(table);
            }
        }
        private void GetViews(Database db)
        {
            DataSet set = this.helper.ExecuteDataset(CommandType.Text, "select TABNAME from SYSCAT.TABLES where  TYPE in ('V')", null);
            //DataSet set = this.helper.ExecuteDataset(CommandType.Text, "select TABNAME from SYSCAT.TABLES where TABSCHEMA = CURRENT_USER and TYPE in ('V')", null);
            foreach (DataRow row in set.Tables[0].Rows)
            {
                Table table = new Table();
                table.Name = row["TABNAME"].ToString();
                this.GetColumns(table);
                table.Fields.Sort();
                db.AddView(table);
            }

        }
    }
}
