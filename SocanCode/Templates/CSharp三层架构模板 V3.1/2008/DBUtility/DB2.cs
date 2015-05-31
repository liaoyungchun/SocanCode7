using System.Data;
using System.Data.Common;
using IBM.Data.DB2;

namespace DBUtility
{
    public class DB2 : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new DB2Connection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new DB2Command();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            DB2DataAdapter adapter = new DB2DataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as DB2Command;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as DB2Command;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as DB2Command;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as DB2Command;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new DB2Parameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }

    }
}
