//----------------------------------------------------------------------------------------------------------------
// File header copyright text should match
// <copyright file="Util.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

#pragma warning disable ET002
namespace TopWinPrio
{
    using Microsoft.Win32;

    /// <summary>
    /// Defines the <see cref="Util" />.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Defines the HKCVRUNLOCATION.
        /// </summary>
        private const string HKCVRUNLOCATION = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

        /// <summary>
        /// The IsAutoStartEnabled.
        /// </summary>
        /// <param name="keyName">The keyName<see cref="string"/>.</param>
        /// <param name="assemblyLocation">The assemblyLocation<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(HKCVRUNLOCATION);
            if (registryKey == null)
            {
                return false;
            }

            var s = (string)registryKey.GetValue(keyName);
            return s == null ? false : s == assemblyLocation;
        }

        /// <summary>
        /// The SetAutoStart.
        /// </summary>
        /// <param name="keyName">The keyName<see cref="string"/>.</param>
        /// <param name="assemblyLocation">The assemblyLocation<see cref="string"/>.</param>
        public static void SetAutoStart(string keyName, string assemblyLocation)
        {
            var registryKey = Registry.CurrentUser.CreateSubKey(HKCVRUNLOCATION);
            registryKey.SetValue(keyName, assemblyLocation);
        }

        /// <summary>
        /// The UnSetAutoStart.
        /// </summary>
        /// <param name="keyName">The keyName<see cref="string"/>.</param>
        public static void UnSetAutoStart(string keyName)
        {
            var registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
            registryKey.DeleteValue(keyName);
        }
    }
}
