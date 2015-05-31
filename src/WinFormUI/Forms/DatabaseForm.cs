using System;
using System.Drawing;
using System.Windows.Forms;

namespace SocanCode
{
    public partial class DatabaseForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public event Action<Model.Database> OutputCode;
        public event Action<Model.Table> CreateCode;
        public event Action<string> ShowStatus;

        public DatabaseForm()
        {
            InitializeComponent();
        }

        private void btnAddDatabase_Click(object sender, EventArgs e)
        {
            ConnectionForm frm = new ConnectionForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Model.Database database = frm.database;
                ShowDatabase(database);
            }
        }

        private void btnRemoveDatabase_Click(object sender, EventArgs e)
        {
            TreeNode node = tvDatabase.SelectedNode;
            if (node == null) { return; }
            while (node.Level > 0)
            {
                node = node.Parent;
            }
            tvDatabase.Nodes.Remove(node);
        }

        #region 加载节点
        /// <summary>
        /// 显示第一级节点：数据库
        /// </summary>
        private void ShowDatabase(Model.Database database)
        {
            TreeNode nodeDB = new TreeNode(
                string.Format("{0}－{1}",
                    database.Name,
                    database.TypeDescn),
                0, 0);
            nodeDB.Tag = database;
            nodeDB.ContextMenuStrip = cmsDB;
            this.tvDatabase.Nodes.Add(nodeDB);

            ShowFolders(database, nodeDB);
            nodeDB.Expand();
        }

        /// <summary>
        /// 显示第二级节点：表，视图，存储过程文件夹
        /// </summary>
        private void ShowFolders(Model.Database db, TreeNode nodeRoot)
        {
            //添加“表”文件夹
            TreeNode nodeTableFolder = new TreeNode("表", 1, 1);
            nodeRoot.Nodes.Add(nodeTableFolder);

            //添加表
            ShowTables(db, nodeTableFolder);
            nodeTableFolder.Expand();

            //添加“视图”文件夹
            TreeNode nodeViewFolder = new TreeNode("视图", 1, 1);
            nodeRoot.Nodes.Add(nodeViewFolder);

            //添加视图
            ShowViews(db, nodeViewFolder);

            //添加“存储过程”文件夹
            TreeNode nodeStoreProceduresFolder = new TreeNode("存储过程", 1, 1);
            nodeRoot.Nodes.Add(nodeStoreProceduresFolder);

            //添加存储过程
            ShowStoreProcedures(db, nodeStoreProceduresFolder);
        }

        /// <summary>
        /// 显示第三级节点：表
        /// </summary>
        private void ShowTables(Model.Database database, TreeNode nodeRoot)
        {
            foreach (Model.Table table in database.Tables)
            {
                TreeNode nodeTable = new TreeNode(table.Name, 2, 2);
                nodeTable.Tag = table;
                nodeTable.ContextMenuStrip = cmsTable;
                nodeRoot.Nodes.Add(nodeTable);

                ShowFields(table, nodeTable);
            }
        }

        /// <summary>
        /// 显示第三级节点：视图
        /// </summary>
        private void ShowViews(Model.Database database, TreeNode nodeRoot)
        {
            foreach (Model.Table table in database.Views)
            {
                TreeNode nodeTable = new TreeNode(table.Name, 2, 2);
                nodeTable.Tag = table;
                nodeTable.ContextMenuStrip = cmsView;
                nodeRoot.Nodes.Add(nodeTable);

                ShowFields(table, nodeTable);
            }
        }

        /// <summary>
        /// 显示第三级节点：存储过程
        /// </summary>
        private static void ShowStoreProcedures(Model.Database db, TreeNode nodeRoot)
        {
            foreach (string storeProcedure in db.StoreProcedures)
            {
                nodeRoot.Nodes.Add(new TreeNode(storeProcedure, 5, 5));
            }
        }

        /// <summary>
        /// 显示第四级节点：字段
        /// </summary>
        private void ShowFields(Model.Table table, TreeNode nodeRoot)
        {
            foreach (Model.Field field in table.Fields)
            {
                string text = string.Format("{0}:{1}{2}{3}", field.Name, field.FieldType,
                    field.IsId ? "[Id]" : "", field.IsKey ? "[key]" : "");
                TreeNode nodeField = new TreeNode(text, 3, 3);
                nodeRoot.Nodes.Add(nodeField);

                //TreeNode nodeField = new TreeNode(field.Name, 3, 3);
                //nodeRoot.Nodes.Add(nodeField);
            }
        }
        #endregion

        #region 右键
        private void menuSelect_Click(object sender, EventArgs e)
        {
            if (CreateCode != null)
            {
                string dbName = tvDatabase.SelectedNode.Parent.Parent.Text;
                Model.Database db = tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database;
                Model.Table table = tvDatabase.SelectedNode.Tag as Model.Table;
                if (table != null)
                {
                    SqlSeleteViewForm ssv = new SqlSeleteViewForm(db, table);
                    if ((ssv.sqlTextEditor.Text.Trim().Length != 0) && (ssv.sqlTextEditor.Text[ssv.sqlTextEditor.Text.Length - 1] != '\n'))
                    {
                        ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + "\n";
                    }
                    ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + "select * from " + this.tvDatabase.SelectedNode.Text + "";
                    ssv.Show(MainForm.dockPanel);
                }
                else
                {
                    ShowMessage.Alert("请先选中一个表或视图。");
                }
            }
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            if (CreateCode != null)
            {
                string dbName = tvDatabase.SelectedNode.Parent.Parent.Text;
                Model.Database db = tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database;
                Model.Table table = tvDatabase.SelectedNode.Tag as Model.Table;
                if (table != null)
                {
                    SqlSeleteViewForm ssv = new SqlSeleteViewForm(db, table);
                    string str = "\nwhere 1 = 1";
                    string str2 = "update ";
                    str2 = ((str2 + "" + this.tvDatabase.SelectedNode.Text + "") + " \nset ") + this.tvDatabase.SelectedNode.Nodes[0].Text + " = ''";
                    for (int i = 1; i < this.tvDatabase.SelectedNode.Nodes.Count; i++)
                    {
                        str2 = (str2 + ",") + this.tvDatabase.SelectedNode.Nodes[i].Text + "=''";
                    }
                    if ((ssv.sqlTextEditor.Text.Trim().Length != 0) && (ssv.sqlTextEditor.Text[ssv.sqlTextEditor.Text.Length - 1] != '\n'))
                    {
                        ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + "\n";
                    }
                    ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + str2;
                    ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + str;
                    ssv.Show(MainForm.dockPanel);
                }
                else
                {
                    ShowMessage.Alert("请先选中一个表或视图。");
                }
            }
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            if (CreateCode != null)
            {
                string dbName = tvDatabase.SelectedNode.Parent.Parent.Text;
                Model.Database db = tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database;
                Model.Table table = tvDatabase.SelectedNode.Tag as Model.Table;
                if (table != null)
                {
                    SqlSeleteViewForm ssv = new SqlSeleteViewForm(db, table);
                    string str = "\nwhere 1 = 1";
                    string str2 = "delete from ";
                    str2 = (str2 + "" + this.tvDatabase.SelectedNode.Text + "") + str;
                    if ((ssv.sqlTextEditor.Text.Trim().Length != 0) && (ssv.sqlTextEditor.Text[ssv.sqlTextEditor.Text.Length - 1] != '\n'))
                    {
                        ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + "\n";
                    }
                    ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + str2;
                    ssv.Show(MainForm.dockPanel);
                }
                else
                {
                    ShowMessage.Alert("请先选中一个表或视图。");
                }
            }
        }

        private void menuInsert_Click(object sender, EventArgs e)
        {
            if (CreateCode != null)
            {
                string dbName = tvDatabase.SelectedNode.Parent.Parent.Text;
                Model.Database db = tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database;
                Model.Table table = tvDatabase.SelectedNode.Tag as Model.Table;
                if (table != null)
                {
                    SqlSeleteViewForm ssv = new SqlSeleteViewForm(db, table);
                    string str = "";
                    string str2 = "insert into ";
                    str2 = (str2 + "" + this.tvDatabase.SelectedNode.Text + "") + " (" + this.tvDatabase.SelectedNode.Nodes[0].Text;
                    for (int i = 1; i < this.tvDatabase.SelectedNode.Nodes.Count; i++)
                    {
                        str = str + ",''";
                        str2 = str2 + "," + this.tvDatabase.SelectedNode.Nodes[i].Text;
                    }
                    str2 = (str2 + ") \n" + "values(''") + str + ")";
                    if ((ssv.sqlTextEditor.Text.Trim().Length != 0) && (ssv.sqlTextEditor.Text[ssv.sqlTextEditor.Text.Length - 1] != '\n'))
                    {
                        ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + "\n";
                    }
                    ssv.sqlTextEditor.Text = ssv.sqlTextEditor.Text + str2;
                    ssv.Show(MainForm.dockPanel);
                }
                else
                {
                    ShowMessage.Alert("请先选中一个表或视图。");
                }
            }
        }

        private void menuOutput_Click(object sender, EventArgs e)
        {
            OutputSelectedDatabaseCode();
        }

        private void menuCreateCode_Click(object sender, EventArgs e)
        {
            CreateCurrentTableCode();
        }

        private void menuDeleteDatabase_Click(object sender, EventArgs e)
        {
            tvDatabase.Nodes.Remove(tvDatabase.SelectedNode);
        }
        #endregion

        /// <summary>
        /// 对选中的库进行输出代码操作
        /// </summary>
        public void OutputSelectedDatabaseCode()
        {
            if (OutputCode != null)
            {
                Model.Database database = tvDatabase.SelectedNode.Tag as Model.Database;
                if (database != null)
                {
                    OutputCode(database);
                }
                else
                {
                    ShowMessage.Alert("请先选中一个数据库。");
                }
            }
        }

        /// <summary>
        /// 对选中的表进行生成代码操作
        /// </summary>
        public void CreateCurrentTableCode()
        {
            if (CreateCode != null)
            {
                Model.Table table = tvDatabase.SelectedNode.Tag as Model.Table;
                if (table != null)
                {
                    CreateCode(table);
                }
                else
                {
                    ShowMessage.Alert("请先选中一个表或视图。");
                }
            }
        }

        private void tvDatabase_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode tn = GetMouseNode(tvDatabase, this);
            if (tn != null)
            {
                tvDatabase.SelectedNode = tn;
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
    }
}