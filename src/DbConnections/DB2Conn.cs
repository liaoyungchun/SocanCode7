using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DbConnections
{
    public partial class DB2Conn : UserControl
    {
        public DB2Conn()
        {
            InitializeComponent();
        }
        private void rad_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlTable.Enabled = this.radTable.Checked;
            this.txtString.Enabled = this.radString.Checked;
            if (this.radTable.Checked)
            {
                this.SetTable(this.GetString());
            }
            if (this.radString.Checked)
            {
                this.SetString(this.GetTable());
            }
        }

        private void SetString(string connStr)
        {
            this.txtString.Text = connStr;
        }

        private void SetTable(string connStr)
        {
            Match match = Regex.Match(connStr, @"Server=(?<Source>[^\;]*);");
            if (match.Success)
            {
                this.txtIP.Text = match.Groups["Source"].Value;
            }
            Match match2 = Regex.Match(connStr, @"User ID=(?<User>[^\;]*);");
            if (match2.Success)
            {
                this.txtUserName.Text = match2.Groups["User"].Value;
            }
            Match match3 = Regex.Match(connStr, @"Password=(?<Password>[^\;]*);");
            if (match3.Success)
            {
                this.txtPassword.Text = match3.Groups["Password"].Value;
            }
            Match match4 = Regex.Match(connStr, @"Database=(?<Database>[^\;]*);");
            if (match4.Success)
            {
                this.txtDatabase.Text = match4.Groups["Database"].Value;
            }
        }

        public string ConnectionString
        {
            get
            {
                if (this.radTable.Checked)
                {
                    return this.GetTable();
                }
                return this.GetString();
            }
            set
            {
                this.SetString(value);
                this.SetTable(value);
            }
        }
        private string GetString()
        {
            return this.txtString.Text.Trim();
        }

        private string GetTable()
        {
            return string.Format("Database={0};User ID={1};Password={2};Server={3};persist security info=true", this.txtDatabase.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.txtIP.Text.Trim());
        }
    }
}
