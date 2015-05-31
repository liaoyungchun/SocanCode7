namespace SocanCode
{
    partial class DatabaseForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddDatabase = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveDatabase = new System.Windows.Forms.ToolStripButton();
            this.tvDatabase = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCreateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.cmsDB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCreateCode1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelect1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdate1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInsert1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.cmsTable.SuspendLayout();
            this.cmsDB.SuspendLayout();
            this.cmsView.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDatabase,
            this.btnRemoveDatabase});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(210, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddDatabase
            // 
            this.btnAddDatabase.Image = global::SocanCode.Properties.Resources.add;
            this.btnAddDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDatabase.Name = "btnAddDatabase";
            this.btnAddDatabase.Size = new System.Drawing.Size(85, 22);
            this.btnAddDatabase.Text = "添加数据库";
            this.btnAddDatabase.Click += new System.EventHandler(this.btnAddDatabase_Click);
            // 
            // btnRemoveDatabase
            // 
            this.btnRemoveDatabase.Image = global::SocanCode.Properties.Resources.delete;
            this.btnRemoveDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveDatabase.Name = "btnRemoveDatabase";
            this.btnRemoveDatabase.Size = new System.Drawing.Size(85, 22);
            this.btnRemoveDatabase.Text = "移除数据库";
            this.btnRemoveDatabase.Click += new System.EventHandler(this.btnRemoveDatabase_Click);
            // 
            // tvDatabase
            // 
            this.tvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDatabase.ImageIndex = 0;
            this.tvDatabase.ImageList = this.imageList1;
            this.tvDatabase.Location = new System.Drawing.Point(0, 25);
            this.tvDatabase.Name = "tvDatabase";
            this.tvDatabase.SelectedImageIndex = 0;
            this.tvDatabase.Size = new System.Drawing.Size(210, 341);
            this.tvDatabase.TabIndex = 1;
            this.tvDatabase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvDatabase_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "db.gif");
            this.imageList1.Images.SetKeyName(1, "folder.gif");
            this.imageList1.Images.SetKeyName(2, "table.gif");
            this.imageList1.Images.SetKeyName(3, "field.gif");
            this.imageList1.Images.SetKeyName(4, "view.gif");
            this.imageList1.Images.SetKeyName(5, "sp.gif");
            this.imageList1.Images.SetKeyName(6, "parameter.gif");
            // 
            // cmsTable
            // 
            this.cmsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreateCode,
            this.menuSelect,
            this.menuUpdate,
            this.menuDelete,
            this.menuInsert});
            this.cmsTable.Name = "contextMenuStrip1";
            this.cmsTable.Size = new System.Drawing.Size(153, 136);
            // 
            // menuCreateCode
            // 
            this.menuCreateCode.Name = "menuCreateCode";
            this.menuCreateCode.Size = new System.Drawing.Size(118, 22);
            this.menuCreateCode.Text = "生成代码";
            this.menuCreateCode.Click += new System.EventHandler(this.menuCreateCode_Click);
            // 
            // menuSelect
            // 
            this.menuSelect.Name = "menuSelect";
            this.menuSelect.Size = new System.Drawing.Size(118, 22);
            this.menuSelect.Text = "查询记录";
            this.menuSelect.Click += new System.EventHandler(this.menuSelect_Click);
            // 
            // menuUpdate
            // 
            this.menuUpdate.Name = "menuUpdate";
            this.menuUpdate.Size = new System.Drawing.Size(152, 22);
            this.menuUpdate.Text = "修改记录";
            this.menuUpdate.Click += new System.EventHandler(this.menuUpdate_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(152, 22);
            this.menuDelete.Text = "删除记录";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuInsert
            // 
            this.menuInsert.Name = "menuInsert";
            this.menuInsert.Size = new System.Drawing.Size(152, 22);
            this.menuInsert.Text = "增加记录";
            this.menuInsert.Click += new System.EventHandler(this.menuInsert_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // cmsDB
            // 
            this.cmsDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOutput,
            this.menuDeleteDatabase});
            this.cmsDB.Name = "cmsDB";
            this.cmsDB.Size = new System.Drawing.Size(119, 48);
            // 
            // menuOutput
            // 
            this.menuOutput.Name = "menuOutput";
            this.menuOutput.Size = new System.Drawing.Size(118, 22);
            this.menuOutput.Text = "输出代码";
            this.menuOutput.Click += new System.EventHandler(this.menuOutput_Click);
            // 
            // menuDeleteDatabase
            // 
            this.menuDeleteDatabase.Name = "menuDeleteDatabase";
            this.menuDeleteDatabase.Size = new System.Drawing.Size(118, 22);
            this.menuDeleteDatabase.Text = "删除";
            this.menuDeleteDatabase.Click += new System.EventHandler(this.menuDeleteDatabase_Click);
            // 
            // cmsView
            // 
            this.cmsView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreateCode1,
            this.menuSelect1,
            this.menuUpdate1,
            this.menuDelete1,
            this.menuInsert1});
            this.cmsView.Name = "cmsView";
            this.cmsView.Size = new System.Drawing.Size(153, 136);
            // 
            // menuCreateCode1
            // 
            this.menuCreateCode1.Name = "menuCreateCode1";
            this.menuCreateCode1.Size = new System.Drawing.Size(152, 22);
            this.menuCreateCode1.Text = "生成代码";
            this.menuCreateCode1.Click += new System.EventHandler(this.menuCreateCode_Click);
            // 
            // menuSelect1
            // 
            this.menuSelect1.Name = "menuSelect1";
            this.menuSelect1.Size = new System.Drawing.Size(152, 22);
            this.menuSelect1.Text = "查询记录";
            this.menuSelect1.Click += new System.EventHandler(this.menuSelect_Click);
            // 
            // menuUpdate1
            // 
            this.menuUpdate1.Name = "menuUpdate1";
            this.menuUpdate1.Size = new System.Drawing.Size(152, 22);
            this.menuUpdate1.Text = "修改记录";
            this.menuUpdate1.Click += new System.EventHandler(this.menuUpdate_Click);
            // 
            // menuDelete1
            // 
            this.menuDelete1.Name = "menuDelete1";
            this.menuDelete1.Size = new System.Drawing.Size(152, 22);
            this.menuDelete1.Text = "删除记录";
            this.menuDelete1.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuInsert1
            // 
            this.menuInsert1.Name = "menuInsert1";
            this.menuInsert1.Size = new System.Drawing.Size(152, 22);
            this.menuInsert1.Text = "增加记录";
            this.menuInsert1.Click += new System.EventHandler(this.menuInsert_Click);
            // 
            // DatabaseForm
            // 
            this.AutoHidePortion = 0.2D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 366);
            this.Controls.Add(this.tvDatabase);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "数据库";
            this.Text = "数据库";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsTable.ResumeLayout(false);
            this.cmsDB.ResumeLayout(false);
            this.cmsView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddDatabase;
        private System.Windows.Forms.ContextMenuStrip cmsTable;
        private System.Windows.Forms.ToolStripMenuItem menuCreateCode;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.TreeView tvDatabase;
        private System.Windows.Forms.ContextMenuStrip cmsDB;
        private System.Windows.Forms.ToolStripMenuItem menuOutput;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteDatabase;
        private System.Windows.Forms.ContextMenuStrip cmsView;
        private System.Windows.Forms.ToolStripMenuItem menuCreateCode1;
        private System.Windows.Forms.ToolStripButton btnRemoveDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuSelect;
        private System.Windows.Forms.ToolStripMenuItem menuUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuInsert;
        private System.Windows.Forms.ToolStripMenuItem menuSelect1;
        private System.Windows.Forms.ToolStripMenuItem menuUpdate1;
        private System.Windows.Forms.ToolStripMenuItem menuDelete1;
        private System.Windows.Forms.ToolStripMenuItem menuInsert1;

    }
}