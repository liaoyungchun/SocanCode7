using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace DBUtility
{
    public class OleDb : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new OleDbConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new OleDbCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as OleDbCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as OleDbCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as OleDbCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as OleDbCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new OleDbParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }
}
