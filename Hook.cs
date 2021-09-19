using System;
using System.Runtime.InteropServices;

namespace KeyHook
{
    public static class Hook
    {
        [DllImport("user32.dll", SetLastError = true)]

        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll", SetLastError = true)]

        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


        [DllImport("user32.dll")]

        static extern bool PostMessage(

            IntPtr hWnd, // handle to destination window 

            UInt32 Msg, // message 

            Int32 wParam, // first message parameter 

            Int32 lParam // second message parameter 

        );

        const int WM_KEYDOWN = 0x100;

        public static void Sendkey(string procName, int keyCount)
        {
            IntPtr proc = FindWindow(procName, null);

            IntPtr editx = FindWindowEx(proc, IntPtr.Zero, "edit", null);

            PostMessage(editx, WM_KEYDOWN, keyCount, 0);
        }
    }
}
