namespace SocanCode
{
    partial class CodeToTemplateForm
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuParse = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtHtml = new SocanCode.TextEditor();
            this.txtJs = new SocanCode.TextEditor();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCut,
            this.mnuCopy,
            this.mnuParse});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // mnuCut
            // 
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Size = new System.Drawing.Size(100, 22);
            this.mnuCut.Text = "剪切";
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(100, 22);
            this.mnuCopy.Text = "复制";
            // 
            // mnuParse
            // 
            this.mnuParse.Name = "mnuParse";
            this.mnuParse.Size = new System.Drawing.Size(100, 22);
            this.mnuParse.Text = "粘贴";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtHtml);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtJs);
            this.splitContainer1.Size = new System.Drawing.Size(626, 310);
            this.splitContainer1.SplitterDistance = 156;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtHtml
            // 
            this.txtHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHtml.IsReadOnly = false;
            this.txtHtml.Location = new System.Drawing.Point(0, 0);
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(626, 156);
            this.txtHtml.TabIndex = 0;
            this.txtHtml.TextChanged += new System.EventHandler(this.txtHtml_TextChanged);
            // 
            // txtJs
            // 
            this.txtJs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJs.IsReadOnly = false;
            this.txtJs.Location = new System.Drawing.Point(0, 0);
            this.txtJs.Name = "txtJs";
            this.txtJs.Size = new System.Drawing.Size(626, 150);
            this.txtJs.TabIndex = 1;
            this.txtJs.Click += new System.EventHandler(this.txtJs_Click);
            // 
            // CodeToTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 310);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "CodeToTemplateForm";
            this.TabText = "";
            this.Text = "代码转模板";
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuParse;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private TextEditor txtHtml;
        private TextEditor txtJs;

    }
}