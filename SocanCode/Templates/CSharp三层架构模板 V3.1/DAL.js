var commandType;

function dal() {
    this.commandType = (set.CommandType == 'SQL' ? 'Text' : 'StoredProcedure');

    var codes = new Array();

    // 复制DBUtility文件夹
    codes.push({
        type: 'copy',
        isfolder: true,
        source: '{0}\\DBUtility'.format(set.VSVersion),
        target: 'DBUtility'
    });

    // 复制DAL文件夹
    codes.push({
        type: 'copy',
        isfolder: true,
        source: '{0}\\{1}'.format(set.VSVersion, set.DALFrame),
        target: set.DALFrame
    });

    // 生成DALHelper.cs
    codes.push(dalHelper());

    // 逐表生成
    for (var i = 0; i < db.Selects.length; i++)
    {
        var table = db.Selects[i];
        codes.push(tableInternalDal(table));
        codes.push(tableEditableDal(table));
    }

    return codes;
}

function dalHelper() {
    var NewLine = '\n';
    var temp = '';
    temp += '//如果要从UI中设置数据库，请取消注释下一行，如果从配置中读取，请注释下一行' + NewLine;
    temp += '//#define UISET' + NewLine;
    temp += NewLine;
    temp += 'using System;' + NewLine;
    temp += 'using System.Configuration;' + NewLine;
    temp += 'using System.Data;' + NewLine;
    temp += 'using System.Data.Common;' + NewLine;
    temp += 'using DBUtility;' + NewLine;
    temp += NewLine;
    temp += 'namespace ' + getNamespace(set.DALFrame) + NewLine;
    temp += '{' + NewLine;
    temp += '    public class DALHelper' + NewLine;
    temp += '    {' + NewLine;
    temp += '#if UISET' + NewLine;
    temp += '        public static DbHelper {0};'.format(set.DBHelperName) + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 设置数据库连接' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        /// <param name="dbType">不区分大小写，可选值：MySql、OleDb、Oracle、SQLite、SqlServer, Ase, DB2,PostgreSql</param>' + NewLine;
    temp += '        /// <param name="connectionString">数据库连接字符串</param>' + NewLine;
    temp += '        public static void SetHelper(string dbType, string connectionString)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            {0} = DbHelper.Create(dbType);'.format(set.DBHelperName) + NewLine;
    temp += '            {0}.ConnectionString = connectionString;'.format(set.DBHelperName) + NewLine;
    temp += '        }' + NewLine;
    temp += '#else' + NewLine;
    temp += '        public static DbHelper {0} = GetHelper("DB");'.format(set.DBHelperName) + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 从Web.config从读取数据库的连接以及数据库类型' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        private static DbHelper GetHelper(string connectionStringName)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            ConnectionStringSettings connectionSetting = ConfigurationManager.ConnectionStrings[connectionStringName];' + NewLine;
    temp += '            string className = connectionSetting.ProviderName;' + NewLine;
    temp += '            DbHelper db = DbHelper.Create(className);' + NewLine;
    temp += '            db.ConnectionString = connectionSetting.ConnectionString;' + NewLine;
    temp += '            return db;' + NewLine;
    temp += '        }' + NewLine;
    temp += '#endif' + NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 对IDataReader读取依次执行事件' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public static void ExecuteReaderAction(IDataReader dr, Action<IDataReader> readAction)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            while (dr.Read())' + NewLine;
    temp += '            {' + NewLine;
    temp += '                if (readAction != null) readAction(dr);' + NewLine;
    temp += '            }' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 对IDataReader读取依次执行事件' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public static void ExecuteReaderAction(IDataReader dr, int first, int count, Action<IDataReader> readAction)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            for (int i = 0; i < first; i++)' + NewLine;
    temp += '            {' + NewLine;
    temp += '                if (!dr.Read()) return;' + NewLine;
    temp += '            }' + NewLine;
    temp += NewLine;
    temp += '            int resultsFetched = 0;' + NewLine;
    temp += '            while (resultsFetched < count && dr.Read())' + NewLine;
    temp += '            {' + NewLine;
    temp += '                if (readAction != null) readAction(dr);' + NewLine;
    temp += '                resultsFetched++;' + NewLine;
    temp += '            }' + NewLine;
    temp += '        }' + NewLine;
    temp += '    }' + NewLine;
    temp += '}' + NewLine;

    return {
        type: 'code',
        title: 'DALHelper',
        path: '{0}\\DALHelper.cs'.format(set.DALFrame),
        code: temp
    };
}

