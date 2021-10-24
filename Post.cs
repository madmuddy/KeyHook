using System;
using System.Runtime.InteropServices;

namespace KeyPost
{
    public static class Post
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        const int WM_KEYDOWN = 0x100;

        public static void SendKey(string procName, int keyCount, bool wndTitle)
        {
            IntPtr proc = FindWindow(procName, null);

            if (wndTitle)
            {
                proc = FindWindow(null, procName);
            }

            PostMessage(proc, WM_KEYDOWN, keyCount, 0);
        }
    }
}
