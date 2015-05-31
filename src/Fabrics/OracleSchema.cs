using System;
using System.Data;

namespace Fabrics
{
    class OracleSchema : ISchema
    {
        DBUtility.DbHelper helper = null;

        public Model.Database GetSchema(string connectionString, Model.DatabaseTypes type)
        {
            Model.Database db = new Model.Database();
            db.ConnString = connectionString;
            db.Type = type;
            helper = DBUtility.DbHelper.Create("Oracle");
            helper.ConnectionString = connectionString;

            GetTables(db);
            GetViews(db);
            GetProcedures(db);

            return db;
        }

        private void GetProcedures(Model.Database db)
        {
            DataSet ds = helper.ExecuteDataset(CommandType.Text, "SELECT * FROM USER_PROCEDURES WHERE PROCEDURE_NAME IS NULL", null);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                db.StoreProcedures.Add(SchemaHelper.GetString(r[0]));
            }
        }

        private void GetViews(Model.Database db)
        {
            DataSet dsTables = helper.ExecuteDataset(System.Data.CommandType.Text, "select * from tab where tabtype='VIEW'", null);
            foreach (DataRow row in dsTables.Tables[0].Rows)
            {
                Model.Table table = new Model.Table();
                table.Name = row[0].ToString();
                GetColumns(table);
                table.Fields.Sort();
                db.AddView(table);
            }
        }

        private void GetTables(Model.Database db)
        {
            DataSet dsTables = helper.ExecuteDataset(System.Data.CommandType.Text, "select * from tab where tabtype='TABLE'", null);
            foreach (DataRow row in dsTables.Tables[0].Rows)
            {
                Model.Table table = new Model.Table();
                table.Name = row[0].ToString();
                GetColumns(table);
                table.Fields.Sort();
                db.AddTable(table);
            }
        }

        private void GetColumns(Model.Table table)
        {
            DataSet dsTableColumns = helper.ExecuteDataset(CommandType.Text,
               string.Format("select * from user_tab_cols where table_name = '{0}'", table.Name),
               null);

            //获取所有字段
            foreach (DataRow r in dsTableColumns.Tables[0].Rows)
            {
                Model.Field field = new Model.Field();
                field.AllowNull = SchemaHelper.GetString(r["NULLABLE"]).Equals("Y", StringComparison.CurrentCultureIgnoreCase);
                field.DefaultValue = r["DATA_DEFAULT"].ToString();
                field.FieldType = SchemaHelper.GetString(r["DATA_TYPE"]);
                //field.Descn 暂时获取不到
                //field.IsId 暂时获取不到
                //field.IsKey 暂时获取不到
                field.Length = SchemaHelper.GetInt(r["DATA_LENGTH"]);
                field.Name = SchemaHelper.GetString(r["COLUMN_NAME"]);
                field.Pos = SchemaHelper.GetInt(r["COLUMN_ID"]);
                field.Size = (int)field.Length;

                table.AddField(field);
            }

            //获取主键
            DataSet ds = helper.ExecuteDataset(CommandType.Text,
                string.Format("select col.column_name from user_constraints con,  user_cons_columns col where con.constraint_name = col.constraint_name and con.constraint_type='P' and col.table_name = '{0}'", table.Name),
                null);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                string key = SchemaHelper.GetString(r[0]);
                foreach (Model.Field field in table.Fields)
                {
                    if (field.Name.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                        field.IsKey = true;
                }
            }
        }
    }
}
