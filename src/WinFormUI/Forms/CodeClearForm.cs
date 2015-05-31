using System;
using System.Text;
using System.Windows.Forms;

namespace SocanCode
{
    public partial class CodeClearForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public CodeClearForm()
        {
            InitializeComponent();
        }

        private void btnRemoveLineNum_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            StringBuilder tmp = new StringBuilder();

            bool isNewLine = true;
            foreach (char item in code)
            {
                if (item == '\r' || item == '\n')
                {
                    tmp.Append(item);
                    isNewLine = true;
                    continue;
                }

                if (isNewLine)
                {
                    int i;

                    if (int.TryParse(new string(new char[] { item }), out i) == false)
                    {
                        tmp.Append(item);
                    }
                }
                else
                {
                    tmp.Append(item);
                }
            }

            txtCode.Text = tmp.ToString();
        }

        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            while (code.IndexOf("\r\n\r\n") >= 0)
            {
                code = code.Replace("\r\n\r\n", "\r\n");
            }

            txtCode.Text = code;
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                txtCode.SelectAll();
            }
        }
    }
}
