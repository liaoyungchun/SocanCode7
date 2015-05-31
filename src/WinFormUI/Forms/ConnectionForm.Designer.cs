using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using DbConnections;
using Model;

namespace SocanCode
{
    public partial class ConnectionForm : Form
    {
        private IContainer components = null;
        private Button btnConnect;
        private Button btnCancel;
        private TabControl tcDatabase;
        private TabPage tpAccess;
        private TabPage tpSqlServer;
        private AccessConn accessConn1;
        private SqlConn sqlConn1;
        private TabPage tabPage1;
        private MySqlConn mySqlConn1;
        private PictureBox pictureBox1;
        private BackgroundWorker backgroundWorker1;
        private TabPage tabPage2;
        private OracleConn oracleConn1;
        private TabPage tabPage3;
        private SQLiteConn sqLiteConn1;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private AseConn aseConn1;
        private DB2Conn dB2Conn1;
        public Database database;
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tcDatabase = new System.Windows.Forms.TabControl();
            this.tpAccess = new System.Windows.Forms.TabPage();
            this.accessConn1 = new DbConnections.AccessConn();
            this.tpSqlServer = new System.Windows.Forms.TabPage();
            this.sqlConn1 = new DbConnections.SqlConn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mySqlConn1 = new DbConnections.MySqlConn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.oracleConn1 = new DbConnections.OracleConn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.sqLiteConn1 = new DbConnections.SQLiteConn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.aseConn1 = new DbConnections.AseConn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dB2Conn1 = new DbConnections.DB2Conn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.postgreSqlConn1 = new DbConnections.PostgreSqlConn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tcDatabase.SuspendLayout();
            this.tpAccess.SuspendLayout();
            this.tpSqlServer.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(439, 465);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 29);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(543, 465);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tcDatabase
            // 
            this.tcDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcDatabase.Controls.Add(this.tpAccess);
            this.tcDatabase.Controls.Add(this.tpSqlServer);
            this.tcDatabase.Controls.Add(this.tabPage1);
            this.tcDatabase.Controls.Add(this.tabPage2);
            this.tcDatabase.Controls.Add(this.tabPage3);
            this.tcDatabase.Controls.Add(this.tabPage4);
            this.tcDatabase.Controls.Add(this.tabPage5);
            this.tcDatabase.Controls.Add(this.tabPage6);
            this.tcDatabase.Location = new System.Drawing.Point(16, 15);
            this.tcDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcDatabase.Name = "tcDatabase";
            this.tcDatabase.SelectedIndex = 0;
            this.tcDatabase.Size = new System.Drawing.Size(627, 434);
            this.tcDatabase.TabIndex = 0;
            // 
            // tpAccess
            // 
            this.tpAccess.Controls.Add(this.accessConn1);
            this.tpAccess.Location = new System.Drawing.Point(4, 25);
            this.tpAccess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpAccess.Name = "tpAccess";
            this.tpAccess.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpAccess.Size = new System.Drawing.Size(619, 405);
            this.tpAccess.TabIndex = 0;
            this.tpAccess.Text = "Access";
            this.tpAccess.UseVisualStyleBackColor = true;
            // 
            // accessConn1
            // 
            this.accessConn1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=;Persist Security Info=True;";
            this.accessConn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accessConn1.Location = new System.Drawing.Point(4, 4);
            this.accessConn1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.accessConn1.Name = "accessConn1";
            this.accessConn1.Size = new System.Drawing.Size(611, 397);
            this.accessConn1.TabIndex = 0;
            // 
            // tpSqlServer
            // 
            this.tpSqlServer.Controls.Add(this.sqlConn1);
            this.tpSqlServer.Location = new System.Drawing.Point(4, 25);
            this.tpSqlServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpSqlServer.Name = "tpSqlServer";
            this.tpSqlServer.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpSqlServer.Size = new System.Drawing.Size(619, 405);
            this.tpSqlServer.TabIndex = 1;
            this.tpSqlServer.Text = "SqlServer";
            this.tpSqlServer.UseVisualStyleBackColor = true;
            // 
            // sqlConn1
            // 
            this.sqlConn1.ConnectionString = "Data Source=.;User ID=sa;Password=;Initial Catalog=;";
            this.sqlConn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlConn1.IsSql2005 = false;
            this.sqlConn1.Location = new System.Drawing.Point(4, 4);
            this.sqlConn1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.sqlConn1.Name = "sqlConn1";
            this.sqlConn1.Size = new System.Drawing.Size(611, 397);
            this.sqlConn1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mySqlConn1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(619, 405);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "MySql";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mySqlConn1
            // 
            this.mySqlConn1.ConnectionString = "Data Source=127.0.0.1;Port=3306;User Id=root;Password=;Database=;";
            this.mySqlConn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlConn1.Location = new System.Drawing.Point(4, 4);
            this.mySqlConn1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.mySqlConn1.Name = "mySqlConn1";
            this.mySqlConn1.Size = new System.Drawing.Size(611, 397);
            this.mySqlConn1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.oracleConn1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(619, 405);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Oracle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // oracleConn1
            // 
            this.oracleConn1.ConnectionString = "Data Source=ORCL;Persist Security Info=True;User ID=SYSTEM;Password=;Unicode=True" +
    "";
            this.oracleConn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oracleConn1.Location = new System.Drawing.Point(4, 4);
            this.oracleConn1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.oracleConn1.Name = "oracleConn1";
            this.oracleConn1.Size = new System.Drawing.Size(611, 397);
            this.oracleConn1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.sqLiteConn1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(619, 405);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "SQLite";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // sqLiteConn1
            // 
            this.sqLiteConn1.ConnectionString = "Data Source=;";
            this.sqLiteConn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqLiteConn1.Location = new System.Drawing.Point(4, 4);
            this.sqLiteConn1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.sqLiteConn1.Name = "sqLiteConn1";
            this.sqLiteConn1.Size = new System.Drawing.Size(611, 397);
            this.sqLiteConn1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.aseConn1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Size = new System.Drawing.Size(619, 405);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "Sybase";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // aseConn1
            // 
            this.aseConn1.ConnectionString = "Data Source=127.0.0.1;Port=5000;User Id=sa;Password=;Database=;persist security i" +
    "nfo=true";
            this.aseConn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aseConn1.Location = new System.Drawing.Point(4, 4);
            this.aseConn1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.aseConn1.Name = "aseConn1";
            this.aseConn1.Size = new System.Drawing.Size(611, 397);
            this.aseConn1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dB2Conn1);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Size = new System.Drawing.Size(619, 405);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "IBM DB2";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dB2Conn1
            // 
            this.dB2Conn1.ConnectionString = "Database=sample;User ID=db2admin;Password=;Server=127.0.0.1;persist security info" +
    "=true";
            this.dB2Conn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dB2Conn1.Location = new System.Drawing.Point(4, 4);
            this.dB2Conn1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dB2Conn1.Name = "dB2Conn1";
            this.dB2Conn1.Size = new System.Drawing.Size(611, 397);
            this.dB2Conn1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.postgreSqlConn1);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage6.Size = new System.Drawing.Size(619, 405);
            this.tabPage6.TabIndex = 7;
            this.tabPage6.Text = "PostgreSql";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // postgreSqlConn1
            // 
            this.postgreSqlConn1.ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=;Database=postgres;Encoding=" +
    "UNICODE";
            this.postgreSqlConn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postgreSqlConn1.Location = new System.Drawing.Point(4, 4);
            this.postgreSqlConn1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.postgreSqlConn1.Name = "postgreSqlConn1";
            this.postgreSqlConn1.Size = new System.Drawing.Size(611, 397);
            this.postgreSqlConn1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::SocanCode.Properties.Resources.ajax;
            this.pictureBox1.Location = new System.Drawing.Point(0, 503);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(661, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 524);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tcDatabase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置连接";
            this.tcDatabase.ResumeLayout(false);
            this.tpAccess.ResumeLayout(false);
            this.tpSqlServer.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private TabPage tabPage6;
        private PostgreSqlConn postgreSqlConn1;
    }
}
