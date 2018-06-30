using System.Text;

namespace TopWinPrio
{

    internal class WinAPI
    {

        public static int GetTopWindowHandle
        {
            get
            {
                return (int)WinAPI.GetForegroundWindow();
            }
        }

        public static int GetTopWindowProcessID
        {
            get
            {
                uint ui = 0;
                WinAPI.GetWindowThreadProcessId(WinAPI.GetForegroundWindow(), out ui);
                return (int)ui;
            }
        }

        public static string GetTopWindowText
        {
            get
            {
                string s = "";
                int i = 256;
                StringBuilder stringBuilder = new StringBuilder(i);
                IntPtr intPtr = WinAPI.GetForegroundWindow();
                if (WinAPI.GetWindowText(intPtr, stringBuilder, i) > 0)
                    s = stringBuilder.ToString();
                return s;
            }
        }

        public WinAPI()
        {
        }

        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetForegroundWindow();

        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    } // class WinAPI

}

