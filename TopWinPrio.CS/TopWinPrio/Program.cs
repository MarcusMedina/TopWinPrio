//----------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

#pragma warning disable ET002

namespace TopWinPrio
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Program"/>.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        [STAThread]
        public static void Main()
        {
#pragma warning disable IDE0059 // Value assigned to symbol is never used
            var flag = true;
#pragma warning restore IDE0059 // Value assigned to symbol is never used
            using (var mutex = new Mutex(true, "LunaWorX TopWinPrio", out flag))
            {
                if (flag)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    using (var frmPrio = new MainForm { Visible = false })
                    {
                        Application.Run(frmPrio);
                    }
                }
            }
        }
    }
}