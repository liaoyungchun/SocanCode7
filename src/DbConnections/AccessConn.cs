using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DbConnections
{
    public partial class AccessConn : UserControl, IDbConn
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
                SetTable(value);
                SetString(value);
            }
        }

        public AccessConn()
        {
            InitializeComponent();
        }

        private void rad_CheckedChanged(object sender, EventArgs e)
        {
            pnlTable.Enabled = radTable.Checked;
            txtString.Enabled = radString.Checked;

            if (radTable.Checked)
                SetTable(GetString());
            if (radString.Checked)
                SetString(GetTable());
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
            StringBuilder connStr = new StringBuilder();
            connStr.Append("Provider=Microsoft.Jet.OLEDB.4.0;");

            if (!chkNullPassword.Checked)
            {
                connStr.Append(string.Format("Password={0};", txtPasswrod.Text.Trim()));
            }

            connStr.Append(string.Format(@"Data Source={0};", txtPath.Text.Trim()));
            connStr.Append("Persist Security Info=True;");

            return connStr.ToString();
        }

        private void SetTable(string connStr)
        {
            Match mPassword = Regex.Match(connStr, @"Password=(?<Password>[^\;]*);");
            if (mPassword.Success)
            {
                chkNullPassword.Checked = false;
                txtPasswrod.Text = mPassword.Groups["Password"].Value;
            }

            Match mSource = Regex.Match(connStr, @"Data Source=(?<Source>[^\;]*);");
            if (mSource.Success)
            {
                txtPath.Text = mSource.Groups["Source"].Value;
            }
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (txtPath.Text.Trim() != string.Empty)
                dlg.InitialDirectory = txtPath.Text.Trim();
            else
                dlg.InitialDirectory = "c:\\";

            dlg.Filter = "Microsoft Access Êý¾Ý¿â(*.mdb)|*.mdb";
            dlg.FilterIndex = 0;
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlg.FileName;
            }
        }

        private void chkNullPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswrod.Enabled = !chkNullPassword.Checked;
        }
    }
}
