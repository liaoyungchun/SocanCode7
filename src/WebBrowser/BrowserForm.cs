using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AxSHDocVw;
using WeifenLuo.WinFormsUI.Docking;

namespace WebBrowser
{
    public partial class BrowserForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        /// <summary>
        /// 404错误时要转向的页面
        /// </summary>
        private readonly string ERROR_GOTO = "http://www.socansoft.com";

        #region 构造函数

        public BrowserForm()
        {
            InitializeComponent();
        }

        public BrowserForm(ContextMenuStrip cms, string url)
        {
            InitializeComponent();
            this.TabPageContextMenuStrip = cms;

            if (false == string.IsNullOrEmpty(url))
            {
                OpenUrl(url);
            }
        }

        #endregion

        #region 事件

        public delegate void TitleChangeEventHandler(IDockContent dockContent, string title);

        /// <summary>
        /// 当标题改变时要执行的事件
        /// </summary>
        public event TitleChangeEventHandler TitleChange;

        #endregion

        #region 属性

        /// <summary>
        /// 当前网页文档
        /// </summary>
        public mshtml.IHTMLDocument2 Document
        {
            get
            {
                mshtml.IHTMLDocument2 doc = AxWebBrowser1.Document as mshtml.IHTMLDocument2;
                return doc;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 调用系统接口查看源文件
        /// </summary>
        public void ViewSource()
        {
            try
            {
                BrowseHelper.BrowserWapper.ViewSource(Document);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 打开一个网站
        /// </summary>
        /// <param name="url">网站URL</param>
        public void Go(string url)
        {
            Application.DoEvents();
            try
            {
                AxWebBrowser1.Navigate(url);
                cobURL.Text = url;
                labStatus.Text = "正在打开网站 " + url;
                AxWebBrowser1.Focus();
                Application.DoEvents();
                AddItemToToolStripComboBox(cobURL, url);
            }
            catch (Exception)
            {
            }
        }

        private void AddItemToToolStripComboBox(ToolStripComboBox cob, string item)
        {
            if (cob.Items.Contains(item))
            {
                cob.Items.Remove(item);
            }

            cob.Items.Insert(0, item);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="keyword">要搜索的关键词</param>
        public void Search(string keyword)
        {
            ToolStripMenuItem searchEngine = GetSelectedSearchEngine();
            if (searchEngine != null)
            {
                string url = string.Format(searchEngine.Tag.ToString(), System.Web.HttpUtility.UrlEncode(keyword));
                Go(url);
                AddItemToToolStripComboBox(cobSearch, keyword);
            }
        }

        private void AddSearchHistory(string keyword)
        {
            if (cobSearch.Items.Contains(keyword))
            {
                cobSearch.Items.Remove(keyword);
            }
            cobSearch.Items.Insert(0, keyword);
        }

        #endregion

        #region 搜索

        private void cobSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search(cobSearch.Text.Trim());
            }
        }

        private void changeSearchEngine(ToolStripMenuItem selctedSearchEngine)
        {
            ToolStripItemCollection searchEngines = btnSearch.DropDownItems;
            foreach (ToolStripItem searchEngine in searchEngines)
            {
                if (searchEngine is ToolStripMenuItem)
                {
                    (searchEngine as ToolStripMenuItem).Checked = false;
                }
            }

            selctedSearchEngine.Checked = true;
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeSearchEngine(sender as ToolStripMenuItem);
            btnSearch_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cobSearch.Text.Trim()))
            {
                Search(cobSearch.Text.Trim());
            }
        }

        private void mnuClearSearchHistory_Click(object sender, EventArgs e)
        {
            cobSearch.Items.Clear();
        }

        /// <summary>
        /// 获取当前选中的搜索引擎，如果没有返回第一个，如果不存在搜索引擎，返回Null
        /// </summary>
        private ToolStripMenuItem GetSelectedSearchEngine()
        {
            List<ToolStripMenuItem> searchEngines = GetAllSearchEngines();

            if (searchEngines.Count > 0)
            {
                foreach (ToolStripMenuItem searchEngine in searchEngines)
                {
                    if (searchEngine.Checked)
                    {
                        return searchEngine;
                    }
                }

                return searchEngines[0];
            }

            return null;
        }

        /// <summary>
        /// 获取所有的搜索引擎
        /// </summary>
        private List<ToolStripMenuItem> GetAllSearchEngines()
        {
            List<ToolStripMenuItem> searchEngines = new List<ToolStripMenuItem>();
            foreach (ToolStripItem item in btnSearch.DropDownItems)
            {
                if (item is ToolStripMenuItem && item.Tag != null && !string.IsNullOrEmpty(item.Tag.ToString()))
                {
                    searchEngines.Add(item as ToolStripMenuItem);
                }
            }
            return searchEngines;
        }

        #endregion

        #region AxWebBrowser

        /// <summary>
        /// 这里控制状态栏显示鼠标移向的链接
        /// </summary>
        private void AxWebBrowser1_StatusTextChange(object sender, DWebBrowserEvents2_StatusTextChangeEvent e)
        {
            Application.DoEvents();
            labStatus.Text = e.text;
        }

        /// <summary>
        /// 这里控制“前进”和“后退”按钮是否可用
        /// </summary>
        private void AxWebBrowser1_CommandStateChange(object sender, DWebBrowserEvents2_CommandStateChangeEvent e)
        {
            Application.DoEvents();
            if (e.command == 1)
            {
                btnGoFoward.Enabled = e.enable;
            }
            else if (e.command == 2)
            {
                btnGoBack.Enabled = e.enable;
            }
        }

        /// <summary>
        /// 这是按下Shift点击时弹出新窗口的事件，应该打开一个新标签页
        /// </summary>
        private void AxWebBrowser1_NewWindow3(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow3Event e)
        {
            BrowserForm frmBrowser = new BrowserForm();
            frmBrowser.TitleChange = TitleChange;
            e.ppDisp = frmBrowser.AxWebBrowser1.Application;
            if (this.DockPanel != null)
            {
                frmBrowser.Show(this.DockPanel);
            }
            else
            {
                frmBrowser.Show();
            }
        }

        /// <summary>
        /// 当标题变化时的事件，标签页上应该显示标题。
        /// 如果是浏览器软件，则软件的标题应该变化。
        /// </summary>
        private void AxWebBrowser1_TitleChange(object sender, AxSHDocVw.DWebBrowserEvents2_TitleChangeEvent e)
        {
            Application.DoEvents();
            this.TabText = BrowseHelper.BrowserUtility.CutString(e.text, 20); ;
            this.ToolTipText = e.text;

            if (TitleChange != null)
            {
                TitleChange(this, e.text);
            }
        }

        /// <summary>
        /// 文档下载完成时，URL栏显示最终的地址
        /// </summary>
        private void AxWebBrowser1_DownloadComplete(object sender, EventArgs e)
        {
            Application.DoEvents();
            cobURL.Text = AxWebBrowser1.LocationURL;
        }

        /// <summary>
        /// 下载的进度，应该显示在进度条上
        /// </summary>
        private void AxWebBrowser1_ProgressChange(object sender, AxSHDocVw.DWebBrowserEvents2_ProgressChangeEvent e)
        {
            Application.DoEvents();
            switch (e.progress)
            {
                case -1:
                    break;
                case 0:
                    pbStatus.Visible = false;
                    break;
                default:
                    pbStatus.Visible = true;
                    pbStatus.Maximum = e.progressMax;
                    pbStatus.Value = Math.Min(e.progressMax, e.progress);
                    break;
            }
        }

        private void AxWebBrowser1_NavigateError(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateErrorEvent e)
        {
            Application.DoEvents();
            if (Convert.ToInt32(e.statusCode) == 400)
            {
                labStatus.Text = "网站未找到...";
                if (!string.IsNullOrEmpty(ERROR_GOTO))
                {
                    OpenUrl(ERROR_GOTO);
                }
            }
        }

        private void AxWebBrowser1_NewWindow2(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow2Event e)
        {
            BrowserForm frmBrowser = new BrowserForm();
            e.ppDisp = frmBrowser.AxWebBrowser1.Application;
            if (this.DockPanel != null)
            {
                frmBrowser.Show(this.DockPanel);
            }
            else
            {
                frmBrowser.Show();
            }
        }
        #endregion

        #region Url文本框

        private void cobURL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((e.Modifiers & Keys.Control) == Keys.Control
                    && (e.Modifiers & Keys.Shift) == Keys.Shift)
                {
                    //按下了Ctrl和Shift键
                    OpenUrl(string.Format("http://www.{0}.com.cn", cobURL.Text.Trim()));
                }
                else if (e.Modifiers == Keys.Shift)
                {
                    //按下了Shift键
                    OpenUrl(string.Format("http://www.{0}.net", cobURL.Text.Trim()));
                }
                else if (e.Modifiers == Keys.Control)
                {
                    //按下了Ctrl键
                    OpenUrl(string.Format("http://www.{0}.com", cobURL.Text.Trim()));
                }
                else
                {
                    OpenUrl(cobURL.Text.Trim());
                }
            }
        }

        private void btnGo_ButtonClick(object sender, EventArgs e)
        {
            OpenUrl(cobURL.Text.Trim());
        }

        private void btnGo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cobURL.Items.Clear();
        }

        private void OpenUrl(string url)
        {
            if (url.ToUpper().IndexOf(":") < 0)
            {
                if (url.IndexOf(".") < 0)
                {
                    Search(url);
                }
                else
                {
                    url = url.Insert(0, "http://");
                    Go(url);
                }
            }
            else
            {
                Go(url);
            }
        }

        #endregion

        #region 宽度自适应

        private void toolStrip1_SizeChanged(object sender, EventArgs e)
        {
            SetWidthOfCobURL();
        }

        private void statusStrip1_SizeChanged(object sender, EventArgs e)
        {
            SetWidthOfLabStatus();
        }

        private void tspbStatus_VisibleChanged(object sender, EventArgs e)
        {
            SetWidthOfLabStatus();
        }

        private void SetWidthOfLabStatus()
        {
            Application.DoEvents();
            int width = 0;
            foreach (ToolStripItem item in statusStrip1.Items)
            {
                if (item != labStatus && item.Visible == true)
                {
                    width += item.Width;
                }
            }
            labStatus.Width = statusStrip1.Width - width - 15 - (pbStatus.Visible ? 2 : 0);
        }

        private void SetWidthOfCobURL()
        {
            Application.DoEvents();
            int width = 0;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item != cobURL)
                {
                    width += item.Width;
                }
            }
            cobURL.Width = toolStrip1.Width - width - 20;
        }

        #endregion

        #region 工具栏

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                AxWebBrowser1.Refresh();
            }
            catch
            {
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            try
            {
                AxWebBrowser1.GoBack();
            }
            catch
            {
            }
        }

        private void btnGoFoward_Click(object sender, EventArgs e)
        {
            try
            {
                AxWebBrowser1.GoForward();
            }
            catch
            {
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                AxWebBrowser1.Stop();
            }
            catch
            {
            }
        }

        private void btnGoHome_Click(object sender, EventArgs e)
        {
            try
            {
                AxWebBrowser1.GoHome();
            }
            catch
            {
            }
        }

        #endregion
    }
}