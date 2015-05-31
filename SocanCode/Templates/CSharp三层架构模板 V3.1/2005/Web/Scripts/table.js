// 颜色加深
function fuscous(obj)
{
    obj.style.backgroundColor='#D3DEEF';
}

//颜色恢复为白色
function undertone(obj)
{
    obj.style.backgroundColor='#ffffff';     
}

//全选及全不选
function chooseAll(sel,check){			var objtb=document.getElementById(sel);	var num=objtb.getElementsByTagName("input");	var check=document.getElementById(check);	for(i=0;i<num.length;i++)	{		if(num[i].tagName=="INPUT")		{			if(check.checked==true)			{			    num[i].checked=true;			}			else			{			    num[i].checked=false;			}		}	}}//弹出showModalDialog窗口function popNew(url,arguments,width,height)
{   
    var obj = showModalDialog(url,arguments,'dialogWidth:'+width+'px; dialogHeight:'+height+'px;help:0;status:0;resizeable:1');
    if(obj == 'OK')
    {
        document.getElementById(arguments).click();
    }
}