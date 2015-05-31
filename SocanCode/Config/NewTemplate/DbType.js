var DbType = {
    Byte: 'Byte',
    SByte: 'SByte',
    Int16: 'Int16',
    UInt16: 'UInt16',
    Int32: 'Int32',
    UInt32: 'UInt32',
    Int64: 'Int64',
    UInt64: 'UInt64',
    Single: 'Single',
    Double: 'Double',
    Decimal: 'Decimal',
    VarNumeric: 'VarNumeric',
    Currency: 'Currency',
    Boolean: 'Boolean',
    Guid: 'Guid',
    Date: 'Date',
    Time: 'Time',
    DateTime: 'DateTime',
    Xml: 'Xml',
    AnsiStringFixedLength: 'AnsiStringFixedLength',
    AnsiString: 'AnsiString',
    StringFixedLength: 'StringFixedLength',
    String: 'String',
    Binary: 'Binary',
    Object: 'Object'
}

/**
* 为Field设置DbType属性, 此Object是Field类型.
*/
Object.prototype.setDbType = function (databaseType) {
    switch (databaseType)
    {
        case 'Access':
            this.DbType = getAccessDbType(this);
            break;
        case 'MySql':
            this.DbType = getMySqlDbType(this);
            break;
        case 'Oracle':
            this.DbType = getOracleDbType(this);
            break;
        case 'SQLite':
            this.DbType = getSQLiteDbType(this);
            break;
        case 'Ase':
            this.DbType = getAseDbType(this);
            break;
        case 'DB2':
            this.DbType = getDB2DbType(this);
            break;
        case 'PostgreSql':
            this.DbType = getPostgreSqlDbType(this);
            break;
        case 'Sql2000':
        case 'Sql2005':
            this.DbType = getSqlDbType(this);
            break;
        default:
            this.DbType = DbType.Object;
            break;
    }
}

getAccessDbType = function (field) {
    switch (field.FieldType)
    {
        case '17':
            return DbType.Byte;
        case '2':
            return DbType.Int16;
        case '3':
            return DbType.Int32;
        case '4':
            return DbType.Single;
        case '131':
        case '5':
            return DbType.Double;
        case '6':
            return DbType.Currency;
        case '11':
            return DbType.Boolean;
        case '72':
            return DbType.Guid;
        case '7':
            return DbType.DateTime;
        case '130':
            return DbType.String;
        case '128':
            return DbType.Binary;
        default:
            return DbType.Object;
    }
}

getMySqlDbType = function (field) {
    switch (field.FieldType)
    {
        case 'tinyint':
            return DbType.Byte;
        case 'smallint':
            return DbType.Int16;
        case 'mediumint':
        case 'int':
            return DbType.Int32;
        case 'bigint':
            return DbType.Int64;
        case 'real':
        case 'double':
        case 'decimal':
        case 'float':
            return DbType.Double;
        case 'numeric':
            return DbType.Decimal;
        case 'bit':
        case 'bool':
            return DbType.Boolean;
        case 'year':
        case 'date':
            return DbType.Date;
        case 'time':
            return DbType.Time;
        case 'timestamp':
        case 'datetime':
            return DbType.DateTime;
        case 'char':
            return DbType.StringFixedLength;
        case 'tinytext':
        case 'mediumtext':
        case 'text':
        case 'varchar':
        case 'longtext':
            return DbType.String;
        case 'varbinary':
        case 'binary':
            return DbType.Binary;
        default:
            return DbType.Object;
    }
}

getOracleDbType = function (field) {
    switch (field.FieldType)
    {
        case 'LONG':
            return DbType.Int64;
        case 'NUMBER':
            return DbType.Decimal;
        case 'DATE':
        case 'TIMESTAMP(6)':
        case 'TIMESTAMP(6) WITH LOCAL TIME ZONE':
        case 'TIMESTAMP(6) WITH TIME ZONE':
        case 'TIMESTAMP':
            return DbType.DateTime;
        case 'CHAR':
            return DbType.AnsiStringFixedLength;
        case 'VARCHAR2':
        case 'ROWID':
        case 'CLOB':
            return DbType.AnsiString;
        case 'NCHAR':
            return DbType.StringFixedLength;
        case 'NVARCHAR2':
        case 'NCLOB':
        case 'INTERVAL YEAR(2) TO MONTH':
        case 'INTERVAL DAY(2) TO SECOND(6)':
            return DbType.String;
        case 'BINARY_DOUBLE':
        case 'BINARY_FLOAT':
        case 'BLOB':
        case 'RAW':
        case 'BFILE':
            return DbType.Binary;
        default:
            return DbType.Object;
    }
}

