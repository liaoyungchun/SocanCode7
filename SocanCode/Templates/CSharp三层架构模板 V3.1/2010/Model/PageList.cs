//------------------------------------------------------------------------------
// 创建标识: Copyright (C) 2007-2010 Socansoft.com 版权所有
// 创建描述: SocanCode代码生成器自动创建
//
// 功能描述: 分页数据类
//
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System.Collections.Generic;

/// <summary>
/// 分页数据类
/// </summary>
/// <typeparam name="TModel">结果集中实体的类型</typeparam>
public class PageList<TModel> where TModel : class
{
    public PageList()
    {
        _pageInfo = new PageInfo();
    }

    public PageList(PageInfo pageInfo)
    {
        _pageInfo = pageInfo;
    }

    public PageList(int pageSize, int pageIndex)
    {
        _pageInfo = new PageInfo(pageSize, pageIndex);
    }

    private List<TModel> _list;
    private PageInfo _pageInfo;

    /// <summary>
    /// 分页结果集
    /// </summary>
    public List<TModel> List
    {
        get { return _list; }
        set { _list = value; }
    }

    /// <summary>
    /// 分页信息
    /// </summary>
    public PageInfo PageInfo
    {
        get { return _pageInfo; }
        set { _pageInfo = value; }
    }
}

/// <summary>
/// 分页信息
/// </summary>
public class PageInfo
{
    public PageInfo()
    { }

    public PageInfo(int pageSize, int pageIndex)
    {
        _pageSize = pageSize;
        _pageIndex = pageIndex;
    }

    private int _recordCount;
    private int _pageSize;
    private int _pageIndex;
    private int _pageCount;
    private int _firstIndex;

    /// <summary>
    /// 总记录数
    /// </summary>
    public int RecordCount
    {
        get { return _recordCount; }
        set { _recordCount = value; }
    }

    /// <summary>
    /// 每页大小
    /// </summary>
    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value; }
    }

    /// <summary>
    /// 页索引
    /// </summary>
    public int PageIndex
    {
        get { return _pageIndex; }
        set { _pageIndex = value; }
    }

    /// <summary>
    /// 总页数
    /// </summary>
    public int PageCount
    {
        get { return _pageCount; }
        set { _pageCount = value; }
    }

    /// <summary>
    /// 该页在所有结果中的起始索引。比如每页10条，第1页起始索引为0，第2页起始索引为10，以此类推
    /// </summary>
    public int FirstIndex
    {
        get { return _firstIndex; }
        set { _firstIndex = value; }
    }

    /// <summary>
    /// 开始计算页数及第一条记录的索引。
    /// 请在赋值PageSize,PageIndex,RecoundCount完毕后调用此方法。
    /// </summary>
    public void Compute()
    {
        //计算页数
        if (RecordCount % PageSize == 0)
            PageCount = RecordCount / PageSize;
        else
            PageCount = RecordCount / PageSize + 1;

        //检查页索引与页大小是否正确，并自动修正
        if (PageIndex < 1)
            PageIndex = 1;
        else if (PageCount >= 1 && PageIndex > PageCount)
            PageIndex = PageCount;

        //计算第一条记录和最后一条记录的索引
        _firstIndex = PageSize * (PageIndex - 1);
    }
}
