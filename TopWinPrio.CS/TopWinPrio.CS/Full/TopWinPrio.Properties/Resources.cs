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

    [System.Diagnostics.DebuggerNonUserCode]
    [System.Runtime.CompilerServices.CompilerGenerated]
    [System.CodeDom.Compiler.GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resources
    {

        private static System.Globalization.CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture
        {
            get
            {
                return TopWinPrio.Properties.Resources.resourceCulture;
            }
            set
            {
                TopWinPrio.Properties.Resources.resourceCulture = value;
            }
        }

        internal static System.Drawing.Bitmap GameIcon
        {
            get
            {
                object obj = TopWinPrio.Properties.Resources.ResourceManager.GetObject("GameIcon", TopWinPrio.Properties.Resources.resourceCulture);
                return (System.Drawing.Bitmap)obj;
            }
        }

        internal static System.Drawing.Bitmap Positive
        {
            get
            {
                object obj = TopWinPrio.Properties.Resources.ResourceManager.GetObject("Positive", TopWinPrio.Properties.Resources.resourceCulture);
                return (System.Drawing.Bitmap)obj;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (System.Object.ReferenceEquals(TopWinPrio.Properties.Resources.resourceMan, null))
                {
                    System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("TopWinPrio.Properties.Resources", typeof(TopWinPrio.Properties.Resources).Assembly);
                    TopWinPrio.Properties.Resources.resourceMan = resourceManager;
                }
                return TopWinPrio.Properties.Resources.resourceMan;
            }
        }

        internal static System.Drawing.Bitmap SettingsIcon
        {
            get
            {
                object obj = TopWinPrio.Properties.Resources.ResourceManager.GetObject("SettingsIcon", TopWinPrio.Properties.Resources.resourceCulture);
                return (System.Drawing.Bitmap)obj;
            }
        }

        internal static System.Drawing.Bitmap ThemeSettingsIcon
        {
            get
            {
                object obj = TopWinPrio.Properties.Resources.ResourceManager.GetObject("ThemeSettingsIcon", TopWinPrio.Properties.Resources.resourceCulture);
                return (System.Drawing.Bitmap)obj;
            }
        }

        internal Resources()
        {
        }

    } // class Resources

}

