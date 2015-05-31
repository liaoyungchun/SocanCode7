using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DbConnections
{
    public partial class AseConn : UserControl
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

        public AseConn()
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
            return string.Format("Data Source={0};Port={1};User Id={2};Password={3};Database={4};persist security info=true",
                          txtServer.Text.Trim(),
                          txtPort.Text.Trim(),
                          txtUserName.Text.Trim(),
                          txtPassword.Text.Trim(),
                          cobDatabase.Text.Trim());
        }

        private void SetTable(string connStr)
        {
            Match mSource = Regex.Match(connStr, @"Data Source=(?<Source>[^\;]*);");
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
                cobDatabase.Text = mDatabase.Groups["Database"].Value;
            }
        }

        private void cobDatabase_DropDown(object sender, EventArgs e)
        {
            cobDatabase.Items.Clear();

            DBUtility.DbHelper dbHelper = DBUtility.DbHelper.Create("Ase");
            dbHelper.ConnectionString = string.Format("Data Source={0};Port={1};User Id={2};Password={3};Database=master;",
                txtServer.Text.Trim(), txtPort.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim());

            try
            {
                DataSet ds = dbHelper.ExecuteDataset(CommandType.Text, "select name from sysdatabases where status2=1", null);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    cobDatabase.Items.Add(r[0].ToString());
                }
            }
            catch
            {
            }
        }
    }
}
