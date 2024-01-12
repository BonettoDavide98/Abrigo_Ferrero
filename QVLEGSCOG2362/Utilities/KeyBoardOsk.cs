using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace QVLEGSCOG2362.Utilities
{
    public static class KeyBoardOsk
    {

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int index, int value);

        [DllImport("user32.dll")]
        static extern int InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        private const int WS_BORDER = 0x800000;
        private const int WS_CHILD = 0x40000000;
        private const int SWP_SHOWWINDOW = 0x40;
        private const int SWP_NOZORDER = 0x4;
        private const int SWP_FRAMECHANGED = 0x20;
        private const int GWL_STYLE = -16;
        private const int WS_POPUP = -2147483648;
        private const int WS_DLGFRAME = 0x400000;
        private const int WS_SYSMENU = 0x00080000;
        //  private const int  WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU);
        private const int WS_THICKFRAME = 0x40000;
        private const int WS_SIZEBOX = 0x40000;
        private const int DS_MODALFRAME = 0x80;
        private const int WS_CAPTION = 0x00C00000;


        public static void showKeypad(IntPtr parentWindowPtr)
        {
            try
            {
                if (Process.GetProcessesByName("osk").Count() == 0)
                {
                    StartTastiera(parentWindowPtr);
                }
                else
                {
                    Process[] p = Process.GetProcessesByName("osk");
                    p[0].Close();
                    StartTastiera(parentWindowPtr);
                }
            }
            catch (Exception) { }
        }

        private static void StartTastiera(IntPtr parentWindowPtr)
        {
            try
            {
                string cmdfile = Environment.GetEnvironmentVariable("comspec");
                Process process = new Process();
                string windir = Environment.GetEnvironmentVariable("WINDIR");
                //   p.StartInfo.FileName = windir + @"\System32\cmd.exe";1
                process.StartInfo.FileName = cmdfile;

                process.StartInfo.Arguments = "/C " + windir + @"\System32\osk.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;

                process.Start();
                //Da qua si bomba... TODO
                //SetWindowLong(process.MainWindowHandle, GWL_STYLE, DS_MODALFRAME | WS_POPUP | WS_CAPTION | WS_SYSMENU);
                //SetWindowPos(process.MainWindowHandle,
                //parentWindowPtr, // Parent Window
                //0, // Keypad Position X
                //Screen.PrimaryScreen.Bounds.Height - 350, // Keypad Position Y
                //Screen.PrimaryScreen.Bounds.Width * 5 / 6, // Keypad Width
                //Screen.PrimaryScreen.Bounds.Height / 2, // Keypad Height
                //SWP_SHOWWINDOW | SWP_NOZORDER | SWP_FRAMECHANGED); // Show Window and Place on Top

                //SetForegroundWindow(process.MainWindowHandle);
                //InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);

                //process.Dispose();
            }
            catch (Exception) { }
        }

    }
}