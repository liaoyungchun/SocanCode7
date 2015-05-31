using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DbConnections
{
    public partial class SqlConn : UserControl, IDbConn
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
                    return txtString.Text.Trim();
                }
            }
            set
            {
                SetTable(value);
                SetString(value);
            }
        }

        public bool IsSql2005
        {
            get
            {
                return cobVersion.SelectedIndex == 1;
            }
            set
            {
                if (value)
                {
                    cobVersion.SelectedIndex = 1;
                }
                else
                {
                    cobVersion.SelectedIndex = 0;
                }
            }
        }

        public SqlConn()
        {
            InitializeComponent();
            cobVersion.SelectedIndex = 0;
            cobValidation.SelectedIndex = 1;
        }

        private void rad_CheckedChanged(object sender, EventArgs e)
        {
            pnlTable.Enabled = radTable.Checked;
            txtString.Enabled = radString.Checked;

            if (radString.Checked)
                SetString(GetTable());
            if (radTable.Checked)
                SetTable(GetString());
        }

        private string GetTable()
        {
            StringBuilder connStr = GetServer();
            connStr.Append(string.Format("Initial Catalog={0};", cobDatabase.Text.Trim()));
            return connStr.ToString();
        }

        private void SetTable(string connStr)
        {
            Match mSource = Regex.Match(connStr, @"Data Source=(?<Source>[^\;]*);");
            if (mSource.Success)
            {
                txtServer.Text = mSource.Groups["Source"].Value;
            }

            Match mSecurity = Regex.Match(connStr, @"Persist Security Info=False;");
            if (mSecurity.Success)
            {
                cobValidation.SelectedIndex = 0;
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

            Match mDatabase = Regex.Match(connStr, @"Initial Catalog=(?<Database>[^\;]*);");
            if (mDatabase.Success)
            {
                cobDatabase.Text = mDatabase.Groups["Database"].Value;
            }
        }

        private string GetString()
        {
            return txtString.Text.Trim().Replace("false", "False");
        }

        private void SetString(string connStr)
        {
            txtString.Text = connStr;
        }

        private StringBuilder GetServer()
        {
            StringBuilder connStr = new StringBuilder();
            connStr.Append(string.Format("Data Source={0};", txtServer.Text.Trim()));

            switch (cobValidation.SelectedIndex)
            {
                case 0:
                    connStr.Append("Integrated Security=SSPI;Persist Security Info=False;");
                    break;
                case 1:
                default:
                    connStr.Append(string.Format("User ID={0};", txtUserName.Text.Trim()));
                    connStr.Append(string.Format("Password={0};", txtPassword.Text.Trim()));
                    break;
            }
            return connStr;
        }

        private void cobValidation_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = txtPassword.Enabled = cobValidation.SelectedIndex == 1;
        }

        private void cobDatabase_DropDown(object sender, EventArgs e)
        {
            cobDatabase.Items.Clear();

            StringBuilder connStr = GetServer();

            connStr.Append("Initial Catalog=master;");

            DBUtility.DbHelper dbHelper = DBUtility.DbHelper.Create("SqlServer");
            dbHelper.ConnectionString = connStr.ToString();
            try
            {
                DataSet ds = dbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_databases", null);
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    cobDatabase.Items.Add(r["DATABASE_NAME"].ToString());
                }
            }
            catch
            {

            }
        }
    }
}
