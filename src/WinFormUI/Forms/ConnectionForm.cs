using DbConnections;
using Fabrics;
using Model;
using SocanCode.Config;
using SocanCode.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SocanCode
{
	public partial class ConnectionForm : Form
	{
		public ConnectionForm()
		{
			this.InitializeComponent();
			this.LoadConnectionFromFile();
		}

		private Schema GetSchema()
		{
			Schema schema;
			switch (this.tcDatabase.SelectedIndex)
			{
			case 0:
				schema = new Schema(this.accessConn1.ConnectionString, DatabaseTypes.Access);
				return schema;
			case 2:
				schema = new Schema(this.mySqlConn1.ConnectionString, DatabaseTypes.MySql);
				return schema;
			case 3:
				schema = new Schema(this.oracleConn1.ConnectionString, DatabaseTypes.Oracle);
				return schema;
			case 4:
				schema = new Schema(this.sqLiteConn1.ConnectionString, DatabaseTypes.SQLite);
				return schema;
            case 5:
                schema = new Schema(this.aseConn1.ConnectionString, DatabaseTypes.Ase);
                return schema;
            case 6:
                schema = new Schema(this.dB2Conn1.ConnectionString, DatabaseTypes.DB2);
                return schema;
            case 7:
                schema = new Schema(this.postgreSqlConn1.ConnectionString, DatabaseTypes.PostgreSql);
                return schema;
			}
			schema = new Schema();
			schema.ConnectionString = this.sqlConn1.ConnectionString;
			if (this.sqlConn1.IsSql2005)
			{
				schema.Type = DatabaseTypes.Sql2005;
			}
			else
			{
				schema.Type = DatabaseTypes.Sql2000;
			}
			return schema;
		}
		private void LoadConnectionFromFile()
		{
			try
			{
				History history = History.Load();
				if (!string.IsNullOrEmpty(history.AccessConn))
				{
					this.accessConn1.ConnectionString = history.AccessConn;
				}
				if (!string.IsNullOrEmpty(history.SqlServerConn))
				{
					this.sqlConn1.ConnectionString = history.SqlServerConn;
					this.sqlConn1.IsSql2005 = (history.DatabaseType == DatabaseTypes.Sql2005);
				}
				if (!string.IsNullOrEmpty(history.MySqlConn))
				{
					this.mySqlConn1.ConnectionString = history.MySqlConn;
				}
				if (!string.IsNullOrEmpty(history.OracleConn))
				{
					this.oracleConn1.ConnectionString = history.OracleConn;
				}
				if (!string.IsNullOrEmpty(history.SQLiteConn))
				{
					this.sqLiteConn1.ConnectionString = history.SQLiteConn;
				}
                if (!string.IsNullOrEmpty(history.AseConn))
                {
                    this.aseConn1.ConnectionString = history.AseConn;
                }
                if (!string.IsNullOrEmpty(history.DB2Conn))
                {
                    this.dB2Conn1.ConnectionString = history.DB2Conn;
                }
                if (!string.IsNullOrEmpty(history.PostgreSqlConn))
                {
                    this.postgreSqlConn1.ConnectionString = history.PostgreSqlConn;
                }
				switch (history.DatabaseType)
				{
				case DatabaseTypes.Access:
					this.tcDatabase.SelectedIndex = 0;
					goto IL_13E;
				case DatabaseTypes.MySql:
					this.tcDatabase.SelectedIndex = 2;
					goto IL_13E;
				case DatabaseTypes.Oracle:
					this.tcDatabase.SelectedIndex = 3;
					goto IL_13E;
				case DatabaseTypes.SQLite:
					this.tcDatabase.SelectedIndex = 4;
					goto IL_13E;
                case DatabaseTypes.Ase:
                    this.tcDatabase.SelectedIndex = 5;
                    goto IL_13E;
                case DatabaseTypes.DB2:
                    this.tcDatabase.SelectedIndex = 6;
                    goto IL_13E;
                case DatabaseTypes.PostgreSql:
                    this.tcDatabase.SelectedIndex = 7;
                    goto IL_13E;
				}
				this.tcDatabase.SelectedIndex = 1;
				IL_13E:;
			}
			catch
			{
			}
		}
		private void SaveConnectionToFile()
		{
			History history = History.Load();
			switch (this.tcDatabase.SelectedIndex)
			{
			case 0:
				history.DatabaseType = DatabaseTypes.Access;
				history.AccessConn = this.accessConn1.ConnectionString;
				goto IL_CE;
			case 2:
				history.DatabaseType = DatabaseTypes.MySql;
				history.MySqlConn = this.mySqlConn1.ConnectionString;
				goto IL_CE;
			case 3:
				history.DatabaseType = DatabaseTypes.Oracle;
				history.OracleConn = this.oracleConn1.ConnectionString;
				goto IL_CE;
			case 4:
				history.DatabaseType = DatabaseTypes.SQLite;
				history.SQLiteConn = this.sqLiteConn1.ConnectionString;
				goto IL_CE;
            case 5:
                history.DatabaseType = DatabaseTypes.Ase;
                history.AseConn = this.aseConn1.ConnectionString;
                goto IL_CE;
            case 6:
                history.DatabaseType = DatabaseTypes.DB2;
                history.DB2Conn = this.dB2Conn1.ConnectionString;
                goto IL_CE;
            case 7:
                history.DatabaseType = DatabaseTypes.PostgreSql;
                history.PostgreSqlConn = this.postgreSqlConn1.ConnectionString;
                goto IL_CE;
			}
			history.DatabaseType = (this.sqlConn1.IsSql2005 ? DatabaseTypes.Sql2005 : DatabaseTypes.Sql2000);
			history.SqlServerConn = this.sqlConn1.ConnectionString;
			IL_CE:
			History.Save(history);
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (this.backgroundWorker1.IsBusy)
			{
				this.backgroundWorker1.CancelAsync();
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
				base.Close();
			}
		}
		private void btnConnect_Click(object sender, EventArgs e)
		{
			this.pictureBox1.Visible = true;
			this.btnConnect.Enabled = false;
			Schema schema = this.GetSchema();
			this.backgroundWorker1.RunWorkerAsync(schema);
		}
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			Schema schema = e.Argument as Schema;
			Database schema2 = schema.GetSchema();
			if (this.backgroundWorker1.CancellationPending)
			{
				e.Cancel = true;
			}
			else
			{
				e.Result = schema2;
			}
		}
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.pictureBox1.Visible = false;
			this.btnConnect.Enabled = true;
			if (!e.Cancelled)
			{
				if (e.Error != null)
				{
					ShowMessage.Error("连接失败！错误：" + e.Error.Message);
				}
				else
				{
					if (e.Result == null)
					{
						ShowMessage.Error("连接失败！");
					}
					else
					{
						this.database = (e.Result as Database);
						this.SaveConnectionToFile();
						base.DialogResult = DialogResult.OK;
						base.Close();
					}
				}
			}
		}
	}
}
