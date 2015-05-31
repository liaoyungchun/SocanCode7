using System;
using System.Data;
using System.Data.Common;
using Sybase.Data.AseClient;

namespace DBUtility
{
    public class Ase : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new AseConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new AseCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            AseDataAdapter adapter = new AseDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as AseCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as AseCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as AseCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as AseCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new AseParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }
}
