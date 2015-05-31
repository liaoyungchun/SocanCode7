
namespace Fabrics
{
    public class Schema
    {
        private ISchema iSchema;

        private string connectionString;
        private Model.DatabaseTypes type;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public Model.DatabaseTypes Type
        {
            get { return type; }
            set
            {
                type = value;

                switch (value)
                {
                    case Model.DatabaseTypes.Access:
                        iSchema = new AccessSchema();
                        break;
                    case Model.DatabaseTypes.MySql:
                        iSchema = new MySqlSchema();
                        break;
                    case Model.DatabaseTypes.Oracle:
                        iSchema = new OracleSchema();
                        break;
                    case Model.DatabaseTypes.SQLite:
                        iSchema = new SQLiteSchema();
                        break;
                    case Model.DatabaseTypes.Ase:
                        iSchema = new AseSchema();
                        break;
                    case Model.DatabaseTypes.DB2:
                        iSchema = new DB2Schema();
                        break;
                    case Model.DatabaseTypes.PostgreSql:
                        iSchema = new PostgreSqlSchema();
                        break;
                    case Model.DatabaseTypes.Sql2000:
                    case Model.DatabaseTypes.Sql2005:
                    default:
                        iSchema = new SqlSchema();
                        break;
                }
            }
        }

        public Schema()
        {
        }

        public Schema(string connectionString, Model.DatabaseTypes type)
        {
            this.connectionString = connectionString;
            Type = type;
        }

        /// <summary>
        /// 获取数据库信息
        /// </summary>
        public Model.Database GetSchema()
        {
            Model.Database db = iSchema.GetSchema(connectionString, type);
            foreach (Model.Table tb in db.Tables)
            {
                foreach (Model.Field fd in tb.Fields)
                {
                    if (fd.Length < 0)
                    {
                        fd.Length = 4000;
                    }
                }
            }
            return db;
        }
    }
}
