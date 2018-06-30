using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TopWinPrio.Properties
{

    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    [CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {

        private static Settings defaultInstance;

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

        public static Settings Default
        {
            get
            {
                return Settings.defaultInstance;
            }
        }

        public Settings()
        {
        }

        static Settings()
        {
            Settings.defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
        }

        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
        }

    } // class Settings

}

