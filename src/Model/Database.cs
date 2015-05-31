using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using Oracle.DataAccess.Client;

namespace Model
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DatabaseTypes
    {
        Access,
        Sql2000,
        Sql2005,
        MySql,
        Oracle,
        SQLite,
        Ase,
        DB2,
        PostgreSql
    }

    /// <summary>
    /// 数据库
    /// </summary>
    public class Database
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TypeDescn
        {
            get
            {
                switch (Type)
                {
                    case DatabaseTypes.Sql2005:
                        return "Sql2005或更高版本";
                    default:
                        return Type.ToString();
                }
            }
        }

        /// <summary>
        /// 构造一个空数据库
        /// </summary>
        public Database()
        {
            Tables = new List<Table>();
            Views = new List<Table>();
            StoreProcedures = new List<string>();
            Selects = new List<Table>();
        }

        #region 属性
        /// <summary>
        /// 数据库连接参数
        /// </summary>
        public string ConnString { get; set; }

        private string name = null;

        /// <summary>
        /// 数据库名
        /// </summary>
        public string Name
        {
            get
            {
                if (name != null)
                {
                    return name;
                }
                else
                {
                    switch (Type)
                    {
                        case DatabaseTypes.Access:
                            using (OleDbConnection conn = new OleDbConnection(ConnString))
                            {
                                try
                                {
                                    FileInfo file = new FileInfo(conn.DataSource);
                                    return file.Name.Remove(file.Name.LastIndexOf("."));
                                }
                                catch (Exception)
                                {
                                    return conn.DataSource;
                                }
                            }
                        case DatabaseTypes.Sql2000:
                        case DatabaseTypes.Sql2005:
                            using (SqlConnection conn = new SqlConnection(ConnString))
                            {
                                try
                                {
                                    FileInfo file = new FileInfo(conn.Database);
                                    int start = file.Name.LastIndexOf(".");
                                    if (start > 0)
                                        return file.Name.Remove(start);

                                    return conn.Database;
                                }
                                catch (Exception)
                                {
                                    return conn.Database;
                                }
                            }
                        case DatabaseTypes.MySql:
                            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString))
                            {
                                try
                                {
                                    return conn.Database;
                                }
                                catch (Exception)
                                {
                                    return "MySqlDB";
                                }
                            }
                        case DatabaseTypes.Oracle:
                            using (OracleConnection conn = new OracleConnection(ConnString))
                            {
                                try
                                {
                                    return conn.DataSource;
                                }
                                catch (Exception)
                                {
                                    return "OracleDB";
                                }
                            }
                        case DatabaseTypes.SQLite:
                            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(ConnString))
                            {
                                try
                                {
                                    Regex r = new Regex("Data Source=(?<source>[^;]+);");
                                    Match m = r.Match(conn.ConnectionString);
                                    if (m.Success)
                                    {
                                        string path = m.Groups["source"].Value;
                                        FileInfo fi = new FileInfo(path);
                                        return fi.Name.Substring(0, fi.Name.LastIndexOf('.'));
                                    }
                                    else
                                    {
                                        return "SQLiteDB";
                                    }
                                }
                                catch (Exception)
                                {
                                    return "SQLiteDB";
                                }
                            }
                        case DatabaseTypes.Ase:
                            using (Sybase.Data.AseClient.AseConnection conn = new Sybase.Data.AseClient.AseConnection(ConnString))
                            {
                                try
                                {
                                    return conn.Database;
                                }
                                catch (Exception)
                                {
                                    return "SybaseDB";
                                }
                            }
                        case DatabaseTypes.DB2:
                            using (IBM.Data.DB2.DB2Connection conn = new IBM.Data.DB2.DB2Connection(ConnString))
                            {
                                try
                                {
                                    Regex r = new Regex("Database=(?<Database>[^;]+);");
                                    Match m = r.Match(conn.ConnectionString);
                                    if (m.Success)
                                    {
                                        string result = m.Groups["Database"].Value;
                                        return result;

                                    }
                                    else
                                    {
                                        return "DB2DB";
                                    }
                                }
                                catch (Exception)
                                {
                                    return "DB2DB";
                                }
                            }
                        case DatabaseTypes.PostgreSql:
                            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(ConnString))
                            {
                                try
                                {
                                    return conn.Database;
                                }
                                catch (Exception)
                                {
                                    return "PostgreSqlDB";
                                }
                            }
                        default:
                            return "UnKnownDB";
                    }
                }
            }
            set { name = value; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseTypes Type { get; set; }

        /// <summary>
        /// 所有表
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public List<Model.Table> Tables { get; set; }

        /// <summary>
        /// 所有视图名
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public List<Model.Table> Views { get; set; }

        /// <summary>
        /// 所有存储过程名
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public List<string> StoreProcedures { get; set; }

        /// <summary>
        /// 选中的表或视图
        /// </summary>
        public List<Model.Table> Selects { get; set; }
        #endregion

        #region 方法
        /// <summary>
        /// 添加一个表
        /// </summary>
        public void AddTable(Model.Table table)
        {
            table.Database = this;
            table.IsView = false;
            Tables.Add(table);
        }

        /// <summary>
        /// 添加一个视图
        /// </summary>
        public void AddView(Model.Table view)
        {
            view.Database = this;
            view.IsView = true;
            Views.Add(view);
        }

        /// <summary>
        /// 转化为字符串
        /// </summary>
        /// <returns>返回表名</returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
