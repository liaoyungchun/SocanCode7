using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace DBUtility
{
    public class MySql : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new MySqlCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as MySqlCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as MySqlCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as MySqlCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as MySqlCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new MySqlParameter();
            parameter.ParameterName = parameterName.Replace("@", "?").Replace(":", "?");
            return parameter;
        }
    }
}
