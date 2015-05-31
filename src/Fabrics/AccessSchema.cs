using System;
using System.Data;
using System.Data.OleDb;

namespace Fabrics
{
    internal class AccessSchema : ISchema
    {
        public Model.Database GetSchema(string connectionString, Model.DatabaseTypes type)
        {
            Model.Database database = new Model.Database();
            database.ConnString = connectionString;
            database.Type = type;

            //获取所有表
            DataTable dtAllTable = GetDbSchema(database.ConnString, OleDbSchemaGuid.Tables, new object[] { null, null, null, "table" });
            foreach (DataRow rt in dtAllTable.Rows)
            {
                Model.Table table = new Model.Table();
                table.Name = rt["TABLE_NAME"].ToString();
                DataTable dtColumns = GetDbSchema(database.ConnString, OleDbSchemaGuid.Columns, new object[] { null, null, table.Name });
                foreach (DataRow rc in dtColumns.Rows)
                {
                    Model.Field field = GetField(database.ConnString, table.Name, rc);
                    table.AddField(field);
                }
                table.Fields.Sort();
                database.AddTable(table);
            }

            //获取所有视图
            DataTable dtAllView = GetDbSchema(database.ConnString, OleDbSchemaGuid.Views, null);
            foreach (DataRow rv in dtAllView.Rows)
            {
                Model.Table view = new Model.Table();
                view.Name = rv["TABLE_NAME"].ToString();
                DataTable dtColumns = GetDbSchema(database.ConnString, OleDbSchemaGuid.Columns, new object[] { null, null, view.Name });
                foreach (DataRow rc in dtColumns.Rows)
                {
                    Model.Field field = GetField(database.ConnString, view.Name, rc);
                    view.AddField(field);
                }
                view.Fields.Sort();
                database.AddView(view);
            }

            //获取所有存储过程
            DataTable dtAllStoreProcedure = GetDbSchema(database.ConnString, OleDbSchemaGuid.Procedures, null);
            foreach (DataRow rsp in dtAllStoreProcedure.Rows)
            {
                database.StoreProcedures.Add(rsp["PROCEDURE_NAME"].ToString());
            }
            return database;
        }

        private Model.Field GetField(string connectionString, string tbName, DataRow r)
        {
            Model.Field model = new Model.Field();
            model.AllowNull = SchemaHelper.GetBool(r["IS_NULLABLE"]);
            model.DefaultValue = SchemaHelper.GetString(r["COLUMN_DEFAULT"]);
            model.Descn = SchemaHelper.GetString(r["DESCRIPTION"]);
            model.Name = SchemaHelper.GetString(r["COLUMN_NAME"]);
            model.Pos = SchemaHelper.GetInt(r["ORDINAL_POSITION"]);
            model.Size = SchemaHelper.GetInt(r["CHARACTER_OCTET_LENGTH"]);
            model.FieldType = SchemaHelper.GetString(r["DATA_TYPE"]);
            model.Length = SchemaHelper.GetInt(r["CHARACTER_MAXIMUM_LENGTH"]);
            model.IsId = SchemaHelper.GetInt(r["COLUMN_FLAGS"]) == 90 && SchemaHelper.GetInt(r["DATA_TYPE"]) == 3;

            DataTable dtPrimanyKey = GetDbSchema(connectionString, OleDbSchemaGuid.Primary_Keys, null);
            foreach (DataRow rp in dtPrimanyKey.Rows)
            {
                if (rp[2].ToString() == tbName && rp[3].ToString() == model.Name)
                {
                    model.IsKey = true;
                }
            }
            return model;
        }

        private DataTable GetDbSchema(string connString, Guid schema, object[] restrictions)
        {
            OleDbConnection myConn = new OleDbConnection(connString);
            myConn.Open();
            DataTable table1 = myConn.GetOleDbSchemaTable(schema, restrictions);
            myConn.Close();
            return table1;
        }
    }
}
