using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SHDocVw;

namespace BrowseHelper
{
    public class BrowserWapper
    {
        public readonly static string ABOUT_BLANK = "about:blank";
        private enum MiscCommandTarget { Find = 1, ViewSource, Options }
        private static Guid cmdGuid = new Guid("ED016940-BD5B-11CF-BA4E-00C04FD70816");

        /// <summary>
        /// 调用系统接口查看源文件
        /// </summary>
        public static void ViewSource(mshtml.IHTMLDocument2 Document)
        {
            IOleCommandTarget cmdt;
            Object o = new object();

            cmdt = (IOleCommandTarget)Document;
            cmdt.Exec(ref cmdGuid, (uint)MiscCommandTarget.ViewSource,
                (uint)SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref o, ref o);
        }

        /// <summary>
        /// 调用系统的“IE选项”
        /// </summary>
        public static void IEConfig()
        {
            Process.Start("Rundll32.exe", "shell32.dll,Control_RunDLL InetCpl.cpl,,0");
        }

        /// <summary>
        /// 调用系统的“添加到收藏夹”
        /// </summary>
        public static void AddFavorite(string url, string title)
        {
            ShellUIHelper helper = new ShellUIHelper();
            if (string.IsNullOrEmpty(title))
            {
                title = ABOUT_BLANK;
            }

            object o = title;
            helper.AddFavorite(url, ref o); //调用添加到收藏夹对话框
        }

        /// <summary>
        /// 调用系统的“整理收藏夹”
        /// </summary>
        public static void OrganizeFavorites()
        {
            ShellUIHelper helper = new ShellUIHelper();
            object o = null;
            helper.ShowBrowserUI("OrganizeFavorites", ref o);
        }
    }
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct OLECMDTEXT
{
    public uint cmdtextf;
    public uint cwActual;
    public uint cwBuf;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
    public char rgwz;
}

[StructLayout(LayoutKind.Sequential)]
public struct OLECMD
{
    public uint cmdID;
    public uint cmdf;
}

// IOleCommandTarget的Interop定义
[ComImport, Guid("b722bccb-4e68-101b-a2bc-00aa00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IOleCommandTarget
{
    //重要: 下面方法的顺序非常重要，因为本示例中我们使用的是早期绑定，详见MSDN中有关.net/COM互操作的参考。
    void QueryStatus(ref Guid pguidCmdGroup, UInt32 cCmds,
    [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] OLECMD[] prgCmds, ref OLECMDTEXT CmdText);
    void Exec(ref Guid pguidCmdGroup, uint nCmdId, uint nCmdExecOpt, ref object pvaIn, ref object pvaOut);
}
