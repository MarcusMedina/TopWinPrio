using System.Text;

namespace TopWinPrio
{

    internal class WinAPI
    {

        public static int GetTopWindowHandle
        {
            get
            {
                return (int)TopWinPrio.WinAPI.GetForegroundWindow();
            }
        }

        public static int GetTopWindowProcessID
        {
            get
            {
                uint ui = 0;
                TopWinPrio.WinAPI.GetWindowThreadProcessId(TopWinPrio.WinAPI.GetForegroundWindow(), out ui);
                return (int)ui;
            }
        }

        public static string GetTopWindowText
        {
            get
            {
                string s = "";
                int i = 256;
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(i);
                System.IntPtr intPtr = TopWinPrio.WinAPI.GetForegroundWindow();
                if (TopWinPrio.WinAPI.GetWindowText(intPtr, stringBuilder, i) > 0)
                    s = stringBuilder.ToString();
                return s;
            }
        }

        public WinAPI()
        {
        }

        [System.Runtime.InteropServices.PreserveSig]
        [System.Runtime.InteropServices.DllImport("user32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        private static extern System.IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.PreserveSig]
        [System.Runtime.InteropServices.DllImport("user32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        private static extern int GetWindowText(System.IntPtr hWnd, System.Text.StringBuilder text, int count);

        [System.Runtime.InteropServices.PreserveSig]
        [System.Runtime.InteropServices.DllImport("user32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        private static extern int GetWindowThreadProcessId(System.IntPtr hWnd, out uint lpdwProcessId);

    } // class WinAPI

}

