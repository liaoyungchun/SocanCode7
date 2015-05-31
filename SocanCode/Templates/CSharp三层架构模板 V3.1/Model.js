function model() {
    var codes = new Array();

    // 复制Model文件夹
    codes.push({
        type: 'copy',
        isfolder: true,
        source: '{0}\\Model'.format(set.VSVersion),
        target: 'Model'
    });

    // 逐表生成
    for (var i = 0; i < db.Selects.length; i++) {
        var table = db.Selects[i];
        codes.push(tableInternalModel(table));
        codes.push(tableEditableModel(table));
    }

    return codes;
}

function tableEditableModel(table) {
    var NewLine = '\n';
    var temp = '';
    temp += 'using System;' + NewLine;
    temp += 'using System.Collections.Generic;' + NewLine;
    if (set.ModelStyle == 'MVC2') {
        temp += 'using System.ComponentModel;' + NewLine;
        temp += 'using System.ComponentModel.DataAnnotations;' + NewLine;
    }
    temp += NewLine;
    temp += 'namespace ' + getNamespace('Model') + NewLine;
    temp += '{' + NewLine;
    temp += '    /// <summary>' + NewLine;
    temp += '    /// 实体类 ' + table.Name + NewLine;
    temp += '    /// </summary>' + NewLine;
    temp += '    public partial class {0}'.format(table.Name) + NewLine;
    temp += '    { }' + NewLine;
    temp += '}';

    return {
        type: 'code',
        title: 'Model-editable',
        path: 'Model\\editable\\{0}.cs'.format(table.Name),
        code: temp
    };
}

function tableInternalModel(table) {
    var NewLine = '\n';
    var temp = '';
    temp += 'using System;' + NewLine;
    if (set.ModelStyle == 'MVC2') {
        temp += 'using System.ComponentModel;' + NewLine;
        temp += 'using System.ComponentModel.DataAnnotations;' + NewLine;
    }
    temp += NewLine;
    temp += 'namespace {0}'.format(getNamespace('Model')) + NewLine;
    temp += '{' + NewLine;
    temp += '    /// <summary>' + NewLine;
    temp += '    /// 实体类 ' + table.Name + ', 此类请勿动，以方便表字段更改时重新生成覆盖' + NewLine;
    temp += '    /// </summary>' + NewLine;
    temp += '    [Serializable]' + NewLine;
    temp += '    public partial class {0} : ICloneable'.format(table.Name) + NewLine;
    temp += '    {' + NewLine;

    temp += '        public {0}()'.format(table.Name) + NewLine;
    temp += '        { }' + NewLine;
    temp += '' + NewLine;
    temp += '        /// <summary>' + NewLine;
    temp += '        /// 构造函数 ' + table.Name + NewLine;
    temp += '        /// </summary>' + NewLine;
    for (var i = 0; i < table.Fields.length; i++) {
        var field = table.Fields[i];
        temp += '        /// <param name="{0}">{1}</param>'.format(field.Name.toLowerCase(), field.Descn) + NewLine;
    }
    temp += '        public {0}({1})'.format(table.Name, getParms()) + NewLine;

    function getParms() {
        var temp = '';
        for (var i = 0; i < table.Fields.length; i++) {
            var field = table.Fields[i];
            temp += '{0} {1}'.format(csType[field.DbType], field.Name.toLowerCase());
            if (i != table.Fields.length - 1)
                temp += ', ';
        }
        return temp;
    }

    temp += '        {' + NewLine;
    for (var i = 0; i < table.Fields.length; i++) {
        var field = table.Fields[i];
        temp += '            this.{0} = {1};'.format(field.Name, field.Name.toLowerCase()) + NewLine;
    }
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        #region 实体属性' + NewLine;
    temp += NewLine;
    if (set.ModelStyle == 'CS2') {
        for (var i = 0; i < table.Fields.length; i++) {
            var field = table.Fields[i];
            temp += '        private {0} _{1};'.format(csType[field.DbType], field.Name.toLowerCase()) + NewLine;
        }
        temp += NewLine;
        for (var i = 0; i < table.Fields.length; i++) {
            var field = table.Fields[i];
            temp += '        /// <summary>' + NewLine;
            temp += '        /// {0}'.format(field.Descn) + NewLine;
            temp += '        /// </summary>' + NewLine;
            temp += '        public {0} {1}'.format(csType[field.DbType], field.Name) + NewLine;
            temp += '        {' + NewLine;
            temp += '            set { _{0} = value; }'.format(field.Name.toLowerCase()) + NewLine;
            temp += '            get { return _{0}; }'.format(field.Name.toLowerCase()) + NewLine;
            temp += '        }' + NewLine;
            temp += NewLine;
        }
    } else {
        for (var i = 0; i < table.Fields.length; i++) {
            var field = table.Fields[i];
            temp += '        /// <summary>' + NewLine;
            temp += '        /// {0}'.format(field.Descn) + NewLine;
            temp += '        /// </summary>' + NewLine;
            if (set.ModelStyle == 'MVC2') {
                temp += '        [DisplayName("{0}")]'.format(field.Descn) + NewLine;
                if (!field.IsId && !field.IsKey && !field.AllowNull)
                    temp += '        [Required(ErrorMessage="{0}不能为空。")]' + NewLine;
                if (csMethod[field.DbType] == 'GetString')
                    temp += '        [RegularExpression(@"[\w\W]{1,{0}}", ErrorMessage = "{0}为1－{1}位。")] //此默认生成的正则为允许任意字符，请根据业务逻辑修改'.format(field.Length) + NewLine;
            }
            temp += '        public {0} {1} { get; set; }'.format(csType[field.DbType], field.Name) + NewLine;
            temp += NewLine;
        }
    }
    temp += '        #endregion' + NewLine;
    temp += NewLine;
    temp += '        #region ICloneable 成员' + NewLine;
    temp += NewLine;
    temp += '        public object Clone()' + NewLine;
    temp += '        {' + NewLine;
    temp += '            return this.MemberwiseClone();' + NewLine;
    temp += '        }' + NewLine;
    temp += NewLine;
    temp += '        #endregion' + NewLine;
    temp += NewLine;
    temp += '        public override bool Equals(object obj)' + NewLine;
    temp += '        {' + NewLine;
    temp += '            {0}.{1} model = obj as {0}.{1};'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '            if ({0})'.format(getCompare()) + NewLine;

    function getCompare() {
        var temp = new Array();
        temp.push('model != null');
        for (var i = 0; i < table.CondFields.length; i++) {
            var field = table.CondFields[i];
            temp.push('model.{0} == this.{0}'.format(field.Name));
        }
        return temp.join(' && ');
    }

    temp += '                return true;' + NewLine;
    temp += '' + NewLine;
    temp += '            return false;' + NewLine;
    temp += '        }' + NewLine;
    temp += '' + NewLine;
    temp += '        public override int GetHashCode()' + NewLine;
    temp += '        {' + NewLine;
    temp += '            return {0};'.format(getReturn()) + NewLine;

    function getReturn() {
        var temp = new Array();
        for (var i = 0; i < table.CondFields.length; i++) {
            var field = table.CondFields[i];
            temp.push('{0}.GetHashCode()'.format(field.Name));
        }
        return temp.join(' ^ ');
    }

    temp += '        }' + NewLine;
    temp += '    }' + NewLine;
    temp += '}';

    return {
        type: 'code',
        title: 'Model-internal',
        path: 'Model\\internal\\{0}.cs'.format(table.Name),
        code: temp
    };
}
