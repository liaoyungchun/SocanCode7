function dalFactory() {
    var codes = new Array();

    // 复制DALFactory文件夹
    codes.push({
        type: 'copy',
        isfolder: true,
        source: '{0}\\DALFactory'.format(set.VSVersion),
        target: 'DALFactory'
    });

    var NewLine = '\n';
    var temp = '';
    temp += 'using System;' + NewLine;
    temp += 'using System.Configuration;' + NewLine;
    temp += 'using System.Collections.Generic;' + NewLine;
    temp += 'using System.Text;' + NewLine;
    temp += 'using System.Reflection;' + NewLine;
    temp += NewLine;
    temp += 'namespace DALFactory' + NewLine;
    temp += '{' + NewLine;
    temp += '    public class DataAccess' + NewLine;
    temp += '    {' + NewLine;
    temp += '        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];' + NewLine;
    for (var i = 0; i < db.Selects.length; i++) {
        var table = db.Selects[i];
        temp += NewLine;
        temp += '        public static {0}.I{1} Create{2}{1}()'.format(getNamespace('IDAL'), table.Name, set.NamespaceSuffix) + NewLine;
        temp += '        {' + NewLine;
        temp += '            string className = {0}'.format(getClassName()) + NewLine;

        function getClassName() {
            var temp = '';
            if (set.NamespacePrefix)
                temp += '"' + set.NamespacePrefix + '." +';
            temp += 'path + "';
            if (set.NamespaceSuffix)
                temp += '.' + set.NamespaceSuffix;
            temp += '.' + table.Name + '";';
            return temp;
        }

        temp += '            return ({0}.I{1})Assembly.Load(path).CreateInstance(className);'.format(getNamespace('IDAL'), table.Name) + NewLine;
        temp += '        }' + NewLine;
    }
    temp += '    }' + NewLine;
    temp += '}' + NewLine;

    codes.push({
        type: 'code',
        title: 'DALFactory',
        path: 'DALFactory\\DataAccess.cs',
        code: temp
    });

    return codes;
}