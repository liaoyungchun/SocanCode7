namespace SocanCode
{
    partial class TemplateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateForm));
            this.tvTemplates = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddJSFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddXmlFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTemplates
            // 
            this.tvTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTemplates.ImageIndex = 0;
            this.tvTemplates.ImageList = this.imageList1;
            this.tvTemplates.Location = new System.Drawing.Point(0, 0);
            this.tvTemplates.Name = "tvTemplates";
            this.tvTemplates.SelectedImageIndex = 0;
            this.tvTemplates.Size = new System.Drawing.Size(310, 437);
            this.tvTemplates.TabIndex = 0;
            this.tvTemplates.DoubleClick += new System.EventHandler(this.tvTemplates_DoubleClick);
            this.tvTemplates.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTemplates_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "root.png");
            this.imageList1.Images.SetKeyName(1, "template.png");
            this.imageList1.Images.SetKeyName(2, "js.png");
            this.imageList1.Images.SetKeyName(3, "xml.png");
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddTemplate,
            this.mnuAddJSFile,
            this.mnuAddXmlFile,
            this.mnuEdit,
            this.mnuDelete,
            this.mnuRefresh,
            this.mnuOpenFolder});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(201, 180);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnuAddJSFile
            // 
            this.mnuAddJSFile.Image = global::SocanCode.Properties.Resources.js;
            this.mnuAddJSFile.Name = "mnuAddJSFile";
            this.mnuAddJSFile.Size = new System.Drawing.Size(200, 22);
            this.mnuAddJSFile.Text = "添加模板文件（*.js）";
            this.mnuAddJSFile.Click += new System.EventHandler(this.mnuAddJSFile_Click);
            // 
            // mnuAddTemplate
            // 
            this.mnuAddTemplate.Image = global::SocanCode.Properties.Resources.template;
            this.mnuAddTemplate.Name = "mnuAddTemplate";
            this.mnuAddTemplate.Size = new System.Drawing.Size(200, 22);
            this.mnuAddTemplate.Text = "添加模板";
            this.mnuAddTemplate.Click += new System.EventHandler(this.mnuAddTemplate_Click);
            // 
            // mnuAddXmlFile
            // 
            this.mnuAddXmlFile.Image = global::SocanCode.Properties.Resources.xml;
            this.mnuAddXmlFile.Name = "mnuAddXmlFile";
            this.mnuAddXmlFile.Size = new System.Drawing.Size(200, 22);
            this.mnuAddXmlFile.Text = "添加设置文件（*.xml）";
            this.mnuAddXmlFile.Click += new System.EventHandler(this.mnuAddXmlFile_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::SocanCode.Properties.Resources.delete;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(200, 22);
            this.mnuDelete.Text = "删除";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::SocanCode.Properties.Resources.edit;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(200, 22);
            this.mnuEdit.Text = "编辑";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuOpenFolder
            // 
            this.mnuOpenFolder.Image = global::SocanCode.Properties.Resources.open;
            this.mnuOpenFolder.Name = "mnuOpenFolder";
            this.mnuOpenFolder.Size = new System.Drawing.Size(200, 22);
            this.mnuOpenFolder.Text = "打开文件夹";
            this.mnuOpenFolder.Click += new System.EventHandler(this.mnuOpenFolder_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = global::SocanCode.Properties.Resources.refresh;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(200, 22);
            this.mnuRefresh.Text = "刷新";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 437);
            this.Controls.Add(this.tvTemplates);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemplateForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "模板";
            this.Text = "模板";
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvTemplates;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem mnuAddTemplate;
        private System.Windows.Forms.ToolStripMenuItem mnuAddJSFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuAddXmlFile;
        private System.Windows.Forms.ImageList imageList1;




    }
}