namespace SocanCode
{
    partial class SqlSeleteViewForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlSeleteViewForm));
            this.tabInfo = new System.Windows.Forms.TabControl();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.tabMessage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.runSql = new System.Windows.Forms.Button();
            this.txtLineEffect = new SocanCode.MyTextBox(this.components);
            this.sqlTextEditor = new SocanCode.TextEditor();
            this.tabInfo.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.tabMessage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabInfo
            // 
            this.tabInfo.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabInfo.Controls.Add(this.tabGrid);
            this.tabInfo.Controls.Add(this.tabMessage);
            this.tabInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInfo.Location = new System.Drawing.Point(0, 308);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedIndex = 0;
            this.tabInfo.Size = new System.Drawing.Size(688, 227);
            this.tabInfo.TabIndex = 3;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.dgView);
            this.tabGrid.ImageIndex = 0;
            this.tabGrid.Location = new System.Drawing.Point(4, 4);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrid.Size = new System.Drawing.Size(680, 201);
            this.tabGrid.TabIndex = 0;
            this.tabGrid.Text = "网格";
            this.tabGrid.UseVisualStyleBackColor = true;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.BackgroundColor = System.Drawing.Color.White;
            this.dgView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgView.Location = new System.Drawing.Point(3, 3);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            dataGridViewCellStyle1.NullValue = null;
            this.dgView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgView.RowTemplate.Height = 23;
            this.dgView.Size = new System.Drawing.Size(674, 195);
            this.dgView.TabIndex = 0;
            this.dgView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgView_DataBindingComplete);
            // 
            // tabMessage
            // 
            this.tabMessage.Controls.Add(this.txtLineEffect);
            this.tabMessage.ImageIndex = 1;
            this.tabMessage.Location = new System.Drawing.Point(4, 4);
            this.tabMessage.Name = "tabMessage";
            this.tabMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessage.Size = new System.Drawing.Size(680, 201);
            this.tabMessage.TabIndex = 1;
            this.tabMessage.Text = "消息";
            this.tabMessage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.runSql);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 57);
            this.panel1.TabIndex = 1;
            // 
            // runSql
            // 
            this.runSql.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.runSql.Location = new System.Drawing.Point(25, 13);
            this.runSql.Name = "runSql";
            this.runSql.Size = new System.Drawing.Size(100, 30);
            this.runSql.TabIndex = 0;
            this.runSql.Text = "执行";
            this.runSql.UseVisualStyleBackColor = true;
            this.runSql.Click += new System.EventHandler(this.runSql_Click);
            // 
            // txtLineEffect
            // 
            this.txtLineEffect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLineEffect.Location = new System.Drawing.Point(3, 3);
            this.txtLineEffect.Multiline = true;
            this.txtLineEffect.Name = "txtLineEffect";
            this.txtLineEffect.Size = new System.Drawing.Size(674, 195);
            this.txtLineEffect.TabIndex = 0;
            // 
            // sqlTextEditor
            // 
            this.sqlTextEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.sqlTextEditor.IsReadOnly = false;
            this.sqlTextEditor.Location = new System.Drawing.Point(0, 57);
            this.sqlTextEditor.Name = "sqlTextEditor";
            this.sqlTextEditor.Size = new System.Drawing.Size(688, 251);
            this.sqlTextEditor.TabIndex = 4;
            // 
            // SqlSeleteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 535);
            this.Controls.Add(this.tabInfo);
            this.Controls.Add(this.sqlTextEditor);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SqlSeleteView";
            this.TabText = "";
            this.tabInfo.ResumeLayout(false);
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.tabMessage.ResumeLayout(false);
            this.tabMessage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabInfo;
        public System.Windows.Forms.TabPage tabGrid;
        public System.Windows.Forms.DataGridView dgView;
        public System.Windows.Forms.TabPage tabMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button runSql;
        public TextEditor sqlTextEditor;
        public MyTextBox txtLineEffect;


    }
}