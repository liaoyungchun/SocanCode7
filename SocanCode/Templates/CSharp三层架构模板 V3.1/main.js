var csType = { Byte: 'byte?', SByte: 'sbyte?', Int16: 'Int16?', UInt16: 'UInt16?', Int32: 'int?', UInt32: 'uint?', Int64: 'long?', UInt64: 'ulong?',
    Single: 'float?', Double: 'double?',
    Decimal: 'decimal?', VarNumeric: 'decimal?', Currency: 'decimal?',
    Boolean: 'bool?',
    Guid: 'Guid?',
    Date: 'DateTime?', Time: 'DateTime?', DateTime: 'DateTime?',
    Xml: 'string', AnsiStringFixedLength: 'string', AnsiString: 'string', StringFixedLength: 'string', String: 'string',
    Binary: 'byte[]', Object: 'object'
};

var csMethod = { Byte: 'GetByte', SByte: 'GetSByte', Int16: 'GetInt16', UInt16: 'GetUInt16', Int32: 'GetInt', UInt32: 'GetUInt', Int64: 'GetLong', UInt64: 'GetULong',
    Single: 'GetFloat', Double: 'GetDouble',
    Decimal: 'GetDecimal', VarNumeric: 'GetDecimal', Currency: 'GetDecimal',
    Boolean: 'GetBool',
    Guid: 'GetGuid',
    Date: 'GetDateTime', Time: 'GetDateTime', DateTime: 'GetDateTime',
    Xml: 'GetString', AnsiStringFixedLength: 'GetString', AnsiString: 'GetString', StringFixedLength: 'GetString', String: 'GetString',
    Binary: 'GetBinary',
    Object: ''
};

var db, set;

/**
* 程序入口，传入的参数可通过软件界面中的调拭窗口看到
*/
function main(databaseJson, settingJson) {
    //为所有field增加DbType属性
    for (var i = 0; i < databaseJson.Selects.length; i++) {
        var table = databaseJson.Selects[i];
        for (var j = 0; j < table.Fields.length; j++) {
            var field = table.Fields[j];
            field.setDbType(databaseJson.Type); //为field设置DbType属性, 此函数在DbType.js中
        }
    }

    //创建了一个优化后的"数据库结构"对象, 以后的代码都用它代替databaseJson
    db = getDb(databaseJson);

    //创建了一个优化后的"用户设置"对象, 以后的代码都用它代替settingJson
    set = getSet(settingJson);

    //开始生成代码
    var codes = model();

    if (set.SlnFrame == 'Factory') {
        codes = codes.concat(idal());
        codes = codes.concat(dalFactory());
    }

    codes = codes.concat(dal());
    codes = codes.concat(bl());
    codes.push(web());
    codes.push(sln());

    return codes;
}

/**
* 在databaseJson的基础上为每个Field增加CondFields和UncondFields两个数组属性，
* 将所有列拆分分别添到这两个属性中
*/
function getDb(databaseJson) {
    var db = databaseJson;
    for (var i = 0; i < db.Selects.length; i++) {
        var table = db.Selects[i];
        var condFields = new Array(); //约束列
        var uncondFields = new Array(); //非约束列

        //优先使用标识作约束列
        for (var j = 0; j < table.Fields.length; j++) {
            var field = table.Fields[j];
            if (field.IsId) {
                condFields.push(field);
                break;
            }
        }

        if (condFields.length > 0) //标识存在，把其它列作非约束列
        {
            for (var j = 0; j < table.Fields.length; j++) {
                var field = table.Fields[j];
                if (!field.IsId) {
                    uncondFields.push(field);
                }
            }
        }
        else //如果标识不存在
        {
            //使用主键作约束列
            for (var j = 0; j < table.Fields.length; j++) {
                var field = table.Fields[j];
                if (field.IsKey) {
                    condFields.push(field);
                } else {
                    uncondFields.push(field);
                }
            }

            //主键不存在
            if (condFields.length == 0) {
                //则使用第一列作约束列
                condFields.push(table.Fields[0]);
                //弹出第一列，剩下的是非约束列
                uncondFields.shift();
            }
        }

        table.CondFields = condFields;
        table.UncondFields = uncondFields;
    }
    return db;
}

/**
* settingJson中原来有Name和Value两个键，转变为Name值变为键，Value值变为其值。
* 即原来的 [{Name:'a',Value:'b'}] 变为 [{a:'b'}]
*/
function getSet(settingJson) {
    var set = {};
    for (var i = 0; i < settingJson.length; i++) {
        set[settingJson[i].Name] = settingJson[i].Value;
    }
    return set;
}

/**
* 获取约束列作为参数的字符串
* addType为false时为'id, name...'
* addType为true时为'int? id, string name...'
*/
function getFuncParm(table, addtype) {
    return table.CondFields.fieldJoin(function () {
        if (addtype)
            return csType[this.DbType] + ' ' + this.Name;
        return this.Name;
    }, ', ');
}

/**
* 获取命名空间
* 格式为'NamespacePrefix.moduleName.NamespaceSuffix'
*/
function getNamespace(moduleName) {
    var temp = '';
    if (set.NamespacePrefix) temp += set.NamespacePrefix + '.';
    temp += moduleName;
    if (set.NamespaceSuffix) temp += '.' + set.NamespaceSuffix;
    return temp;
}