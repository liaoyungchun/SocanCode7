using System;
using System.Windows.Forms;

namespace SocanCode
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string error = string.Format("[{0}]{1}\r\n{2}\r\n\r\n", DateTime.Now.ToString(), e.Exception.Message, e.Exception.StackTrace);
            ErrorForm frm = new ErrorForm(error);
            frm.Show();
            Generator.IOHelper.AppendFile(Application.StartupPath + "\\error.txt", error);
        }
    }
}