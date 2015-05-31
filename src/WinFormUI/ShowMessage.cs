
namespace System.Windows.Forms
{
    /// <summary>
    /// 消息提示框
    /// </summary>
    public class ShowMessage
    {
        public static void Alert(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Alert(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string msg)
        {
            MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Warning(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Error(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string msg)
        {
            DialogResult result = MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            return result == DialogResult.Yes;
        }

        public static bool Confirm(string msg, string title)
        {
            DialogResult result = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            return result == DialogResult.Yes;
        }
    }
}
