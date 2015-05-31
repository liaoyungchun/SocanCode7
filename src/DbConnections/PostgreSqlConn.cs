using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DbConnections
{
    public partial class PostgreSqlConn : UserControl
    {
        public string ConnectionString
        {
            get
            {
                if (radTable.Checked)
                {
                    return GetTable();
                }
                else
                {
                    return GetString();
                }
            }
            set
            {
                SetString(value);
                SetTable(value);
            }
        }

        public PostgreSqlConn()
        {
            InitializeComponent();
        }

        private void rad_CheckedChanged(object sender, EventArgs e)
        {
            pnlTable.Enabled = radTable.Checked;
            txtString.Enabled = radString.Checked;

            if (radTable.Checked)
            {
                SetTable(GetString());
            }
            if (radString.Checked)
            {
                SetString(GetTable());
            }
        }

        private string GetString()
        {
            return txtString.Text.Trim();
        }

        private void SetString(string connStr)
        {
            txtString.Text = connStr;
        }

        private string GetTable()
        {
            return string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};Encoding=UNICODE",
                          txtServer.Text.Trim(),
                          txtPort.Text.Trim(),
                          txtUserName.Text.Trim(),
                          txtPassword.Text.Trim(),
                          txtDatabase.Text.Trim());
        }

        private void SetTable(string connStr)
        {
            Match mSource = Regex.Match(connStr, @"Server=(?<Source>[^\;]*);");
            if (mSource.Success)
            {
                txtServer.Text = mSource.Groups["Source"].Value;
            }

            Match mPort = Regex.Match(connStr, @"Port=(?<Port>[^\;]*);");
            if (mPort.Success)
            {
                txtPort.Text = mPort.Groups["Port"].Value;
            }

            Match mUser = Regex.Match(connStr, @"User Id=(?<User>[^\;]*);");
            if (mUser.Success)
            {
                txtUserName.Text = mUser.Groups["User"].Value;
            }

            Match mPassword = Regex.Match(connStr, @"Password=(?<Password>[^\;]*);");
            if (mPassword.Success)
            {
                txtPassword.Text = mPassword.Groups["Password"].Value;
            }

            Match mDatabase = Regex.Match(connStr, @"Database=(?<Database>[^\;]*);");
            if (mDatabase.Success)
            {
                txtDatabase.Text = mDatabase.Groups["Database"].Value;
            }
        }
    }
}
