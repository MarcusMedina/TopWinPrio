using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TopWinPrio.Properties
{

    [System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal sealed class Settings : System.Configuration.ApplicationSettingsBase
    {

        private static TopWinPrio.Properties.Settings defaultInstance;

        [System.Configuration.UserScopedSetting]
        [System.Configuration.DefaultSettingValue("0")]
        [System.Diagnostics.DebuggerNonUserCode]
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

        [System.Diagnostics.DebuggerNonUserCode]
        [System.Configuration.UserScopedSetting]
        [System.Configuration.DefaultSettingValue("1")]
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

        [System.Configuration.DefaultSettingValue("True")]
        [System.Configuration.UserScopedSetting]
        [System.Diagnostics.DebuggerNonUserCode]
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

        [System.Configuration.UserScopedSetting]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Configuration.DefaultSettingValue("True")]
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

        [System.Configuration.UserScopedSetting]
        [System.Configuration.DefaultSettingValue("False")]
        [System.Diagnostics.DebuggerNonUserCode]
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

        [System.Configuration.DefaultSettingValue("0")]
        [System.Configuration.UserScopedSetting]
        [System.Diagnostics.DebuggerNonUserCode]
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

        [System.Configuration.DefaultSettingValue("1")]
        [System.Configuration.UserScopedSetting]
        [System.Diagnostics.DebuggerNonUserCode]
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

        [System.Configuration.DefaultSettingValue("True")]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Configuration.UserScopedSetting]
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

        public static TopWinPrio.Properties.Settings Default
        {
            get
            {
                return TopWinPrio.Properties.Settings.defaultInstance;
            }
        }

        public Settings()
        {
        }

        static Settings()
        {
            TopWinPrio.Properties.Settings.defaultInstance = (TopWinPrio.Properties.Settings)System.Configuration.SettingsBase.Synchronized(new TopWinPrio.Properties.Settings());
        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
        }

        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

    } // class Settings

}

