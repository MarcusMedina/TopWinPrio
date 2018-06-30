using System;
using System.Threading;
using System.Windows.Forms;

namespace TopWinPrio
{

    internal abstract class Program
    {

        [System.STAThread]
        public static void Main()
        {
            bool flag = true;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, "LunaWorX TopWinPrio", flag))
            {
                if (flag)
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    TopWinPrio.frmPrio frmPrio = new TopWinPrio.frmPrio();
                    frmPrio.Visible = false;
                    System.Windows.Forms.Application.Run(frmPrio);
                }
            }
        }

    } // class Program

}

