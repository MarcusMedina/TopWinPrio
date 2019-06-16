//----------------------------------------------------------------------------------------------------------------
// <copyright file="Resources.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------

#pragma warning disable ET002

namespace TopWinPrio.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Defines the <see cref="Resources"/>
    /// </summary>
    [DebuggerNonUserCode]
    [CompilerGenerated]
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resources
    {
        /// <summary>
        /// Defines the resourceCulture
        /// </summary>
        private static CultureInfo resourceCulture;

        /// <summary>
        /// Defines the resourceMan
        /// </summary>
        private static ResourceManager resourceMan;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class.
        /// </summary>
        internal Resources()
        {
        }

        /// <summary>
        /// Gets or sets the Culture
        /// </summary>
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

        /// <summary>
        /// Gets the GameIcon
        /// </summary>
        internal static Bitmap GameIcon
        {
            get
            {
                object obj = Resources.ResourceManager.GetObject("GameIcon", Resources.resourceCulture);
                return (Bitmap)obj;
            }
        }

        /// <summary>
        /// Gets the Positive
        /// </summary>
        internal static Bitmap Positive
        {
            get
            {
                object obj = Resources.ResourceManager.GetObject("Positive", Resources.resourceCulture);
                return (Bitmap)obj;
            }
        }

        /// <summary>
        /// Gets the ResourceManager
        /// </summary>
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

        /// <summary>
        /// Gets the SettingsIcon
        /// </summary>
        internal static Bitmap SettingsIcon
        {
            get
            {
                object obj = Resources.ResourceManager.GetObject("SettingsIcon", Resources.resourceCulture);
                return (Bitmap)obj;
            }
        }

        /// <summary>
        /// Gets the ThemeSettingsIcon
        /// </summary>
        internal static Bitmap ThemeSettingsIcon
        {
            get
            {
                object obj = Resources.ResourceManager.GetObject("ThemeSettingsIcon", Resources.resourceCulture);
                return (Bitmap)obj;
            }
        }
    }
}