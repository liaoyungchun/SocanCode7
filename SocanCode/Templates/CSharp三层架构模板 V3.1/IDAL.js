function idal() {
    var codes = new Array();

    // 复制IDAL文件夹
    codes.push({
        type: 'copy',
        isfolder: true,
        source: set.VSVersion + '\\IDAL',
        target: 'IDAL'
    });

    // 逐表生成IDAL代码
    for (var i = 0; i < db.Selects.length; i++) {
        var table = db.Selects[i];
        codes.push(tableIDal(table));
    }

    return codes;
}

function tableIDal(table) {
    var NewLine = '\n';
    var temp = '';
    temp += 'using System;' + NewLine;
    temp += 'using System.Data;' + NewLine;
    temp += 'using System.Collections;' + NewLine;
    temp += 'using System.Collections.Generic;' + NewLine;
    temp += NewLine;
    temp += 'namespace {0}'.format(getNamespace('IDAL')) + NewLine;
    temp += '{' + NewLine;
    temp += '	/// <summary>' + NewLine;
    temp += '	/// 接口层 I{0}'.format(table.Name) + NewLine;
    temp += '	/// </summary>' + NewLine;
    temp += '	public interface I{0}'.format(table.Name) + NewLine;
    temp += '	{' + NewLine;
    temp += '		/// <summary>' + NewLine;
    temp += '		/// 增加一条数据' + NewLine;
    temp += '		/// </summary>' + NewLine;
    temp += '		int Add({0}.{1} model);'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += NewLine;
    temp += '		/// <summary>' + NewLine;
    temp += '		/// 更新一条数据' + NewLine;
    temp += '		/// </summary>' + NewLine;
    temp += '		int Update({0}.{1} model);'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += NewLine;
    temp += '		/// <summary>' + NewLine;
    temp += '		/// 删除一条数据' + NewLine;
    temp += '		/// </summary>' + NewLine;
    temp += '		int Delete({0});'.format(getFuncParm(table, true)) + NewLine;
    temp += NewLine;
    temp += '		/// <summary>' + NewLine;
    temp += '		/// 是否存在该记录' + NewLine;
    temp += '		/// </summary>' + NewLine;
    temp += '		bool Exists({0});'.format(getFuncParm(table, true)) + NewLine;
    temp += NewLine;
    temp += '		/// <summary>' + NewLine;
    temp += '		/// 得到一个对象实体' + NewLine;
    temp += '		/// </summary>' + NewLine;
    temp += '		{0}.{1} GetModel({2});'.format(getNamespace('Model'), table.Name, getFuncParm(table, true)) + NewLine;
    temp += NewLine;
    temp += '		/// <summary>' + NewLine;
    temp += '		/// 获取数据条数' + NewLine;
    temp += '		/// </summary>' + NewLine;
    temp += '		int GetCount();' + NewLine;
    temp += NewLine;
    temp += '		/// <summary>' + NewLine;
    temp += '		/// 获取泛型数据列表' + NewLine;
    temp += '		/// </summary>' + NewLine;
    temp += '		List<{0}.{1}> GetList();'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += NewLine;
    temp += '		/// <summary>' + NewLine;
    temp += '		/// 分页获取泛型数据列表' + NewLine;
    temp += '		/// </summary>' + NewLine;
    temp += '		PageList<{0}.{1}> GetPageList(PageInfo pi);'.format(getNamespace('Model'), table.Name) + NewLine;
    temp += '	}' + NewLine;
    temp += '}' + NewLine;

    return {
        type: 'code',
        title: 'IDAL',
        path: 'IDAL\\{0}.cs'.format(table.Name),
        code: temp
    };
}