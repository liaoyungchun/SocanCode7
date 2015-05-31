function mySql() {
    var NewLine = '\n';
    var temp = '';

    for (var i = 0; i < db.Selects.length; i++) {
        temp += tableMySql(db.Selects[i]) + NewLine;
    }

    return {
        title: '存储过程',
        path: '{0}.sql'.format(db.Name),
        code: temp
    };
}

function tableMySql(table) {
    var NewLine = '\n';
    var temp = '';
    temp += 'DELIMITER $$' + NewLine;
    temp += 'DROP PROCEDURE IF EXISTS `sp_{0}_Add`$$'.format(table.Name) + NewLine;
    temp += '/*******************************************************************************' + NewLine;
    temp += '** 增加一条记录' + NewLine;
    temp += '*******************************************************************************/' + NewLine;
    temp += 'CREATE PROCEDURE `sp_{0}_Add`'.format(table.Name) + NewLine;
    temp += '(';
    temp += getAddFields(function () { return NewLine + getFieldParm(this); }) + NewLine;
    temp += ')' + NewLine;
    temp += 'BEGIN' + NewLine;
    temp += 'INSERT INTO `{0}`({1})VALUES({2});'.format(table.Name,
        getAddFields(function () { return '`{0}`'.format(this.Name); }),
        getAddFields(function () { return 'in_{0}'.format(this.Name); })) + NewLine;
    temp += 'END$$' + NewLine;
    temp += 'DELIMITER ;' + NewLine;
    temp += NewLine;

    function getAddFields(func) {
        return table.Fields.fieldJoin(func, ',', function () {
            return !this.IsId && (set.FilterDefaultableField == 'false' || !this.DefaultValue);
        });
    }

    temp += 'DELIMITER $$' + NewLine;
    temp += 'DROP PROCEDURE IF EXISTS `sp_{0}_Update`$$'.format(table.Name) + NewLine;
    temp += '/*******************************************************************************' + NewLine;
    temp += '** 修改一条记录' + NewLine;
    temp += '*******************************************************************************/' + NewLine;
    temp += 'CREATE PROCEDURE `sp_{0}_Update`'.format(table.Name) + NewLine;
    temp += '(';
    temp += table.UncondFields.fieldJoin(function () { return NewLine + getFieldParm(this); }, ',') + ',';
    temp += table.CondFields.fieldJoin(function () { return NewLine + getFieldParm(this); }, ',');
    temp += NewLine;
    temp += ')' + NewLine;
    temp += 'BEGIN' + NewLine;
    temp += 'UPDATE `{0}` SET {1} WHERE {2};'.format(table.Name,
        table.UncondFields.fieldJoin(function () { return '`{0}`=in_{0}'.format(this.Name); }, ','),
        table.CondFields.fieldJoin(function () { return '`{0}`=in_{0}'.format(this.Name); }, ' AND ')) + NewLine;
    temp += 'END$$' + NewLine;
    temp += 'DELIMITER ;' + NewLine;
    temp += NewLine;
    temp += 'DELIMITER $$' + NewLine;
    temp += 'DROP PROCEDURE IF EXISTS `sp_{0}_Delete`$$'.format(table.Name) + NewLine;
    temp += '/*******************************************************************************' + NewLine;
    temp += '** 删除一条记录' + NewLine;
    temp += '*******************************************************************************/' + NewLine;
    temp += 'CREATE PROCEDURE `sp_{0}_Delete`'.format(table.Name) + NewLine;
    temp += '(';
    temp += table.CondFields.fieldJoin(function () { return NewLine + getFieldParm(this); }, ',') + NewLine;
    temp += ')' + NewLine;
    temp += 'BEGIN' + NewLine;
    temp += 'DELETE FROM `{0}` WHERE {1};'.format(table.Name,
        table.CondFields.fieldJoin(function () { return '`{0}`=in_{0}'.format(this.Name); }, ' AND ')) + NewLine;
    temp += 'END$$' + NewLine;
    temp += 'DELIMITER ;' + NewLine;
    temp += NewLine;
    temp += 'DELIMITER $$' + NewLine;
    temp += 'DROP PROCEDURE IF EXISTS `sp_{0}_Exists`$$'.format(table.Name) + NewLine;
    temp += '/*******************************************************************************' + NewLine;
    temp += '** 是否已经存在' + NewLine;
    temp += '*******************************************************************************/' + NewLine;
    temp += 'CREATE PROCEDURE `sp_{0}_Exists`'.format(table.Name) + NewLine;
    temp += '(';
    temp += table.CondFields.fieldJoin(function () { return NewLine + getFieldParm(this); }, ',') + NewLine;
    temp += ')' + NewLine;
    temp += 'BEGIN' + NewLine;
    temp += 'SELECT COUNT(*) FROM `{0}` WHERE {1};'.format(table.Name,
        table.CondFields.fieldJoin(function () { return '`{0}`=in_{0}'.format(this.Name); }, ' AND ')) + NewLine;
    temp += 'END$$' + NewLine;
    temp += 'DELIMITER ;' + NewLine;
    temp += NewLine;
    temp += 'DELIMITER $$' + NewLine;
    temp += 'DROP PROCEDURE IF EXISTS `sp_{0}_GetCount`$$'.format(table.Name) + NewLine;
    temp += '/*******************************************************************************' + NewLine;
    temp += '** 获取记录条数' + NewLine;
    temp += '*******************************************************************************/' + NewLine;
    temp += 'CREATE PROCEDURE `sp_{0}_GetCount`()'.format(table.Name) + NewLine;
    temp += 'BEGIN' + NewLine;
    temp += 'SELECT COUNT(*) FROM `{0}`;'.format(table.Name) + NewLine;
    temp += 'END$$' + NewLine;
    temp += 'DELIMITER ;' + NewLine;
    temp += NewLine;
    temp += 'DELIMITER $$' + NewLine;
    temp += 'DROP PROCEDURE IF EXISTS `sp_{0}_GetModel`$$'.format(table.Name) + NewLine;
    temp += '/*******************************************************************************' + NewLine;
    temp += '** 得到一个实体' + NewLine;
    temp += '*******************************************************************************/' + NewLine;
    temp += 'CREATE PROCEDURE `sp_{0}_GetModel`'.format(table.Name) + NewLine;
    temp += '(';
    temp += table.CondFields.fieldJoin(function () { return NewLine + getFieldParm(this); }, ',') + NewLine;
    temp += ')' + NewLine;
    temp += 'BEGIN' + NewLine;
    temp += 'SELECT * FROM `{0}` WHERE {1};'.format(table.Name,
        table.CondFields.fieldJoin(function () { return '`{0}`=in_{0}'.format(this.Name); }, ' AND ')) + NewLine;
    temp += 'END$$' + NewLine;
    temp += 'DELIMITER ;' + NewLine;
    temp += NewLine;
    temp += 'DELIMITER $$' + NewLine;
    temp += 'DROP PROCEDURE IF EXISTS `sp_{0}_GetAllList`$$'.format(table.Name) + NewLine;
    temp += '/*******************************************************************************' + NewLine;
    temp += '** 得到所有实体' + NewLine;
    temp += '*******************************************************************************/' + NewLine;
    temp += 'CREATE PROCEDURE `sp_{0}_GetAllList`()'.format(table.Name) + NewLine;
    temp += 'BEGIN' + NewLine;
    temp += 'SELECT * FROM `{0}`;'.format(table.Name) + NewLine;
    temp += 'END$$' + NewLine;
    temp += 'DELIMITER ;' + NewLine;


    function getFieldParm(field) {
        switch (field.DbType) {
            case 'AnsiString':
            case 'AnsiStringFixedLength':
            case 'String':
            case 'StringFixedLength':
                return 'in_{0} {1}({2})'.format(field.Name, field.FieldType, field.Length);
            default:
                return 'in_{0} {1}'.format(field.Name, field.FieldType);
        }
    }

    return temp;
}