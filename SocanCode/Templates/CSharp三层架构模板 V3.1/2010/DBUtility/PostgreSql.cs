using System;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace DBUtility
{
    public class PostgreSql : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new NpgsqlCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as NpgsqlCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as NpgsqlCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as NpgsqlCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as NpgsqlCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new NpgsqlParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }
}
