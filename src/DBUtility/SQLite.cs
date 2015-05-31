using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace DBUtility
{
    public class SQLite : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new SQLiteCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as SQLiteCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as SQLiteCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as SQLiteCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as SQLiteCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new SQLiteParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }
}
