using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace SocanCode
{
    public partial class CSharpToVBForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {   
        public CSharpToVBForm()
        {
            InitializeComponent();
            txt_Vb.SetStyle("VBNET");
            txt_Csharp.SetStyle("C#");        
        }

        private void btn_imp_Click(object sender, EventArgs e)
        {
            string cFileName = "";
            cFileName = this.GetFile();
            if (cFileName.Length > 0)
            {
                this.txt_Csharp.Text = this.FileToStr(cFileName);
            }
            string startupPath = Application.StartupPath;
            this.tabControl1.TabIndex = 0;
        }

        private string GetFile()
        {
            string fileName = "";
            string str2 = "C# Files (*.cs)|*.cs|All files (*.*)|*.*";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = str2;
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                fileName = dialog.FileName;
            }
            return fileName;
        }

        public string FileToStr(string cFileName)
        {
            StreamReader reader = new StreamReader(cFileName, Encoding.Default);
            string str = reader.ReadToEnd();
            reader.Close();
            return str;
        }

        private void btn_conert_Click(object sender, EventArgs e)
        {
            this.txt_msg.Text = "正在转换，请稍候...";
            this.txt_Vb.Text = new ConvertCSharp2VB.CSharpToVBConverter().Execute(this.txt_Csharp.Text);
            string startupPath = Application.StartupPath;
            this.tabControl1.TabIndex = 1;
            this.txt_msg.Text = "数据转换完成。";
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存文件";
            string text = "";
            if (this.tabControl1.SelectedIndex == 0)
            {
                dialog.Filter = "C# Files (*.cs)|*.cs|All files (*.*)|*.*";
                text = this.txt_Csharp.Text;
            }
            else
            {
                dialog.Filter = "VB.NET Files (*.vb)|*.vb|All files (*.*)|*.*";
                text = this.txt_Vb.Text;
            }
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txt_msg.Text = "正在导出数据，请稍候...";
                StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.Default);
                writer.Write(text);
                writer.Flush();
                writer.Close();
                this.txt_msg.Text = "数据导出完成。";
            }
        }       
    }
}
