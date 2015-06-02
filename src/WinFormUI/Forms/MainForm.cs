#define OPENURL

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

namespace SocanCode
{
    public partial class MainForm : Form
    {
        private const string HOME_URL = "http://www.Socansoft.com";
        private const string XML_URL = "http://www.socansoft.com/downloads/socancode/SocanCode.xml";
        private const string DOWNLOAD_URL = "http://www.socansoft.com/downloads/SocanCode/SocanCode.rar";

        public static WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;

        private DatabaseForm frmDatabase;
        private TemplateForm frmTemplate;
        public DebugForm frmDebug;

        public MainForm()
        {
            InitializeComponent();
            labNewVersion.Tag = DOWNLOAD_URL;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Text = this.Text + " V" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            dockPanel = this.dockPanel1;

            frmDatabase = new DatabaseForm();
            frmDatabase.OutputCode += new Action<Model.Database>(frmDatabase_OutputCode);
            frmDatabase.CreateCode += new Action<Model.Table>(frmDatabase_CreateCode);
            frmDatabase.Show(dockPanel);

            frmTemplate = new TemplateForm();
            frmTemplate.TemplateChanged += new Action(frmTemplate_TemplateChanged);
            frmTemplate.Show(dockPanel);

            frmDebug = new DebugForm();
            frmDebug.Show(dockPanel);

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();

            OpenUrl(HOME_URL);
        }

        void frmTemplate_TemplateChanged()
        {
            List<DockContent> contents = new List<DockContent>();
            foreach (DockContent content in dockPanel1.Documents)
            {
                contents.Add(content);
            }

            foreach (DockContent content in contents)
            {
                if (content is ITemplateChanged)
                {
                    ITemplateChanged templateChanged = content as ITemplateChanged;
                    templateChanged.OnTemplateChanged();
                }
            }
        }

        #region 版本检测
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            bool hasGetVersion = false;
            while (!hasGetVersion && count < 3)
            {
                try
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(XML_URL);
                    e.Result = xml;
                    return;
                }
                catch
                {
                    count++;
                }
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                labNewVersion.Text = "连接服务器失败!";
                labNewVersion.LinkColor = Color.Red;
                return;
            }

            XmlDocument xml = e.Result as XmlDocument;
            XmlNode display = xml.SelectSingleNode("DOCUMENT").SelectSingleNode("item").SelectSingleNode("display");
            Version lastVersion = new Version(display.SelectSingleNode("content2").InnerText);
            Version currVersion = Assembly.GetExecutingAssembly().GetName().Version;
            labNewVersion.Tag = display.SelectSingleNode("button").Attributes["buttonlink"].Value;

