//----------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

#pragma warning disable ET002
namespace TopWinPrio.Properties
{
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Defines the <see cref="Settings" />
    /// </summary>
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    [CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        /// <summary>
        /// Defines the defaultInstance
        /// </summary>
        private static Settings defaultInstance;

        /// <summary>
        /// Initializes static members of the <see cref="Settings"/> class.
        /// </summary>
        static Settings()
        {
            Settings.defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
        }

        /// <summary>
        /// Gets the Default
        /// </summary>
        public static Settings Default
        {
            get
            {
                return Settings.defaultInstance;
            }
        }

        /// <summary>
        /// Gets or sets the ActiveWinPrio
        /// </summary>
        [UserScopedSetting]
        [DefaultSettingValue("0")]
        [DebuggerNonUserCode]
        public int ActiveWinPrio
        {
            get
            {
                return (int)base["ActiveWinPrio"];
            }
            set
            {
                base["ActiveWinPrio"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the ApplicationPrio
        /// </summary>
        [DebuggerNonUserCode]
        [UserScopedSetting]
        [DefaultSettingValue("1")]
        public int ApplicationPrio
        {
            get
            {
                return (int)base["ApplicationPrio"];
            }
            set
            {
                base["ApplicationPrio"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether BalloonHidden
        /// </summary>
        [DefaultSettingValue("True")]
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public bool BalloonHidden
        {
            get
            {
                return (bool)base["BalloonHidden"];
            }
            set
            {
                base["BalloonHidden"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether BalloonStart
        /// </summary>
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool BalloonStart
        {
            get
            {
                return (bool)base["BalloonStart"];
            }
            set
            {
                base["BalloonStart"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether BoostExplorer
        /// </summary>
        [UserScopedSetting]
        [DefaultSettingValue("False")]
        [DebuggerNonUserCode]
        public bool BoostExplorer
        {
            get
            {
                return (bool)base["BoostExplorer"];
            }
            set
            {
                base["BoostExplorer"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the InactiveWinPrio
        /// </summary>
        [DefaultSettingValue("0")]
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public int InactiveWinPrio
        {
            get
            {
                return (int)base["InactiveWinPrio"];
            }
            set
            {
                base["InactiveWinPrio"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the RefreshTime
        /// </summary>
        [DefaultSettingValue("1")]
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public int RefreshTime
        {
            get
            {
                return (int)base["RefreshTime"];
            }
            set
            {
                base["RefreshTime"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether StartHidden
        /// </summary>
        [DefaultSettingValue("True")]
        [DebuggerNonUserCode]
        [UserScopedSetting]
        public bool StartHidden
        {
            get
            {
                return (bool)base["StartHidden"];
            }
            set
            {
                base["StartHidden"] = value;
            }
        }

        /// <summary>
        /// The SettingChangingEventHandler
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="SettingChangingEventArgs"/></param>
        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
        }

        /// <summary>
        /// The SettingsSavingEventHandler
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="CancelEventArgs"/></param>
        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
        }
    }
}
