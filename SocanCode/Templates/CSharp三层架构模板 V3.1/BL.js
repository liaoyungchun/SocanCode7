function bl() {
    var codes = new Array();

    // 复制 BLL/BLS 文件夹
    codes.push({
        type: 'copy',
        isfolder: true,
        source: set.VSVersion + '\\' + set.BLFrame,
        target: set.BLFrame
    });

    // 业务逻辑层基类
    codes.push(blHelper());

    // 逐表生成
    for (var i = 0; i < db.Selects.length; i++) {
        codes.push(blcs(db.Selects[i]));
        if (set.BLFrame == 'BLS')
            codes.push(blasmx(db.Selects[i]));
    }

    return codes;
}

function blHelper() {
    var NewLine = '\n';
    var temp = '';
    temp += 'using System;' + NewLine;
    temp += 'using System.Collections;' + NewLine;
    temp += 'using System.Configuration;' + NewLine;
    temp += 'using System.Web;' + NewLine;
    temp += 'using System.Web.Caching;' + NewLine;
    temp += NewLine;
    temp += 'namespace {0}'.format(getNamespace(set.BLFrame)) + NewLine;
    temp += '{' + NewLine;
    temp += '    /// <summary>' + NewLine;
    temp += '    /// 业务逻辑层基类' + NewLine;
    temp += '    /// </summary>' + NewLine;
    temp += '    public class BLHelper' + NewLine;
    temp += '    {' + NewLine;
    temp += '        private static readonly string CACHEHEADER_MODEL = "Model_";' + NewLine;
    temp += '        private static readonly string CACHEHEADER_LIST = "List_";' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 是否启用缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected static readonly bool EnableCache = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableCache"]);' + NewLine;
    temp += NewLine;
    temp += '        public BLHelper() { }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 缓存key的头部' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected string basicKey;' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 构造函数,请传入basicKey' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        public BLHelper(string basicKey)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            this.basicKey = basicKey;' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        #region 缓存操作' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 建立一个Model缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected void TryAddModelCache(object modelKey, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemovedCallback)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            string key = basicKey + CACHEHEADER_MODEL + modelKey.ToString();' + NewLine;
    temp += '            CacheHelper.TryAddCache(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemovedCallback);' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 获取一个Model缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected object GetModelCache(object modelKey)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            return CacheHelper.GetCache(basicKey + CACHEHEADER_MODEL + modelKey.ToString());' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 删除一个Model缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected void RemoveModelCache(object modelKey)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            CacheHelper.TryRemoveCache(basicKey + CACHEHEADER_MODEL + modelKey.ToString());' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 删除所有Model缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected void RemoveModelCache()' + NewLine;
    temp += '        {' + NewLine;
    temp += '            CacheHelper.RemoveMultiCache(basicKey + CACHEHEADER_MODEL);' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 建立一个List缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected void TryAddListCache(object listKey, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemovedCallback)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            string key = basicKey + CACHEHEADER_LIST + listKey.ToString();' + NewLine;
    temp += '            CacheHelper.TryAddCache(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemovedCallback);' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 获取一个List缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected object GetListCache(object listKey)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            return CacheHelper.GetCache(basicKey + CACHEHEADER_LIST + listKey.ToString());' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 删除一个List缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected void RemoveListCache(object listKey)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            CacheHelper.TryRemoveCache(basicKey + CACHEHEADER_LIST + listKey.ToString());' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 删除所有List缓存' + NewLine;
    temp += '        /// </summary>' + NewLine;
    temp += '        protected void RemoveListCache()' + NewLine;
    temp += '        {' + NewLine;
    temp += '            CacheHelper.RemoveMultiCache(basicKey + CACHEHEADER_LIST);' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        #endregion' + NewLine;
    temp += '    }' + NewLine;
    temp += '}' + NewLine;

    return {
        type: 'code',
        title: 'BLHelper',
        path: set.BLFrame + '\\BLHelper.cs',
        code: temp
    };
}

