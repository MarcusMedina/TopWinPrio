using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace TopWinPrio.Properties
{

    [DebuggerNonUserCode]
    [CompilerGenerated]
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resources
    {

        private static CultureInfo resourceCulture;
        private static ResourceManager resourceMan;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Resources.resourceCulture;
            }
            set
            {
                Resources.resourceCulture = value;
            }
        }

        internal static Bitmap GameIcon
        {
            get
            {
                object obj = Resources.ResourceManager.GetObject("GameIcon", Resources.resourceCulture);
                return (Bitmap)obj;
            }
        }

        internal static Bitmap Positive
        {
            get
            {
                object obj = Resources.ResourceManager.GetObject("Positive", Resources.resourceCulture);
                return (Bitmap)obj;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (Object.ReferenceEquals(Resources.resourceMan, null))
                {
                    ResourceManager resourceManager = new ResourceManager("TopWinPrio.Properties.Resources", typeof(Resources).Assembly);
                    Resources.resourceMan = resourceManager;
                }
                return Resources.resourceMan;
            }
        }

        internal static Bitmap SettingsIcon
        {
            get
            {
                object obj = Resources.ResourceManager.GetObject("SettingsIcon", Resources.resourceCulture);
                return (Bitmap)obj;
            }
        }

        internal static Bitmap ThemeSettingsIcon
        {
            get
            {
                object obj = Resources.ResourceManager.GetObject("ThemeSettingsIcon", Resources.resourceCulture);
                return (Bitmap)obj;
            }
        }

        internal Resources()
        {
        }

    } // class Resources

}

