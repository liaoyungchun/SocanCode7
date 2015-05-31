using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace SocanCode
{
    public partial class TemplateForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public event Action TemplateChanged;

        TreeNode rootNode;

        public TemplateForm()
        {
            InitializeComponent();

            LoadRoot();
        }

        private void LoadRoot()
        {
            rootNode = new TreeNode("所有模板");
            string templatePath = Application.StartupPath + "\\templates";
            DirectoryInfo templateFolder = new DirectoryInfo(templatePath);
            rootNode.Tag = templateFolder;
            rootNode.ContextMenuStrip = cms;
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 0;
            tvTemplates.Nodes.Add(rootNode);
            LoadTempates();
            rootNode.Expand();
        }

        private void LoadTempates()
        {
            rootNode.Nodes.Clear();
            DirectoryInfo rootFolder = rootNode.Tag as DirectoryInfo;
            foreach (DirectoryInfo dir in rootFolder.GetDirectories())
            {
                TreeNode node = new TreeNode(dir.Name);
                node.Tag = dir;
                node.ContextMenuStrip = cms;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                rootNode.Nodes.Add(node);
                LoadFiles(node);
            }
        }

        private void LoadFiles(TreeNode templateNode)
        {
            templateNode.Nodes.Clear();
            DirectoryInfo templateDir = templateNode.Tag as DirectoryInfo;
            foreach (FileInfo fi in templateDir.GetFiles())
            {
                TreeNode node = new TreeNode(fi.Name);
                node.Tag = fi;
                node.ContextMenuStrip = cms;
                if (fi.Extension.ToLower().Contains("js"))
                {
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                }
                else
                {
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                }
                templateNode.Nodes.Add(node);
            }
        }

        private void tvTemplates_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode tn = GetMouseNode(tvTemplates, this);
            if (tn != null)
            {
                tvTemplates.SelectedNode = tn;
            }
        }

        /// <summary>
        /// 得到TreeView里鼠标指向的节点,同时把该节点设置为当前选中的节点
        /// </summary>
        private TreeNode GetMouseNode(TreeView tv, Control currentForm)
        {
            Point pt = currentForm.PointToScreen(tv.Location);
            Point p = new Point(Control.MousePosition.X - pt.X, Control.MousePosition.Y - pt.Y);
            TreeNode tn = tv.GetNodeAt(p);
            return tn;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mnuAddJSFile.Visible = false;
            mnuAddXmlFile.Visible = false;
            mnuAddTemplate.Visible = false;
            mnuDelete.Visible = false;
            mnuEdit.Visible = false;
            mnuRefresh.Visible = false;
            mnuOpenFolder.Visible = false;

            switch (tvTemplates.SelectedNode.Level)
            {
                case 0:
                    mnuAddTemplate.Visible = true;
                    mnuRefresh.Visible = true;
                    mnuOpenFolder.Visible = true;
                    break;
                case 1:
                    mnuAddJSFile.Visible = true;
                    mnuAddXmlFile.Visible = true;
                    mnuDelete.Visible = true;
                    mnuRefresh.Visible = true;
                    mnuOpenFolder.Visible = true;
                    break;
                default:
                    mnuDelete.Visible = true;
                    mnuEdit.Visible = true;
                    break;
            }
        }

        private void mnuAddTemplate_Click(object sender, EventArgs e)
        {
            InputForm frm = new InputForm();
            frm.Title = "请输入模板名称";
            frm.Value = "新模板";
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(frm.Value))
                {
                    ShowMessage.Alert("模板名称不能为空。");
                    frm.ShowDialog();
                    return;
                }

                DirectoryInfo rootFolder = rootNode.Tag as DirectoryInfo;
                string path = rootFolder.FullName + "\\" + frm.Value;
                if (Directory.Exists(path))
                {
                    ShowMessage.Alert("模板已存在。");
                    frm.ShowDialog();
                    return;
                }

                Generator.IOHelper.CopyFolder(Application.StartupPath + "\\Config\\NewTemplate", path);
                LoadTempates();
                if (TemplateChanged != null)
                    TemplateChanged();
            }
        }

        private void mnuAddJSFile_Click(object sender, EventArgs e)
        {
            AddFile("js");
        }

        private void mnuAddXmlFile_Click(object sender, EventArgs e)
        {
            AddFile("xml");
        }

        private void AddFile(string ext)
        {
            InputForm frm = new InputForm();
            frm.Title = string.Format("请输入文件名称 (.{0})", ext);
            frm.Value = "test";
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(frm.Value))
                {
                    ShowMessage.Alert("文件名称不能为空。");
                    frm.ShowDialog();
                    return;
                }

                DirectoryInfo rootFolder = tvTemplates.SelectedNode.Tag as DirectoryInfo;
                string path = string.Format("{0}\\{1}.{2}", rootFolder.FullName, frm.Value, ext);
                if (File.Exists(path))
                {
                    ShowMessage.Alert("文件已存在。");
                    frm.ShowDialog();
                    return;
                }

                Generator.IOHelper.WriteFile(path, "");
                LoadFiles(tvTemplates.SelectedNode);
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            FileInfo fi = tvTemplates.SelectedNode.Tag as FileInfo;
            MainForm.OpenFile(fi);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            object obj = tvTemplates.SelectedNode.Tag;
            switch (tvTemplates.SelectedNode.Level)
            {
                case 1:
                    if (ShowMessage.Confirm("确定要删除此模板吗？") == false)
                        return;
                    DirectoryInfo dir = obj as DirectoryInfo;
                    Directory.Delete(dir.FullName, true);
                    LoadTempates();
                    if (TemplateChanged != null)
                        TemplateChanged();
                    break;
                case 2:
                    if (ShowMessage.Confirm("确定要删除此文件吗？") == false)
                        return;
                    TreeNode parent = tvTemplates.SelectedNode.Parent;
                    FileInfo fi = obj as FileInfo;
                    File.Delete(fi.FullName);
                    LoadFiles(parent);
                    break;
                default:
                    break;
            }
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            switch (tvTemplates.SelectedNode.Level)
            {
                case 0:
                    LoadTempates();
                    break;
                case 1:
                    LoadFiles(tvTemplates.SelectedNode);
                    break;
                default:
                    break;
            }
        }

        private void mnuOpenFolder_Click(object sender, EventArgs e)
        {
            object tag = tvTemplates.SelectedNode.Tag;
            if (tag is DirectoryInfo)
            {
                DirectoryInfo dir = tag as DirectoryInfo;
                Process.Start(dir.FullName);
            }
        }

        private void tvTemplates_DoubleClick(object sender, EventArgs e)
        {
            switch (tvTemplates.SelectedNode.Level)
            {
                case 2:
                    FileInfo fi = tvTemplates.SelectedNode.Tag as FileInfo;
                    MainForm.OpenFile(fi);
                    break;
                default:
                    break;
            }
        }
    }
}