getSQLiteDbType = function (field) {
    switch (field.FieldType)
    {
        case 'tinyint':
            return DbType.Byte;
        case 'smallint':
            return DbType.Int16;
        case 'autoinc':
        case 'int':
        case 'integer':
            return DbType.Int32;
        case 'bigint':
        case 'int64':
        case 'largeint':
        case 'word':
            return DbType.Int64;
        case 'real':
            return DbType.Single;
        case 'double':
        case 'float':
            return DbType.Double;
        case 'dec':
        case 'decimal':
        case 'double':
        case 'precision':
        case 'numeric':
            return DbType.Decimal;
        case 'number':
            return DbType.VarNumeric;
        case 'currency':
        case 'money':
        case 'smallmoney':
            return DbType.Currency;
        case 'bool':
        case 'boolean':
            return DbType.Boolean;
        case 'guid':
            return DbType.Guid;
        case 'date':
            return DbType.Date;
        case 'time':
            return DbType.Time;
        case 'datetime':
        case 'timestamp':
            return DbType.DateTime;
        case 'xml':
            return DbType.Xml;
        case 'char':
            return DbType.AnsiStringFixedLength;
        case 'clob':
        case 'varchar':
        case 'varchar2':
            return DbType.AnsiString;
        case 'nchar':
            return DbType.StringFixedLength;
        case 'ntext':
        case 'text':
        case 'nvarchar':
        case 'datetext':
        case 'nvarchar2':
            return DbType.String;
        case 'binary':
        case 'blob':
        case 'blob_text':
        case 'memo':
        case 'graphic':
        case 'image':
        case 'photo':
        case 'picture':
        case 'raw':
        case 'varbinary':
            return DbType.Binary;
        default:
            return DbType.Object;
    }
}

getAseDbType = function (field) {
    switch (field.FieldType)
    {
        case 'tinyint':
            return DbType.Byte;
        case 'smallint':
            return DbType.Int16;
        case 'int':
            return DbType.Int32;
        case 'real':
            return DbType.Single;
        case 'float':
        case 'decimal':
            return DbType.Double;
        case 'numeric':
            return DbType.Decimal;
        case 'smallmoney':
        case 'money':
            return DbType.Currency;
        case 'bit':
            return DbType.Boolean;
        case 'date':
            return DbType.Date;
        case 'time':
            return DbType.Time;
        case 'smalldatetime':
        case 'datetime':
        case 'timestamp':
            return DbType.DateTime;
        case 'char':
            return DbType.AnsiStringFixedLength;
        case 'varchar':
            return DbType.AnsiString;
        case 'nchar':
            return DbType.StringFixedLength;
        case 'nvarchar':
        case 'text':
            return DbType.String;
        case 'varbinary':
        case 'binary':
        case 'image':
            return DbType.Binary;
        default:
            return DbType.Object;
    }
}

getDB2DbType = function (field) {
    switch (field.FieldType)
    {
        case 'smallint':
            return DbType.Int16;
        case 'int,integer':
            return DbType.Int32;
        case 'bigint':
            return DbType.Int64;
        case 'real':
            return DbType.Single;
        case 'double':
        case 'float':
            return DbType.Double;
        case 'decimal':
        case 'dec':
        case 'numeric':
        case 'num':
            return DbType.Decimal;
        case 'date':
            return DbType.Date;
        case 'time':
            return DbType.Time;
        case 'timestamp':
            return DbType.DateTime;
        case 'char':
            return DbType.AnsiStringFixedLength;
        case 'varchar':
            return DbType.AnsiString;
        case 'nchar':
            return DbType.StringFixedLength;
        case 'nvarchar':
            return DbType.String;
        case 'blob':
            return DbType.Binary;
        default:
            return DbType.Object;
    }
}

getPostgreSqlDbType = function (field) {
    switch (field.FieldType)
    {
        case 'smallint':
        case 'int2':
            return DbType.Int16;
        case 'integer':
        case 'int4':
            return DbType.Int32;
        case 'bigint':
            return DbType.Int64;
        case 'bigserial':
            return DbType.UInt64;
        case 'real':
            return DbType.Single;
        case 'decimal':
        case 'double':
            return DbType.Double;
        case 'numeric':
            return DbType.Decimal;
        case 'bit':
        case 'bool':
            return DbType.Boolean;
        case 'date':
            return DbType.Date;
        case 'time':
            return DbType.Time;
        case 'timestamp':
            return DbType.DateTime;
        case 'varchar':
        case 'character varying':
            return DbType.AnsiString;
        case 'nchar':
            return DbType.StringFixedLength;
        case 'nvarchar':
        case 'text':
            return DbType.String;
        default:
            return DbType.Object;
    }
}

getSqlDbType = function (field) {
    switch (field.FieldType)
    {
        case 'tinyint':
            return DbType.Byte;
        case 'smallint':
            return DbType.Int16;
        case 'int':
            return DbType.Int32;
        case 'bigint':
            return DbType.Int64;
        case 'real':
            return DbType.Single;
        case 'float':
        case 'decimal':
            return DbType.Double;
        case 'numeric':
            return DbType.Decimal;
        case 'smallmoney':
        case 'money':
            return DbType.Currency;
        case 'bit':
            return DbType.Boolean;
        case 'uniqueidentifier':
            return DbType.Guid;
        case 'smalldatetime':
        case 'datetime':
        case 'timestamp':
            return DbType.DateTime;
        case 'xml':
            return DbType.Xml;
        case 'char':
            return DbType.AnsiStringFixedLength;
        case 'varchar':
            return DbType.AnsiString;
        case 'nchar':
            return DbType.StringFixedLength;
        case 'nvarchar':
        case 'text':
        case 'ntext':
            return DbType.String;
        case 'varbinary':
        case 'binary':
        case 'sql_variant':
        case 'image':
            return DbType.Binary;
        default:
            return DbType.Object;
    }
}