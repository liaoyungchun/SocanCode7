namespace DbConnections
{
    partial class AccessConn
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
            this.txtString = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNullPassword = new System.Windows.Forms.CheckBox();
            this.txtPasswrod = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radString = new System.Windows.Forms.RadioButton();
            this.radTable = new System.Windows.Forms.RadioButton();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTable.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtString
            // 
            this.txtString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtString.Enabled = false;
            this.txtString.Location = new System.Drawing.Point(0, 199);
            this.txtString.Margin = new System.Windows.Forms.Padding(4);
            this.txtString.Multiline = true;
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(568, 304);
            this.txtString.TabIndex = 2;
            // 
            // txtPath
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPath, 2);
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Location = new System.Drawing.Point(136, 4);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(388, 25);
            this.txtPath.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserName.Location = new System.Drawing.Point(136, 41);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(194, 25);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Text = "Admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 10, 4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库路径";
            // 
            // chkNullPassword
            // 
            this.chkNullPassword.AutoSize = true;
            this.chkNullPassword.Checked = true;
            this.chkNullPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNullPassword.Location = new System.Drawing.Point(338, 78);
            this.chkNullPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNullPassword.Name = "chkNullPassword";
            this.chkNullPassword.Size = new System.Drawing.Size(74, 19);
            this.chkNullPassword.TabIndex = 4;
            this.chkNullPassword.Text = "空密码";
            this.chkNullPassword.UseVisualStyleBackColor = true;
            this.chkNullPassword.CheckedChanged += new System.EventHandler(this.chkNullPassword_CheckedChanged);
            // 
            // txtPasswrod
            // 
            this.txtPasswrod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPasswrod.Enabled = false;
            this.txtPasswrod.Location = new System.Drawing.Point(136, 78);
            this.txtPasswrod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPasswrod.Name = "txtPasswrod";
            this.txtPasswrod.PasswordChar = '●';
            this.txtPasswrod.Size = new System.Drawing.Size(194, 25);
            this.txtPasswrod.TabIndex = 3;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectPath.Location = new System.Drawing.Point(532, 4);
            this.btnSelectPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(32, 29);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(30, 10, 4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(30, 10, 4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "密码";
            // 
            // radString
            // 
            this.radString.Dock = System.Windows.Forms.DockStyle.Top;
            this.radString.Location = new System.Drawing.Point(0, 158);
            this.radString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radString.Name = "radString";
            this.radString.Size = new System.Drawing.Size(568, 41);
            this.radString.TabIndex = 1;
            this.radString.Text = "直接填写数据库连接";
            this.radString.UseVisualStyleBackColor = true;
            this.radString.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // radTable
            // 
            this.radTable.Checked = true;
            this.radTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTable.Location = new System.Drawing.Point(0, 0);
            this.radTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radTable.Name = "radTable";
            this.radTable.Size = new System.Drawing.Size(568, 45);
            this.radTable.TabIndex = 0;
            this.radTable.TabStop = true;
            this.radTable.Text = "填写数据库信息";
            this.radTable.UseVisualStyleBackColor = true;
            this.radTable.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // pnlTable
            // 
            this.pnlTable.Controls.Add(this.tableLayoutPanel1);
            this.pnlTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTable.Location = new System.Drawing.Point(0, 45);
            this.pnlTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(568, 113);
            this.pnlTable.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkNullPassword, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPasswrod, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUserName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectPath, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(50, 10, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(568, 113);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // AccessConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.radString);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.radTable);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AccessConn";
            this.Size = new System.Drawing.Size(568, 503);
            this.pnlTable.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNullPassword;
        private System.Windows.Forms.TextBox txtPasswrod;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radString;
        private System.Windows.Forms.RadioButton radTable;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
