namespace SocanCode
{
    partial class SelectTableUserControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstSelectedTables = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectedAll = new System.Windows.Forms.Button();
            this.btnSelected = new System.Windows.Forms.Button();
            this.btnUnSelected = new System.Windows.Forms.Button();
            this.btnUnSelectedAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 472);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstSelectedTables);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(317, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 466);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "要输出代码的表";
            // 
            // lstSelectedTables
            // 
            this.lstSelectedTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelectedTables.FormattingEnabled = true;
            this.lstSelectedTables.ItemHeight = 12;
            this.lstSelectedTables.Location = new System.Drawing.Point(3, 17);
            this.lstSelectedTables.Name = "lstSelectedTables";
            this.lstSelectedTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectedTables.Size = new System.Drawing.Size(252, 436);
            this.lstSelectedTables.TabIndex = 0;
            this.lstSelectedTables.DoubleClick += new System.EventHandler(this.btnUnSelected_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTables);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 466);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库中的表";
            // 
            // lstTables
            // 
            this.lstTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTables.FormattingEnabled = true;
            this.lstTables.ItemHeight = 12;
            this.lstTables.Location = new System.Drawing.Point(3, 17);
            this.lstTables.Name = "lstTables";
            this.lstTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTables.Size = new System.Drawing.Size(252, 436);
            this.lstTables.TabIndex = 0;
            this.lstTables.DoubleClick += new System.EventHandler(this.btnSelected_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnSelectedAll, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSelected, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnUnSelected, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnUnSelectedAll, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(267, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(44, 466);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSelectedAll
            // 
            this.btnSelectedAll.Location = new System.Drawing.Point(3, 186);
            this.btnSelectedAll.Name = "btnSelectedAll";
            this.btnSelectedAll.Size = new System.Drawing.Size(38, 44);
            this.btnSelectedAll.TabIndex = 1;
            this.btnSelectedAll.Text = ">>";
            this.btnSelectedAll.UseVisualStyleBackColor = true;
            this.btnSelectedAll.Click += new System.EventHandler(this.btnSelectedAll_Click);
            // 
            // btnSelected
            // 
            this.btnSelected.Location = new System.Drawing.Point(3, 136);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(38, 44);
            this.btnSelected.TabIndex = 0;
            this.btnSelected.Text = ">";
            this.btnSelected.UseVisualStyleBackColor = true;
            this.btnSelected.Click += new System.EventHandler(this.btnSelected_Click);
            // 
            // btnUnSelected
            // 
            this.btnUnSelected.Location = new System.Drawing.Point(3, 236);
            this.btnUnSelected.Name = "btnUnSelected";
            this.btnUnSelected.Size = new System.Drawing.Size(38, 44);
            this.btnUnSelected.TabIndex = 2;
            this.btnUnSelected.Text = "<";
            this.btnUnSelected.UseVisualStyleBackColor = true;
            this.btnUnSelected.Click += new System.EventHandler(this.btnUnSelected_Click);
            // 
            // btnUnSelectedAll
            // 
            this.btnUnSelectedAll.Location = new System.Drawing.Point(3, 286);
            this.btnUnSelectedAll.Name = "btnUnSelectedAll";
            this.btnUnSelectedAll.Size = new System.Drawing.Size(38, 44);
            this.btnUnSelectedAll.TabIndex = 3;
            this.btnUnSelectedAll.Text = "<<";
            this.btnUnSelectedAll.UseVisualStyleBackColor = true;
            this.btnUnSelectedAll.Click += new System.EventHandler(this.btnUnSelectedAll_Click);
            // 
            // SelectTableUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SelectTableUserControl";
            this.Size = new System.Drawing.Size(578, 472);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstSelectedTables;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSelectedAll;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.Button btnUnSelected;
        private System.Windows.Forms.Button btnUnSelectedAll;
    }
}
