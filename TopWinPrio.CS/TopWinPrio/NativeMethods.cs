//----------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="MarcusMedinapro">
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
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="NativeMethods" />.
    /// </summary>
    internal class NativeMethods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeMethods"/> class.
        /// </summary>
        public NativeMethods()
        {
        }

        /// <summary>
        /// Gets the GetTopWindowHandle.
        /// </summary>
        public static int GetTopWindowHandle => (int)NativeMethods.GetForegroundWindow();

        /// <summary>
        /// Gets the GetTopWindowProcessID.
        /// </summary>
        public static int GetTopWindowProcessID
        {
            get
            {
                GetWindowThreadProcessId(GetForegroundWindow(), out var ui);
                return (int)ui;
            }
        }

        /// <summary>
        /// Gets the GetTopWindowText.
        /// </summary>
        public static string GetTopWindowText
        {
            get
            {
                var s = string.Empty;
                const int i = 256;
                var stringBuilder = new StringBuilder(i);
                var intPtr = NativeMethods.GetForegroundWindow();
                if (NativeMethods.GetWindowText(intPtr, stringBuilder, i) > 0)
                {
                    s = stringBuilder.ToString();
                }

                return s;
            }
        }

        /// <summary>
        /// The GetForegroundWindow.
        /// </summary>
        /// <returns>The <see cref="IntPtr"/>.</returns>
        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        private static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// The GetWindowText.
        /// </summary>
        /// <param name="hWnd">The hWnd<see cref="IntPtr"/>.</param>
        /// <param name="text">The text<see cref="StringBuilder"/>.</param>
        /// <param name="count">The count<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        /// <summary>
        /// The GetWindowThreadProcessId.
        /// </summary>
        /// <param name="hWnd">The hWnd<see cref="IntPtr"/>.</param>
        /// <param name="lpdwProcessId">The lpdwProcessId<see cref="uint"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [PreserveSig]
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    }
}