function tableEditableDal(table) {
    var NewLine = '\n';
    var temp = '';
    temp += 'using System;' + NewLine;
    temp += 'using System.Collections.Generic;' + NewLine;
    temp += 'using System.Data;' + NewLine;
    temp += 'using System.Data.Common;' + NewLine;
    temp += 'using System.Text;' + NewLine;
    temp += NewLine;
    temp += 'namespace {0}'.format(getNamespace(set.DALFrame, set)) + NewLine;
    temp += '{' + NewLine;
    temp += '    /// <summary>' + NewLine;
    temp += '    /// 数据访问类 ' + table.Name + NewLine;
    temp += '    /// <summary>' + NewLine;
    temp += '    public partial class {0} : DALHelper'.format(table.Name);
    if (set.SlnFrame == 'Factory') temp += ', {0}.I{1}'.format(getNamespace('IDAL', set), table.Name);
    temp += NewLine;
    temp += '    {' + NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 增加一条数据' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public int Add({0}.{1} model)'.format(getNamespace('Model', set), table.Name) + NewLine;
    temp += '        {' + NewLine;
    temp += '            IDbDataParameter[] parms4{0} = PrepareAddParameters(model);'.format(table.Name) + NewLine;
    temp += '            return {0}.ExecuteNonQuery(CommandType.{1}, COMMAND_ADD, parms4{2});'.format(set.DBHelperName, commandType, table.Name) + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 更新一条数据' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public int Update({0}.{1} model)'.format(getNamespace("Model"), table.Name) + NewLine;
    temp += '        {' + NewLine;
    temp += '            IDbDataParameter[] parms4{0} = PrepareUpdateParameters(model);'.format(table.Name) + NewLine;
    temp += '            return {0}.ExecuteNonQuery(CommandType.{1}, COMMAND_UPDATE, parms4{2});'.format(set.DBHelperName, commandType, table.Name) + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 删除一条数据' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public int Delete({0})'.format(getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    temp += '            IDbDataParameter[] parms4{0} = PrepareDeleteParameters({1});'.format(table.Name, getFuncParm(table, false)) + NewLine;
    temp += '            return {0}.ExecuteNonQuery(CommandType.{1}, COMMAND_DELETE, parms4{2});'.format(set.DBHelperName, commandType, table.Name) + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 得到一个对象实体' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public {0}.{1} GetModel({2})'.format(getNamespace('Model'), table.Name, getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    temp += '            IDbDataParameter[] parms4{0} = PrepareGetModelParameters({1});'.format(table.Name, getFuncParm(table, false)) + NewLine;
    temp += '            using (IDataReader dr = {0}.ExecuteReader(CommandType.{1}, COMMAND_GETMODEL, parms4{2}))'.format(set.DBHelperName, commandType, table.Name) + NewLine;
    temp += '            {' + NewLine;
    temp += '                if (dr.Read()) return GetModel(dr);' + NewLine;
    temp += '                return null;' + NewLine;
    temp += '            }' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 是否存在该记录' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public bool Exists({0})'.format(getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    temp += '            IDbDataParameter[] parms4{0} = PrepareExistParameters({1});'.format(table.Name, getFuncParm(table, false)) + NewLine;
    temp += '            object obj = {0}.ExecuteScalar(CommandType.{1}, COMMAND_EXISTS, parms4{2});'.format(set.DBHelperName, commandType, table.Name) + NewLine;
    temp += '            return int.Parse(obj.ToString()) > 0;' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 获取数量' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public int GetCount()' + NewLine;
    temp += '        {' + NewLine;
    temp += '            object obj = {0}.ExecuteScalar(CommandType.{1}, COMMAND_GETCOUNT, null);'.format(set.DBHelperName, commandType) + NewLine;
    temp += '            return int.Parse(obj.ToString());' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 获取泛型数据列表' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public List<{0}.{1}> GetList()'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    temp += '            using (IDataReader dr = {0}.ExecuteReader(CommandType.{1}, COMMAND_GETLIST, null))'.format(set.DBHelperName, commandType) + NewLine;
    temp += '            {' + NewLine;
    temp += '                List<{0}.{1}> lst = new List<{0}.{1}>();'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '                ExecuteReaderAction(dr, r => lst.Add(GetModel(r)));' + NewLine;
    temp += '                return lst;' + NewLine;
    temp += '            }' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 分页获取泛型数据列表' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public PageList<{0}.{1}> GetPageList(PageInfo pi)'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    temp += '            pi.RecordCount = GetCount();' + NewLine;
    temp += '            pi.Compute();' + NewLine;
    temp += NewLine;
    temp += '            PageList<{0}.{1}> pl = new PageList<{0}.{1}>(pi);'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '            using (IDataReader dr = {0}.ExecuteReader(CommandType.Text, COMMAND_GETLIST, null))'.format(set.DBHelperName) + NewLine;
    temp += '            {' + NewLine;
    temp += '                pl.List = new List<{0}.{1}>();'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '                ExecuteReaderAction(dr, pi.FirstIndex, pi.PageSize, r => pl.List.Add(GetModel(r)));' + NewLine;
    temp += '            }' + NewLine;
    temp += '            return pl;' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 由一行数据得到一个实体' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        private {0}.{1} GetModel(IDataReader dr)'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    temp += '            {0}.{1} model = new {0}.{1}();'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '            PrepareModel(model, dr);' + NewLine;
    temp += '            return model;' + NewLine;
    temp += '        }' + NewLine;
    temp += '    }' + NewLine;
    temp += '}';

    return {
        type: 'code',
        title: 'DAL-editable',
        path: '{0}\\editable\\{1}.cs'.format(set.DALFrame, table.Name),
        code: temp
    };
}

function tableInternalDal(table) {
    var NewLine = '\n';
    var temp = '';
    temp += 'using System;' + NewLine;
    temp += 'using System.Collections.Generic;' + NewLine;
    temp += 'using System.Data;' + NewLine;
    temp += 'using System.Data.Common;' + NewLine;
    temp += 'using System.Text;' + NewLine;
    temp += 'using DBUtility;' + NewLine;
    temp += NewLine;
    temp += 'namespace {0}'.format(getNamespace(set.DALFrame)) + NewLine;
    temp += '{' + NewLine;
    temp += '    /// <summary>' + NewLine;
    temp += '    /// 数据访问类 {0} ，此类请勿动，以方便表字段更改时重新生成覆盖'.format(table.Name) + NewLine;
    temp += '    /// </summary>' + NewLine;
    temp += '    public partial class {0}'.format(table.Name) + NewLine;
    temp += '    {' + NewLine;
    if (set.CommandType == 'SQL')
    {
        temp += '        internal const string COMMAND_ADD = "INSERT INTO {0}({1}) VALUES ({2})";'.format(
            table.Name,
            table.UncondFields.fieldJoin(function () {
                return this.Name;
            }, ', ', function () {
                return !this.IsId && (set.FilterDefaultableField == 'false' || !this.DefaultValue);
            }),
            table.UncondFields.fieldJoin(function () {
                return '@in_' + this.Name;
            }, ', ', function () {
                return !this.IsId && (set.FilterDefaultableField == 'false' || !this.DefaultValue);
            })) + NewLine;

        // SQL语句中的条件
        var sqlCond = table.CondFields.fieldJoin(function () { return this.Name + '=@in_' + this.Name; }, ' AND ');

        temp += '        internal const string COMMAND_UPDATE = "UPDATE {0} SET {1} WHERE {2}";'.format(
            table.Name,
            table.UncondFields.fieldJoin(function () {
                return '{0}=@in_{0}'.format(this.Name);
            }, ', '),
            sqlCond) + NewLine;

        temp += '        internal const string COMMAND_DELETE = "DELETE FROM {0} WHERE {1}";'.format(table.Name, sqlCond) + NewLine;
        temp += '        internal const string COMMAND_EXISTS = "SELECT COUNT(1) FROM {0} WHERE {1}";'.format(table.Name, sqlCond) + NewLine;
        temp += '        internal const string COMMAND_GETMODEL = "SELECT * FROM {0} WHERE {1}";'.format(table.Name, sqlCond) + NewLine;
        temp += '        internal const string COMMAND_GETCOUNT = "SELECT COUNT(*) FROM {0}";'.format(table.Name) + NewLine;
        temp += '        internal const string COMMAND_GETLIST = "SELECT * FROM {0}";'.format(table.Name) + NewLine;
    } else
    {
        temp += '        internal const string COMMAND_ADD = "sp_{0}_Add";'.format(table.Name) + NewLine;
        temp += '        internal const string COMMAND_UPDATE = "sp_{0}_Update";'.format(table.Name) + NewLine;
        temp += '        internal const string COMMAND_DELETE = "sp_{0}_Delete";'.format(table.Name) + NewLine;
        temp += '        internal const string COMMAND_EXISTS = "sp_{0}_Exists";'.format(table.Name) + NewLine;
        temp += '        internal const string COMMAND_GETMODEL = "sp_{0}_GetModel";'.format(table.Name) + NewLine;
        temp += '        internal const string COMMAND_GETCOUNT = "sp_{0}_GetCount";'.format(table.Name) + NewLine;
        temp += '        internal const string COMMAND_GETLIST = "sp_{0}_GetAllList";'.format(table.Name) + NewLine;
    }

    temp += NewLine;
    for (var i = 0; i < table.Fields.length; i++)
    {
        var field = table.Fields[i];
        temp += '        internal const string PARM_{0} = "@in_{1}";'.format(field.Name.toUpperCase(), field.Name) + NewLine;
    }
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 为新增一条数据准备参数' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        internal static IDbDataParameter[] PrepareAddParameters({0}.{1} model)'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    temp += '            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet({0}.ConnectionString, COMMAND_ADD);'.format(set.DBHelperName) + NewLine;
    temp += '            if (parms == null)' + NewLine;
    temp += '            {' + NewLine;

    temp += '                parms = new IDbDataParameter[]{';
    temp += table.Fields.fieldJoin(
        function () {
            return NewLine + '                    {0}.CreateDbParameter(PARM_{1}, DbType.{2}, ParameterDirection.Input)'.format(set.DBHelperName, this.Name.toUpperCase(), this.DbType);
        }, ',',
        function () {
            return !this.IsId && (set.FilterDefaultableField == 'false' || !this.DefaultValue);
        });
    temp += '};' + NewLine;
    temp += '                DbParameterCache.CacheParameterSet({0}.ConnectionString, COMMAND_ADD, parms);'.format(set.DBHelperName) + NewLine;
    temp += '            }' + NewLine;
    temp += NewLine;
    var i = -1;
    temp += table.Fields.fieldJoin(
        function () {
            i++;
            return '            parms[{0}].Value = model.{1};'.format(i, this.Name) + NewLine;
        }, '',
        function () {
            return !this.IsId && (set.FilterDefaultableField == 'false' || !this.DefaultValue);
        }
    );
    temp += NewLine;
    temp += '            return parms;' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 为更新一条数据准备参数' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        internal static IDbDataParameter[] PrepareUpdateParameters({0}.{1} model)'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    temp += '            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet({0}.ConnectionString, COMMAND_UPDATE);'.format(set.DBHelperName) + NewLine;
    temp += '            if (parms == null)' + NewLine;
    temp += '            {' + NewLine;
    temp += '                parms = new IDbDataParameter[]{';
    temp += table.UncondFields.concat(table.CondFields).fieldJoin(function () {
        return NewLine + '                    {0}.CreateDbParameter(PARM_{1}, DbType.{2}, ParameterDirection.Input)'.format(set.DBHelperName, this.Name.toUpperCase(), this.DbType);
    }, ',');
    temp += '};' + NewLine;
    temp += '                DbParameterCache.CacheParameterSet({0}.ConnectionString, COMMAND_UPDATE, parms);'.format(set.DBHelperName) + NewLine;
    temp += '            }' + NewLine;
    temp += NewLine;
    var all = table.UncondFields.concat(table.CondFields);
    for (var i = 0; i < all.length; i++)
    {
        var field = all[i];
        temp += '            parms[{0}].Value = model.{1};'.format(i, field.Name) + NewLine;
    }
    temp += NewLine;
    temp += '            return parms;' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 为删除一条数据准备参数' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        internal static IDbDataParameter[] PrepareDeleteParameters({0})'.format(getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    temp += getCondPrepareParameters(table, 'COMMAND_DELETE');
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 为查询是否存在一条数据准备参数' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        internal static IDbDataParameter[] PrepareExistParameters({0})'.format(getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    temp += getCondPrepareParameters(table, 'COMMAND_EXISTS');
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 为获取一条数据准备参数' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        internal static IDbDataParameter[] PrepareGetModelParameters({0})'.format(getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    temp += getCondPrepareParameters(table, 'COMMAND_GETMODEL');
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 由一行数据得到一个实体' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        internal static void PrepareModel({0}.{1} model, IDataReader dr)'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    for (var i = 0; i < table.Fields.length; i++)
    {
        var field = table.Fields[i];
        var method = csMethod[field.DbType];
        if (method)
            temp += '            model.{0} = DbValue.{1}(dr["{0}"]);'.format(field.Name, method) + NewLine;
        else
            temp += '            model.{0} = dr["{0}"];'.format(field.Name) + NewLine;
    }
    temp += '        }' + NewLine;
    temp += '    }' + NewLine;
    temp += '}' + NewLine;

    function getCondPrepareParameters(table, command) {
        var NewLine = '\n';
        var temp = '';
        temp += '            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet({0}.ConnectionString, {1});'.format(set.DBHelperName, command) + NewLine;
        temp += '            if (parms == null)' + NewLine;
        temp += '            {' + NewLine;
        temp += '                parms = new IDbDataParameter[]{' + NewLine;
        for (var i = 0; i < table.CondFields.length; i++)
        {
            var field = table.CondFields[i];
            temp += '                    {0}.CreateDbParameter(PARM_{1}, DbType.{2}, ParameterDirection.Input)'.format(set.DBHelperName, field.Name.toUpperCase(), field.DbType);
            if (i != table.CondFields.length - 1)
                temp += ',' + NewLine;
            else
                temp += '};' + NewLine;
        }
        temp += '                DbParameterCache.CacheParameterSet({0}.ConnectionString, COMMAND_EXISTS, parms);'.format(set.DBHelperName) + NewLine;
        temp += '            }' + NewLine;
        temp += NewLine;
        for (var i = 0; i < table.CondFields.length; i++)
        {
            var field = table.CondFields[i];
            temp += '            parms[{0}].Value = {1};'.format(i, field.Name) + NewLine;
        }
        temp += NewLine;
        temp += '            return parms;' + NewLine;
        return temp;
    }

    return {
        type: 'code',
        title: 'DAL-internal',
        path: '{0}\\internal\\{1}.cs'.format(set.DALFrame, table.Name),
        code: temp
    };
}