            if (lastVersion > currVersion)
            {
                labNewVersion.Text = "发现新版本 V" + lastVersion + ", 请点击此处下载";
                labNewVersion.LinkColor = Color.Red;
            }
            else
            {
                labNewVersion.Text = "当前版本已经是最新版本";
                labNewVersion.LinkColor = Color.Green;
            }
        }
        #endregion

        #region frmDatabase事件
        void frmDatabase_OutputCode(Model.Database db)
        {
            OutputCodeForm frm = new OutputCodeForm(db);
            frm.ShowDebug += new Action<string, string, bool>(frm_ShowDebug);
            frm.Show(MainForm.dockPanel);
        }

        void frmDatabase_CreateCode(Model.Table table)
        {
            CreateCodeForm frm = new CreateCodeForm(table);
            frm.ShowDebug += new Action<string, string, bool>(frm_ShowDebug);
            frm.Show(MainForm.dockPanel);
        }

        void frm_ShowDebug(string dbJson, string setJson, bool show)
        {
            frmDebug.txtDbJson.Text = dbJson;
            frmDebug.txtSetJson.Text = setJson;
            frmDebug.Focus();
            if (show)
                frmDebug.Show(dockPanel);
        }
        #endregion

        #region 标签页上的右键菜单
        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.dockPanel1.ActiveContent.DockHandler.Close();
        }

        private void mnuCloseOther_Click(object sender, EventArgs e)
        {
            List<DockContent> contents = new List<DockContent>();
            foreach (DockContent content in dockPanel1.Documents)
            {
                contents.Add(content);
            }

            foreach (DockContent content in contents)
            {
                if (content != this.dockPanel1.ActiveContent)
                {
                    content.Close();
                }
            }
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            mnuCloseOther_Click(sender, e);
            mnuClose_Click(sender, e);
        }
        #endregion

        #region 菜单
        /// <summary>
        /// 生成代码
        /// </summary>
        private void menuCreateCode_Click(object sender, EventArgs e)
        {
            frmDatabase.CreateCurrentTableCode();
        }

        /// <summary>
        /// 输出代码
        /// </summary>
        private void menuOutputCode_Click(object sender, EventArgs e)
        {
            frmDatabase.OutputSelectedDatabaseCode();
        }

        /// <summary>
        /// 数据库
        /// </summary>
        private void menufrmDatabase_Click(object sender, EventArgs e)
        {
            frmDatabase.Show(dockPanel);
        }

        /// <summary>
        /// 模板
        /// </summary>
        private void menuTemplate_Click(object sender, EventArgs e)
        {
            frmTemplate.Show(dockPanel);
        }

        /// <summary>
        /// 调拭
        /// </summary>
        private void menuShowDebug_Click(object sender, EventArgs e)
        {
            frmDebug.Show(dockPanel);
        }

        /// <summary>
        /// 代码转模板
        /// </summary>
        private void menuCodeToTemplateForm_Click(object sender, EventArgs e)
        {
            CodeToTemplateForm frm = new CodeToTemplateForm();
            frm.Show(dockPanel);
        }

        /// <summary>
        /// 代码去行号空行
        /// </summary>
        private void menuCodeClear_Click(object sender, EventArgs e)
        {
            CodeClearForm frm = new CodeClearForm();
            frm.Show(dockPanel);
        }
        /// <summary>
        /// cSharp转换VBNET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cSharp转换VBNETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSharpToVBForm frm = new CSharpToVBForm();
            frm.Show(dockPanel);
        }
        /// <summary>
        /// 官方网站
        /// </summary>
        private void menuWebsite_Click(object sender, EventArgs e)
        {
            OpenUrl(HOME_URL);
        }

        /// <summary>
        /// 关于
        /// </summary>
        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }
        #endregion

        private void labNewVersion_Click(object sender, EventArgs e)
        {
            object tag = (sender as ToolStripStatusLabel).Tag;
            Process.Start(new ProcessStartInfo("IEXPLORE.EXE", tag.ToString()));
        }

        private void dockPanel1_ContentAdded(object sender, DockContentEventArgs e)
        {
            if (e.Content.DockHandler.ShowHint == DockState.Document
                   || e.Content.DockHandler.ShowHint == DockState.Unknown)
            {
                e.Content.DockHandler.TabPageContextMenuStrip = cmsDockPanel;
            }
        }

        /// <summary>
        /// 打开一个文件
        /// </summary>
        public static void OpenFile(FileInfo fi)
        {
            foreach (DockContent content in dockPanel.Documents)
            {
                if (content.GetType() == typeof(EditForm))
                {
                    EditForm frm = content as EditForm;
                    if (frm.FileInfo.FullName.Equals(fi.FullName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        content.Activate();
                        return;
                    }
                }
            }

            EditForm frm2 = new EditForm(fi);
            frm2.Show(dockPanel);
        }

        /// <summary>
        /// 打开一个新链接
        /// </summary>
        public static void OpenUrl(string url)
        {
#if OPENURL
            if (dockPanel.InvokeRequired)
            {
                dockPanel.BeginInvoke(new Action<string>(OpenUrl), new object[] { url });
                return;
            }

            WebBrowser.BrowserForm frm = new WebBrowser.BrowserForm();
            frm.Show(dockPanel);
            frm.Go(url);
#endif
        }


    }
}