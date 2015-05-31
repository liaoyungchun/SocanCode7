using System;
using System.Windows.Forms;
using System.Text;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace SocanCode
{
    public partial class CodeToTemplateForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public CodeToTemplateForm()
        {
            InitializeComponent();
            txtHtml.SetStyleByExt("html");
            txtJs.SetStyleByExt("js");
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            
        }

        private void txtHtml_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHtml.Text))
                txtJs.Text = string.Empty;

            string[] lines = txtHtml.Text.Split('\n');
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var NewLine = '\\n'");
            sb.AppendLine("var temp = '';");
            foreach (string item in lines)
            {
                if (string.IsNullOrWhiteSpace(item))
                    sb.AppendLine("temp += NewLine;");
                else
                    sb.AppendLine(string.Format("temp += '{0}' + NewLine;", item.Replace("\r", "").Replace("\\", "\\\\").Replace("'", "\\'")));
            }
            txtJs.Text = sb.ToString();
        }

        private void txtJs_Click(object sender, EventArgs e)
        {
            ShowMessage.Alert("¸´ÖÆ¡£");
        }
    }
}