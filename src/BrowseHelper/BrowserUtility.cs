using System.Runtime.InteropServices;
using System.Text;
using System;

namespace BrowseHelper
{
    public class BrowserUtility
    {
        /// <summary>
        /// ½ØÈ¡×Ö·û´®
        /// </summary>
        public static string CutString(string s, int byteCount)
        {
            if (Encoding.Default.GetByteCount(s) < byteCount)
            {
                return s;
            }
            else
            {
                byte[] bytes = Encoding.Default.GetBytes(s);
                string subStr = Encoding.Default.GetString(bytes, 0, byteCount - 3);
                char ch = subStr[subStr.Length - 1];
                if (subStr[subStr.Length - 1] != s[subStr.Length - 1])
                {
                    return subStr.Substring(0, subStr.Length - 1) + "...";
                }
                else
                {
                    return subStr + "...";
                }
            }
        }

        [STAThread]
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
        const int URLMON_OPTION_USERAGENT = 0x10000001;

        /// <summary>
        /// ¸ü¸ÄUserAgent
        /// </summary>
        public static void ChangeUserAgent(string ua)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, ua, ua.Length, 0);
        }  

    }
}
