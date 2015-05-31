/**
* 将一个Field数组用分割符相连组成字符串
* contentFunc为每一个Field要转化为字符串的方法
* split为分割符
* condFunc为过滤Field条件的方法，返回true则拼接，否则略过
*/
Array.prototype.fieldJoin = function (contentFunc, split, condFunc) {
    var arr = new Array();
    for (var i = 0; i < this.length; i++) {
        var field = this[i];
        if (!condFunc || condFunc.call(field)) {
            arr.push(contentFunc.call(field));
        }
    }
    if (split)
        return arr.join(split);
    else
        return arr.join('');
}

/**
* 以下三个函数为字符串格式化，会让代码看起来更直观
*/
String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}

String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,
        function (m, i) {
            return args[i];
        });
}

String.prototype.formatln = function () {
    return String.prototype.format.apply(this, arguments) + '\n';
}

/**
* 在字符串不为空时给其加后缀，返回新的字符串
*/
String.prototype.appendUnEmpty = function (ch) {
    if (this)
        return this + ch;
    else
        return '';
}