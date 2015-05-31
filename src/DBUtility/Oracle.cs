using System.Data;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace DBUtility
{
    public class Oracle : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new OracleConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new OracleCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            OracleDataAdapter adapter = new OracleDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as OracleCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as OracleCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as OracleCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as OracleCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new OracleParameter();
            parameter.ParameterName = parameterName.Replace("@", ":").Replace("?", ":");
            return parameter;
        }
    }
}
