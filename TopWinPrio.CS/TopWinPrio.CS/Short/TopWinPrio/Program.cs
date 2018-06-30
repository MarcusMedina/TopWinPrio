using System;
using System.Threading;
using System.Windows.Forms;

namespace TopWinPrio
{

    internal abstract sealed class Program
    {

        [STAThread]
        public static void Main()
        {
            bool flag = true;
            using (Mutex mutex = new Mutex(true, "LunaWorX TopWinPrio", flag))
            {
                if (flag)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    frmPrio frmPrio = new frmPrio();
                    frmPrio.Visible = false;
                    Application.Run(frmPrio);
                }
            }
        }

    } // class Program

}

