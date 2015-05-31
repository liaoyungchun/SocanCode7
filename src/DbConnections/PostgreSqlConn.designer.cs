namespace DbConnections
{
    partial class PostgreSqlConn
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.用户名 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtString = new System.Windows.Forms.TextBox();
            this.radString = new System.Windows.Forms.RadioButton();
            this.radTable = new System.Windows.Forms.RadioButton();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTable.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(22, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器";
            // 
            // txtServer
            // 
            this.txtServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServer.Location = new System.Drawing.Point(83, 3);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(159, 21);
            this.txtServer.TabIndex = 0;
            this.txtServer.Text = "127.0.0.1";
            // 
            // 用户名
            // 
            this.用户名.AutoSize = true;
            this.用户名.Location = new System.Drawing.Point(22, 33);
            this.用户名.Margin = new System.Windows.Forms.Padding(22, 6, 3, 0);
            this.用户名.Name = "用户名";
            this.用户名.Size = new System.Drawing.Size(41, 12);
            this.用户名.TabIndex = 0;
            this.用户名.Text = "用户名";
            // 
            // txtUserName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtUserName, 3);
            this.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserName.Location = new System.Drawing.Point(83, 30);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(311, 21);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Text = "postgres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(22, 6, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "密码";
            // 
            // txtPassword
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPassword, 3);
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(83, 57);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(311, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(22, 6, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据库";
            // 
            // txtString
            // 
            this.txtString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtString.Enabled = false;
            this.txtString.Location = new System.Drawing.Point(0, 173);
            this.txtString.Multiline = true;
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(397, 185);
            this.txtString.TabIndex = 3;
            // 
            // radString
            // 
            this.radString.Dock = System.Windows.Forms.DockStyle.Top;
            this.radString.Location = new System.Drawing.Point(0, 141);
            this.radString.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.radString.Name = "radString";
            this.radString.Size = new System.Drawing.Size(397, 32);
            this.radString.TabIndex = 2;
            this.radString.Text = "直接填写数据库连接";
            this.radString.UseVisualStyleBackColor = true;
            this.radString.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // radTable
            // 
            this.radTable.Checked = true;
            this.radTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTable.Location = new System.Drawing.Point(0, 0);
            this.radTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.radTable.Name = "radTable";
            this.radTable.Size = new System.Drawing.Size(397, 31);
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
            this.pnlTable.Location = new System.Drawing.Point(0, 31);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(397, 110);
            this.pnlTable.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDatabase, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUserName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPort, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.用户名, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(397, 110);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txtDatabase
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDatabase, 3);
            this.txtDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatabase.Location = new System.Drawing.Point(83, 84);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(311, 21);
            this.txtDatabase.TabIndex = 4;
            // 
            // txtPort
            // 
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.Location = new System.Drawing.Point(321, 3);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(73, 21);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "5432";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(22, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口";
            // 
            // PostgreSqlConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.radString);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.radTable);
            this.Name = "PostgreSqlConn";
            this.Size = new System.Drawing.Size(397, 358);
            this.pnlTable.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label 用户名;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.RadioButton radString;
        private System.Windows.Forms.RadioButton radTable;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