function blcs(table) {
    var NewLine = '\n';
    var temp = '';
    temp += 'using System;' + NewLine;
    if (set.BLFrame == 'BLS') {
        temp += 'using System.Web.Services;' + NewLine;
        temp += 'using System.ComponentModel;' + NewLine;
    }
    temp += 'using System.Collections.Generic;' + NewLine;
    temp += 'using System.Text.RegularExpressions;' + NewLine;
    temp += 'using System.Web;' + NewLine;
    temp += 'using System.Web.Caching;' + NewLine;
    if (set.CacheFrame == 'ListCache')
        temp += 'using System.Linq;' + NewLine;
    if (set.SlnFrame == 'Factory')
        temp += 'using DALFactory;' + NewLine;
    temp += NewLine;
    temp += 'namespace {0}'.format(getNamespace(set.BLFrame)) + NewLine;
    temp += '{' + NewLine;
    temp += '    /// <summary>' + NewLine;
    temp += '    /// 业务逻辑类 ' + table.Name + NewLine;
    temp += '    /// </summary>' + NewLine;
    if (set.BLFrame == 'BLS') {
        temp += '    [WebService(Namespace = "http://www.Socansoft.com/")]' + NewLine;
        temp += '    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]' + NewLine;
        temp += '    [ToolboxItem(false)]' + NewLine;
    }
    temp += '    public class {0}: BLHelper'.format(table.Name) + NewLine;
    temp += '    {' + NewLine;
    if (set.SlnFrame == 'Factory') {
        temp += '        private readonly {0}.I{1} dal = DataAccess.Create{2}{1}();'.format(getNamespace('IDAL'), table.Name, set.NamespaceSuffix) + NewLine;
    } else {
        temp += '        private readonly {0}.{1} dal = new {0}.{1}();'.format(getNamespace(set.DALFrame), table.Name) + NewLine;
    }
    temp += NewLine;
    temp += '        public {0}()'.format(table.Name) + NewLine;
    temp += '            : base("{0}{1}_") { }'.format(set.NamespaceSuffix.appendUnEmpty('_'), table.Name) + NewLine;
    temp += NewLine;
    temp += getComment('增加一条数据');
    temp += '        public void Add({0}.{1} model)'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    if (set.CacheFrame == 'ListCache') {
        temp += '            int count = dal.Add(model);' + NewLine;
        temp += '            if (EnableCache && count > 0)' + NewLine;
        temp += '            {' + NewLine;
        temp += '                RemoveListCache();' + NewLine;
        temp += '            }' + NewLine;
    } else {
        temp += '            dal.Add(model);' + NewLine;
    }
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += getComment('更新一条数据');
    temp += '        public void Update({0}.{1} model)'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    switch (set.CacheFrame) {
        case 'ObjectCache':
            temp += '            int count = dal.Update(model);' + NewLine;
            temp += '            if (EnableCache && count > 0)' + NewLine;
            temp += '            {' + NewLine;
            temp += '                RemoveModelCache({0});'.format(table.CondFields.fieldJoin(function () { return 'model.' + this.Name; }, ' + "_" + ')) + NewLine;
            temp += '            }' + NewLine;
            break;
        case 'ListCache':
            temp += '            int count = dal.Update(model);' + NewLine;
            temp += '            if (EnableCache && count > 0)' + NewLine;
            temp += '            {' + NewLine;
            temp += '                RemoveListCache();' + NewLine;
            temp += '            }' + NewLine;
            break;
        default:
            temp += '            dal.Update(model);' + NewLine;
            break;
    }
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += getComment('删除一条数据');
    temp += '        public void Delete({0})'.format(getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    switch (set.CacheFrame) {
        case 'ObjectCache':
            temp += '            int count = dal.Delete({0});'.format(getFuncParm(table, false)) + NewLine;
            temp += '            if (EnableCache && count > 0)' + NewLine;
            temp += '            {' + NewLine;
            temp += '                RemoveModelCache({0});'.format(table.CondFields.fieldJoin(function () { return this.Name + '.ToString()' }, ' + "_" + ')) + NewLine;
            temp += '            }' + NewLine;
            break;
        case 'ListCache':
            temp += '            int count = dal.Delete({0});'.format(getFuncParm(table, false)) + NewLine;
            temp += '            if (EnableCache && count > 0)' + NewLine;
            temp += '            {' + NewLine;
            temp += '                RemoveListCache();' + NewLine;
            temp += '            }' + NewLine;
            break;
        default:
            temp += '            dal.Delete({0});'.format(getFuncParm(table, false)) + NewLine;
            break;
    }
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += getComment('是否存在该记录');
    temp += '        public bool Exists({0})'.format(getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    if (set.CacheFrame == 'ListCache') {
        temp += '            List<{0}.{1}> lst = GetList();'.format(getNamespace('Model'), table.Name) + NewLine;
        temp += '            bool bln = (from m in lst where {0} select m).Count() > 0;'.format(table.CondFields.fieldJoin(function () { return 'm.' + this.Name + '.Equals(' + this.Name + ')'; }, ' && ')) + NewLine;
    } else {
        temp += '            bool bln = dal.Exists({0});'.format(getFuncParm(table, false)) + NewLine;
    }
    temp += '            return bln;' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += getComment('得到一个对象实体');
    temp += '        public {0}.{1} GetModel({2})'.format(getNamespace('Model'), table.Name, getFuncParm(table, true)) + NewLine;
    temp += '        {' + NewLine;
    switch (set.CacheFrame) {
        case 'ObjectCache':
            temp += '            {0}.{1} model = null;'.format(getNamespace('Model'), table.Name) + NewLine;
            temp += '            if (!EnableCache)' + NewLine;
            temp += '            {' + NewLine;
            temp += '                model = dal.GetModel({0});'.format(getFuncParm(table, false)) + NewLine;
            temp += '            }' + NewLine;
            temp += '            else' + NewLine;
            temp += '            {' + NewLine;
            temp += '                string key = {0};'.format(table.CondFields.fieldJoin(function () { return this.Name + '.ToString()' }, ' + "_" + ')) + NewLine;
            temp += '                if (GetModelCache(key) != null)' + NewLine;
            temp += '                {' + NewLine;
            temp += '                    model = ({0}.{1})GetModelCache(key);'.format(getNamespace('Model'), table.Name) + NewLine;
            temp += '                }' + NewLine;
            temp += '                else' + NewLine;
            temp += '                {' + NewLine;
            temp += '                    model = dal.GetModel({0});'.format(getFuncParm(table, false)) + NewLine;
            temp += '                    TryAddModelCache(key, model, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);' + NewLine;
            temp += '                }' + NewLine;
            temp += '            }' + NewLine;
            temp += '            return model;' + NewLine;
            break;
        case 'ListCache':
            temp += '            List<{0}.{1}> lst = GetList();'.format(getNamespace('Model'), table.Name) + NewLine;
            temp += '            {0}.{1} model = (from m in lst where {2} select m).SingleOrDefault();'.format(getNamespace('Model'), table.Name, table.CondFields.fieldJoin(function () { return 'm.' + this.Name + '.Equals(' + this.Name + ')'; }, ' && ')) + NewLine;
            temp += '            return model;' + NewLine;
            break;
        default:
            temp += '            {0}.{1} model = dal.GetModel({2});'.format(getNamespace('Model'), table.Name, getFuncParm(table, false)) + NewLine;
            temp += '            return model;' + NewLine;
            break;
    }
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += getComment('获得泛型数据列表');
    temp += '        public List<{0}.{1}> GetList()'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    if (set.CacheFrame == 'ListCache') {
        temp += '            List<{0}.{1}> lst = null;'.format(getNamespace('Model'), table.Name) + NewLine;
        temp += '            if (!EnableCache)' + NewLine;
        temp += '            {' + NewLine;
        temp += '                lst = dal.GetList();' + NewLine;
        temp += '            }' + NewLine;
        temp += '            else' + NewLine;
        temp += '            {' + NewLine;
        temp += '                string key = "ALL";' + NewLine;
        temp += '                if (GetListCache(key) != null)' + NewLine;
        temp += '                {' + NewLine;
        temp += '                    lst = GetListCache(key) as List<{0}.{1}>;'.format(getNamespace('Model'), table.Name) + NewLine;
        temp += '                }' + NewLine;
        temp += '                else' + NewLine;
        temp += '                {' + NewLine;
        temp += '                    lst = dal.GetList();' + NewLine;
        temp += '                    TryAddListCache(key, lst, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);' + NewLine;
        temp += '                }' + NewLine;
        temp += '            }' + NewLine;
        temp += NewLine;
    } else {
        temp += '            List<{0}.{1}> lst = dal.GetList();'.format(getNamespace('Model'), table.Name) + NewLine;
    }
    temp += '            return lst;' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += getComment('分页获取泛型数据列表');
    temp += '        public PageList<{0}.{1}> GetPageList(PageInfo pi)'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '        {' + NewLine;
    if (set.CacheFrame == 'ListCache') {
        temp += '            List<{0}.{1}> lst = GetList();'.format(getNamespace('Model'), table.Name) + NewLine;
        temp += '            pi.RecordCount = lst.Count;' + NewLine;
        temp += '            pi.Compute();' + NewLine;
        temp += '            PageList<{0}.{1}> pl = new PageList<{0}.{1}>(pi);'.format(getNamespace('Model'), table.Name) + NewLine;
        temp += '            pl.List = lst.Skip(pi.FirstIndex).Take(pi.PageSize).ToList();' + NewLine;
    } else {
        temp += '            PageList<{0}.{1}> pl = dal.GetPageList(pi);'.format(getNamespace('Model'), table.Name) + NewLine;
    }
    temp += '            return pl;' + NewLine;
    temp += '        }' + NewLine;
    temp += '    }' + NewLine;
    temp += '}' + NewLine;


    function getComment(content) {
        var temp = '';
        var NewLine = '\n';
        switch (set.BLFrame) {
            case 'BLL':
                temp += '        /// <summary>' + NewLine;
                temp += '        /// {0}'.format(content) + NewLine;
                temp += '        /// </summary>' + NewLine;
                break;
            case 'BLS':
            default:
                temp += '        [WebMethod(Description="{0}")]'.format(content) + NewLine;
                break;
        }
        return temp;
    }

    return {
        title: set.BLFrame,
        path: '{0}\\{1}{2}.cs'.format(set.BLFrame, table.Name, set.BLFrame == 'BLS' ? '.asmx' : ''),
        code: temp
    }
}

function blasmx(table) {
    var temp = '<%@ WebService Language="C#" CodeBehind="{1}.asmx.cs" Class="{0}.{1}" %>'.format(getNamespace('Model'), table.Name);
    return {
        title: '{0}.asmx'.format(set.BLFrame),
        path: '{0}\\{1}.asmx'.format(set.BLFrame, table.Name),
        code: temp
    };
}