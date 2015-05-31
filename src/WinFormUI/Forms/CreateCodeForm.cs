using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Generator;

namespace SocanCode
{
    public partial class CreateCodeForm : WeifenLuo.WinFormsUI.Docking.DockContent, ITemplateChanged
    {
        private Model.Table _table;
        public event Action<string, string, bool> ShowDebug;

        public CreateCodeForm(Model.Table table)
        {
            InitializeComponent();
            this.TabText = "生成代码 " + table.Name;
            _table = table;
        }

        private void btnViewDebug_Click(object sender, EventArgs e)
        {
            selectTemplateUserControl1.SaveSetting();

            this._table.Database.Selects = new List<Model.Table>() { _table };

            Template template = new Template();
            template.TemplateFolder = selectTemplateUserControl1.TemplateFolderPath;
            template.Database = this._table.Database;
            template.Settings = selectTemplateUserControl1.Settings;

            template.Debug();
            if (ShowDebug != null) ShowDebug(template.DatabaseJson, template.SettingJson, true);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            selectTemplateUserControl1.SaveSetting();

            this._table.Database.Selects = new List<Model.Table>() { _table };

            Template template = new Template();
            template.TemplateFolder = selectTemplateUserControl1.TemplateFolderPath;
            template.Database = this._table.Database;
            template.Settings = selectTemplateUserControl1.Settings;

            List<IJSResult> jsResults = template.GetJSResults();
            if (ShowDebug != null) ShowDebug(template.DatabaseJson, template.SettingJson, false);

            tcCodes.Controls.Clear();
            foreach (IJSResult r in jsResults)
            {
                if (r.GetType() == typeof(Codes))
                    AddCodeTabPage(r as Codes);
            }

            if (tcCodes.TabPages.Count > 0)
            {
                btnSaveAll.Enabled = true;
                btnSaveCurrentTab.Enabled = true;
            }
        }

        private void btnSaveCurrentTab_Click(object sender, EventArgs e)
        {
            if (tcCodes.SelectedTab == null)
            {
                ShowMessage.Alert("请先生成代码！");
                return;
            }

            Generator.Codes code = tcCodes.SelectedTab.Tag as Generator.Codes;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.FileName = code.FileName;
            dlg.Filter = string.Format(".{0}|*.{0}", code.Ext);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Generator.IOHelper.WriteFile(dlg.FileName, code.Code);
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (tcCodes.TabPages == null)
            {
                ShowMessage.Alert("请先生成代码！");
                return;
            }

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (TabPage page in tcCodes.TabPages)
                {
                    Generator.Codes code = page.Tag as Generator.Codes;
                    code.Generate(dlg.SelectedPath);
                }
            }
        }

        /// <summary>
        /// 生成一个代码页
        /// </summary>
        public void AddCodeTabPage(Generator.Codes code)
        {
            TextEditor txt = new TextEditor();
            txt.Dock = DockStyle.Fill;
            txt.ShowInvalidLines = false;
            txt.SetStyleByExt(code.Ext);
            txt.Text = code.Code;

            TabPage page = new TabPage();
            page.Tag = code;
            page.Text = string.IsNullOrEmpty(code.Title) ? code.FileName : code.Title;

            page.Controls.Add(txt);
            tcCodes.TabPages.Add(page);
        }

        public void OnTemplateChanged()
        {
            selectTemplateUserControl1.LoadTemplates();
        }
    }
}
