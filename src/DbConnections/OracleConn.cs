using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DbConnections
{
    public partial class OracleConn : UserControl, IDbConn
    {
        public OracleConn()
        {
            InitializeComponent();
        }

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

        private void SetString(string connStr)
        {
            txtString.Text = connStr;
        }

        private string GetString()
        {
            return txtString.Text.Trim();
        }

        private void SetTable(string connStr)
        {
            Match mSource = Regex.Match(connStr, @"Data Source=(?<Source>[^\;]*);");
            if (mSource.Success)
            {
                txtService.Text = mSource.Groups["Source"].Value;
            }

            Match mUser = Regex.Match(connStr, @"User ID=(?<User>[^\;]*);");
            if (mUser.Success)
            {
                txtUserName.Text = mUser.Groups["User"].Value;
            }

            Match mPassword = Regex.Match(connStr, @"Password=(?<Password>[^\;]*);");
            if (mPassword.Success)
            {
                txtPassword.Text = mPassword.Groups["Password"].Value;
            }
        }

        private string GetTable()
        {
            return string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2};Unicode=True",
                          txtService.Text.Trim(),
                          txtUserName.Text.Trim(),
                          txtPassword.Text.Trim());
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
    }
}
