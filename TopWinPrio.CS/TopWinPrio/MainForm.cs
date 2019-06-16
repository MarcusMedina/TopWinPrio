//----------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="MarcusMedinapro">
// Copyright (c) MarcusMedinaPro. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------------------------
// This file is subject to the terms and conditions defined in file 'license.txt', which is part of this project.
// For more information visit http://MarcusMedina.Pro
//----------------------------------------------------------------------------------------------------------------
#pragma warning disable CA1031 // Do not catch general exception types
#pragma warning disable IDE0003 // Remove qualification
#pragma warning disable IDE0007 // Use implicit type
#pragma warning disable RCS1032 // Remove redundant parentheses.
#pragma warning disable RCS1114 // Remove redundant delegate creation.
#pragma warning disable SA1013 // Closing braces should be spaced correctly
#pragma warning disable SA1028 // Code should not contain trailing whitespace
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1119 // Statement should not use unnecessary parenthesis
#pragma warning disable SA1120 // Comments should contain text
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
#pragma warning disable SA1629 // Documentation text should end with a period
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
#pragma warning disable SA1500 // Braces for multi-line statements should not share line

#pragma warning disable ET002

namespace TopWinPrio
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    using TopWinPrio.Properties;

    /// <summary>
    /// Defines the <see cref="MainForm"/>
    /// </summary>
    public class MainForm : Form
    {
        /// <summary>
        /// Defines the assemblyLocation
        /// </summary>
        private readonly string assemblyLocation;

        /// <summary>
        /// Defines the keyName
        /// </summary>
        private readonly string keyName;

        /// <summary>
        /// Defines the activeLabel
        /// </summary>
        private Label activeLabel;

        /// <summary>
        /// Defines the activeList
        /// </summary>
        private ComboBox activeList;

        /// <summary>
        /// Defines the allTabs
        /// </summary>
        private TabControl allTabs;

        /// <summary>
        /// Defines the applicationFrame
        /// </summary>
        private GroupBox applicationFrame;

        /// <summary>
        /// Defines the applicationInfo
        /// </summary>
        private Label applicationInfo;

        /// <summary>
        /// Defines the applicationPriorityLabel
        /// </summary>
        private Label applicationPriorityLabel;

        /// <summary>
        /// Defines the applicationPriorityList
        /// </summary>
        private ComboBox applicationPriorityList;

        /// <summary>
        /// Defines the applicationSettings
        /// </summary>
        private TabPage applicationSettings;

        /// <summary>
        /// Defines the autostartOption
        /// </summary>
        private CheckBox autostartOption;

        /// <summary>
        /// Defines the boostExplorerOption
        /// </summary>
        private CheckBox boostExplorerOption;

        /// <summary>
        /// Defines the boostFrame
        /// </summary>
        private GroupBox boostFrame;

        /// <summary>
        /// Defines the boostSettings
        /// </summary>
        private TabPage boostSettings;

        /// <summary>
        /// Defines the checkBox5
        /// </summary>
        private CheckBox checkBox5;

        /// <summary>
        /// Defines the checkBox6
        /// </summary>
        private CheckBox checkBox6;

        /// <summary>
        /// Defines the checkBox7
        /// </summary>
        private CheckBox checkBox7;

        /// <summary>
        /// Defines the checkBox8
        /// </summary>
        private CheckBox checkBox8;

        /// <summary>
        /// Defines the checkBox9
        /// </summary>
        private CheckBox checkBox9;

        /// <summary>
        /// Defines the clmTime
        /// </summary>
        private ColumnHeader clmTime;

        /// <summary>
        /// Defines the clmWindow
        /// </summary>
        private ColumnHeader clmWindow;

        /// <summary>
        /// Defines the closeButton
        /// </summary>
        private Button closeButton;

        /// <summary>
        /// Defines the comboBox1
        /// </summary>
        private ComboBox comboBox1;

        /// <summary>
        /// Defines the comboBox2
        /// </summary>
        private ComboBox comboBox2;

        /// <summary>
        /// Defines the components
        /// </summary>
        private IContainer components;

        /// <summary>
        /// Defines the exitButton
        /// </summary>
        private Button exitButton;

        /// <summary>
        /// Defines the hScrollBar1
        /// </summary>
        private HScrollBar hScrollBar1;

        /// <summary>
        /// Defines the inactiveLabel
        /// </summary>
        private Label inactiveLabel;

        /// <summary>
        /// Defines the inactiveList
        /// </summary>
        private ComboBox inactiveList;

        /// <summary>
        /// Defines the infoLabel
        /// </summary>
        private Label infoLabel;

        /// <summary>
        /// Defines the isFirstRun
        /// </summary>
        private bool isFirstRun;

        /// <summary>
        /// Defines the label5
        /// </summary>
        private Label label5;

        /// <summary>
        /// Defines the label6
        /// </summary>
        private Label label6;

        /// <summary>
        /// Defines the label7
        /// </summary>
        private Label label7;

        /// <summary>
        /// Defines the lastHandle
        /// </summary>
        private int lastHandle;

        /// <summary>
        /// Defines the logList
        /// </summary>
        private ListView logList;

        /// <summary>
        /// Defines the logoPic
        /// </summary>
        private PictureBox logoPic;

        /// <summary>
        /// Defines the oldProc
        /// </summary>
        private MainForm.ProcessData oldProc;

        /// <summary>
        /// Defines the prioList
        /// </summary>
        private TabPage prioList;

        /// <summary>
        /// Defines the refreshLabel
        /// </summary>
        private Label refreshLabel;

        /// <summary>
        /// Defines the settingsInfoText
        /// </summary>
        private Label settingsInfoText;

        /// <summary>
        /// Defines the settingsPic
        /// </summary>
        private PictureBox settingsPic;

        /// <summary>
        /// Defines the showPopupOption
        /// </summary>
        private CheckBox showPopupOption;

        /// <summary>
        /// Defines the startBalloonOption
        /// </summary>
        private CheckBox startBalloonOption;

        /// <summary>
        /// Defines the startHiddenOption
        /// </summary>
        private CheckBox startHiddenOption;

        /// <summary>
        /// Defines the timerSlider
        /// </summary>
        private HScrollBar timerSlider;

        /// <summary>
        /// Defines the timerTopWindowCheck
        /// </summary>
        private Timer timerTopWindowCheck;

        /// <summary>
        /// Defines the toolsPic
        /// </summary>
        private PictureBox toolsPic;

        /// <summary>
        /// Defines the trayIcon
        /// </summary>
        private NotifyIcon trayIcon;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            oldProc = new MainForm.ProcessData();
            isFirstRun = true;
            keyName = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
            assemblyLocation = Assembly.GetExecutingAssembly().Location;
            InitializeComponent();
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing <see cref="bool"/></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// The SetProcessPrio
        /// </summary>
        /// <param name="theProc">The theProc <see cref="MainForm.ProcessData"/></param>
        /// <param name="processPriorityClass">The processPriorityClass <see cref="ProcessPriorityClass"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private static bool SetProcessPrio(MainForm.ProcessData theProc, ProcessPriorityClass processPriorityClass)
        {
            Process process;

            var flag1 = false;
            try
            {
                process = Process.GetProcessById(theProc.ProcessID);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
#pragma warning restore CA1031 // Do not catch general exception types
            if (process == null)
            {
                return false;
            }

            try
            {
                process.PriorityClass = processPriorityClass;
                flag1 = true;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
#pragma warning restore CA1031 // Do not catch general exception types
            return flag1;
        }

        /// <summary>
        /// The BtnClose_Click
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="EventArgs"/></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.BalloonTipText = "The program is running in the background";
            trayIcon.BalloonTipTitle = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
            trayIcon.ShowBalloonTip(3000);
        }

        /// <summary>
        /// The BtnExit_Click
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="EventArgs"/></param>
        private void BtnExit_Click(object sender, EventArgs e) => Application.Exit();

        /// <summary>
        /// The ChkAutostart_CheckedChanged
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="EventArgs"/></param>
        private void ChkAutostart_CheckedChanged(object sender, EventArgs e)
        {
            if (RegistryTools.IsAutoStartEnabled(keyName, assemblyLocation))
            {
                RegistryTools.RemoveAutoStart(keyName);
                return;
            }

            RegistryTools.SetAutoStart(keyName, assemblyLocation);
        }

        /// <summary>
        /// The FrmPrio_Activated
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="EventArgs"/></param>
        private void FrmPrio_Activated(object sender, EventArgs e)
        {
            if (isFirstRun)
            {
                isFirstRun = false;
                Visible = !startHiddenOption.Checked;
                if (!Visible)
                {
                    ClientSize = new Size(0, 0);
                    var i1 = Top;
                    var i2 = Left;
                    Top = -100;
                    Left = -100;
                    trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                    trayIcon.BalloonTipText = "The program is running in the background";
                    trayIcon.BalloonTipTitle = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
                    trayIcon.ShowBalloonTip(3000);
                    var processPriorityClass = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), applicationPriorityList.Text);
                    Process.GetCurrentProcess().PriorityClass = processPriorityClass;
                    ClientSize = new Size(310, 396);
                    Top = i1;
                    Left = i2;
                }
            }
        }

        /// <summary>
        /// The FrmPrio_FormClosed
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="FormClosedEventArgs"/></param>
        private void FrmPrio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.BoostExplorer = boostExplorerOption.Checked;
            Settings.Default.RefreshTime = timerSlider.Value;
            Settings.Default.InactiveWinPrio = inactiveList.SelectedIndex;
            Settings.Default.ActiveWinPrio = activeList.SelectedIndex;
            Settings.Default.BalloonHidden = showPopupOption.Checked;
            Settings.Default.BalloonStart = startBalloonOption.Checked;
            Settings.Default.StartHidden = startHiddenOption.Checked;
            Settings.Default.ApplicationPrio = applicationPriorityList.SelectedIndex;
            Settings.Default.Save();
            SetProcessPrio(oldProc, oldProc.LastPrio);
        }

        /// <summary>
        /// The FrmPrio_Load
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="EventArgs"/></param>
        private void FrmPrio_Load(object sender, EventArgs e)
        {
            boostExplorerOption.Checked = Settings.Default.BoostExplorer;
            timerSlider.Value = Settings.Default.RefreshTime;
            inactiveList.SelectedIndex = Settings.Default.InactiveWinPrio;
            activeList.SelectedIndex = Settings.Default.ActiveWinPrio;
            startHiddenOption.Checked = Settings.Default.StartHidden;
            startBalloonOption.Checked = Settings.Default.BalloonStart;
            showPopupOption.Checked = Settings.Default.BalloonHidden;
            applicationPriorityList.SelectedIndex = Settings.Default.ApplicationPrio;
            autostartOption.Checked = RegistryTools.IsAutoStartEnabled(keyName, assemblyLocation);
            HsbTimer_Scroll(null, null);
        }

        /// <summary>
        /// The HsbTimer_Scroll
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="ScrollEventArgs"/></param>
        private void HsbTimer_Scroll(object sender, ScrollEventArgs e)
        {
            var i = timerSlider.Value;
            refreshLabel.Text = "Refresh every " + i.ToString(System.Globalization.CultureInfo.CurrentCulture) + " secs";
            timerTopWindowCheck.Interval = i * 1000;
        }

        /// <summary>
        /// The InitializeComponent
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerTopWindowCheck = new System.Windows.Forms.Timer(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.allTabs = new System.Windows.Forms.TabControl();
            this.prioList = new System.Windows.Forms.TabPage();
            this.logList = new System.Windows.Forms.ListView();
            this.clmTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmWindow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infoLabel = new System.Windows.Forms.Label();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.boostSettings = new System.Windows.Forms.TabPage();
            this.boostFrame = new System.Windows.Forms.GroupBox();
            this.inactiveList = new System.Windows.Forms.ComboBox();
            this.inactiveLabel = new System.Windows.Forms.Label();
            this.activeList = new System.Windows.Forms.ComboBox();
            this.activeLabel = new System.Windows.Forms.Label();
            this.timerSlider = new System.Windows.Forms.HScrollBar();
            this.refreshLabel = new System.Windows.Forms.Label();
            this.boostExplorerOption = new System.Windows.Forms.CheckBox();
            this.settingsInfoText = new System.Windows.Forms.Label();
            this.toolsPic = new System.Windows.Forms.PictureBox();
            this.applicationSettings = new System.Windows.Forms.TabPage();
            this.applicationFrame = new System.Windows.Forms.GroupBox();
            this.applicationPriorityList = new System.Windows.Forms.ComboBox();
            this.applicationPriorityLabel = new System.Windows.Forms.Label();
            this.startHiddenOption = new System.Windows.Forms.CheckBox();
            this.startBalloonOption = new System.Windows.Forms.CheckBox();
            this.showPopupOption = new System.Windows.Forms.CheckBox();
            this.autostartOption = new System.Windows.Forms.CheckBox();
            this.applicationInfo = new System.Windows.Forms.Label();
            this.settingsPic = new System.Windows.Forms.PictureBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.allTabs.SuspendLayout();
            this.prioList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.boostSettings.SuspendLayout();
            this.boostFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolsPic)).BeginInit();
            this.applicationSettings.SuspendLayout();
            this.applicationFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPic)).BeginInit();
            this.SuspendLayout();
            // 
            // timerTopWindowCheck
            // 
            this.timerTopWindowCheck.Enabled = true;
            this.timerTopWindowCheck.Interval = 1000;
            this.timerTopWindowCheck.Tick += new System.EventHandler(this.TimerTopWindowCheck_Tick);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(231, 370);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(4, 370);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "&Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // allTabs
            // 
            this.allTabs.Controls.Add(this.prioList);
            this.allTabs.Controls.Add(this.boostSettings);
            this.allTabs.Controls.Add(this.applicationSettings);
            this.allTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.allTabs.Location = new System.Drawing.Point(0, 0);
            this.allTabs.Name = "allTabs";
            this.allTabs.SelectedIndex = 0;
            this.allTabs.Size = new System.Drawing.Size(310, 364);
            this.allTabs.TabIndex = 0;
            // 
            // prioList
            // 
            this.prioList.Controls.Add(this.logList);
            this.prioList.Controls.Add(this.infoLabel);
            this.prioList.Controls.Add(this.logoPic);
            this.prioList.Location = new System.Drawing.Point(4, 22);
            this.prioList.Name = "prioList";
            this.prioList.Padding = new System.Windows.Forms.Padding(3);
            this.prioList.Size = new System.Drawing.Size(302, 338);
            this.prioList.TabIndex = 0;
            this.prioList.Text = "prioList";
            this.prioList.UseVisualStyleBackColor = true;
            // 
            // logList
            // 
            this.logList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmTime,
            this.clmWindow});
            this.logList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logList.Location = new System.Drawing.Point(3, 80);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(296, 255);
            this.logList.TabIndex = 0;
            this.logList.UseCompatibleStateImageBehavior = false;
            this.logList.View = System.Windows.Forms.View.Details;
            // 
            // clmTime
            // 
            this.clmTime.Text = "Time";
            this.clmTime.Width = 48;
            // 
            // clmWindow
            // 
            this.clmWindow.Text = "Window title";
            this.clmWindow.Width = 242;
            // 
            // infoLabel
            // 
            this.infoLabel.Location = new System.Drawing.Point(77, 16);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(217, 49);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "List of applications boosted with higher prio, when having focus.";
            // 
            // logoPic
            // 
            this.logoPic.Image = global::TopWinPrio.Properties.Resources.GameIcon;
            this.logoPic.Location = new System.Drawing.Point(8, 16);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(64, 64);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            // 
            // boostSettings
            // 
            this.boostSettings.Controls.Add(this.boostFrame);
            this.boostSettings.Controls.Add(this.settingsInfoText);
            this.boostSettings.Controls.Add(this.toolsPic);
            this.boostSettings.Location = new System.Drawing.Point(4, 22);
            this.boostSettings.Name = "boostSettings";
            this.boostSettings.Padding = new System.Windows.Forms.Padding(3);
            this.boostSettings.Size = new System.Drawing.Size(302, 338);
            this.boostSettings.TabIndex = 1;
            this.boostSettings.Text = "Boost settings";
            this.boostSettings.UseVisualStyleBackColor = true;
            // 
            // boostFrame
            // 
            this.boostFrame.Controls.Add(this.inactiveList);
            this.boostFrame.Controls.Add(this.inactiveLabel);
            this.boostFrame.Controls.Add(this.activeList);
            this.boostFrame.Controls.Add(this.activeLabel);
            this.boostFrame.Controls.Add(this.timerSlider);
            this.boostFrame.Controls.Add(this.refreshLabel);
            this.boostFrame.Controls.Add(this.boostExplorerOption);
            this.boostFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boostFrame.Location = new System.Drawing.Point(9, 87);
            this.boostFrame.Name = "boostFrame";
            this.boostFrame.Size = new System.Drawing.Size(285, 245);
            this.boostFrame.TabIndex = 1;
            this.boostFrame.TabStop = false;
            this.boostFrame.Text = "Boost settings";
            // 
            // inactiveList
            // 
            this.inactiveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inactiveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveList.FormattingEnabled = true;
            this.inactiveList.Items.AddRange(new object[] {
            "Default",
            "Normal",
            "BelowNormal",
            "Idle (not a good idea)"});
            this.inactiveList.Location = new System.Drawing.Point(134, 95);
            this.inactiveList.Name = "inactiveList";
            this.inactiveList.Size = new System.Drawing.Size(143, 21);
            this.inactiveList.TabIndex = 6;
            // 
            // inactiveLabel
            // 
            this.inactiveLabel.AutoSize = true;
            this.inactiveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveLabel.Location = new System.Drawing.Point(3, 98);
            this.inactiveLabel.Name = "inactiveLabel";
            this.inactiveLabel.Size = new System.Drawing.Size(125, 13);
            this.inactiveLabel.TabIndex = 5;
            this.inactiveLabel.Text = "Force inactive window to";
            // 
            // activeList
            // 
            this.activeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeList.FormattingEnabled = true;
            this.activeList.Items.AddRange(new object[] {
            "AboveNormal",
            "High",
            "RealTime (dangerous)"});
            this.activeList.Location = new System.Drawing.Point(134, 68);
            this.activeList.Name = "activeList";
            this.activeList.Size = new System.Drawing.Size(143, 21);
            this.activeList.TabIndex = 4;
            // 
            // activeLabel
            // 
            this.activeLabel.AutoSize = true;
            this.activeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeLabel.Location = new System.Drawing.Point(3, 71);
            this.activeLabel.Name = "activeLabel";
            this.activeLabel.Size = new System.Drawing.Size(106, 13);
            this.activeLabel.TabIndex = 3;
            this.activeLabel.Text = "Set active window to";
            // 
            // timerSlider
            // 
            this.timerSlider.Location = new System.Drawing.Point(119, 39);
            this.timerSlider.Maximum = 69;
            this.timerSlider.Minimum = 1;
            this.timerSlider.Name = "timerSlider";
            this.timerSlider.Size = new System.Drawing.Size(163, 17);
            this.timerSlider.TabIndex = 2;
            this.timerSlider.TabStop = true;
            this.timerSlider.Value = 1;
            // 
            // refreshLabel
            // 
            this.refreshLabel.AutoSize = true;
            this.refreshLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshLabel.Location = new System.Drawing.Point(3, 43);
            this.refreshLabel.Name = "refreshLabel";
            this.refreshLabel.Size = new System.Drawing.Size(110, 13);
            this.refreshLabel.TabIndex = 1;
            this.refreshLabel.Text = "Refresh every 5 secs.";
            // 
            // boostExplorerOption
            // 
            this.boostExplorerOption.AutoSize = true;
            this.boostExplorerOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boostExplorerOption.Location = new System.Drawing.Point(6, 19);
            this.boostExplorerOption.Name = "boostExplorerOption";
            this.boostExplorerOption.Size = new System.Drawing.Size(93, 17);
            this.boostExplorerOption.TabIndex = 0;
            this.boostExplorerOption.Text = "Boost explorer";
            this.boostExplorerOption.UseVisualStyleBackColor = true;
            // 
            // settingsInfoText
            // 
            this.settingsInfoText.Location = new System.Drawing.Point(77, 16);
            this.settingsInfoText.Name = "settingsInfoText";
            this.settingsInfoText.Size = new System.Drawing.Size(194, 64);
            this.settingsInfoText.TabIndex = 0;
            this.settingsInfoText.Text = "Boost settings:\r\nHere you can configure \r\nhow the program will boost \r\nyour appli" +
    "cations.\r\n";
            // 
            // toolsPic
            // 
            this.toolsPic.Image = global::TopWinPrio.Properties.Resources.ThemeSettingsIcon;
            this.toolsPic.Location = new System.Drawing.Point(8, 16);
            this.toolsPic.Name = "toolsPic";
            this.toolsPic.Size = new System.Drawing.Size(64, 64);
            this.toolsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.toolsPic.TabIndex = 2;
            this.toolsPic.TabStop = false;
            // 
            // applicationSettings
            // 
            this.applicationSettings.Controls.Add(this.applicationFrame);
            this.applicationSettings.Controls.Add(this.applicationInfo);
            this.applicationSettings.Controls.Add(this.settingsPic);
            this.applicationSettings.Location = new System.Drawing.Point(4, 22);
            this.applicationSettings.Name = "applicationSettings";
            this.applicationSettings.Size = new System.Drawing.Size(302, 338);
            this.applicationSettings.TabIndex = 2;
            this.applicationSettings.Text = "Application settings";
            this.applicationSettings.UseVisualStyleBackColor = true;
            // 
            // applicationFrame
            // 
            this.applicationFrame.Controls.Add(this.applicationPriorityList);
            this.applicationFrame.Controls.Add(this.applicationPriorityLabel);
            this.applicationFrame.Controls.Add(this.startHiddenOption);
            this.applicationFrame.Controls.Add(this.startBalloonOption);
            this.applicationFrame.Controls.Add(this.showPopupOption);
            this.applicationFrame.Controls.Add(this.autostartOption);
            this.applicationFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationFrame.Location = new System.Drawing.Point(9, 88);
            this.applicationFrame.Name = "applicationFrame";
            this.applicationFrame.Size = new System.Drawing.Size(285, 231);
            this.applicationFrame.TabIndex = 1;
            this.applicationFrame.TabStop = false;
            this.applicationFrame.Text = "Application settings";
            // 
            // applicationPriorityList
            // 
            this.applicationPriorityList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.applicationPriorityList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationPriorityList.FormattingEnabled = true;
            this.applicationPriorityList.Items.AddRange(new object[] {
            "Normal",
            "BelowNormal"});
            this.applicationPriorityList.Location = new System.Drawing.Point(136, 109);
            this.applicationPriorityList.Name = "applicationPriorityList";
            this.applicationPriorityList.Size = new System.Drawing.Size(143, 21);
            this.applicationPriorityList.TabIndex = 8;
            // 
            // applicationPriorityLabel
            // 
            this.applicationPriorityLabel.AutoSize = true;
            this.applicationPriorityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationPriorityLabel.Location = new System.Drawing.Point(5, 112);
            this.applicationPriorityLabel.Name = "applicationPriorityLabel";
            this.applicationPriorityLabel.Size = new System.Drawing.Size(92, 13);
            this.applicationPriorityLabel.TabIndex = 7;
            this.applicationPriorityLabel.Text = "Application priority";
            // 
            // startHiddenOption
            // 
            this.startHiddenOption.AutoSize = true;
            this.startHiddenOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startHiddenOption.Location = new System.Drawing.Point(6, 42);
            this.startHiddenOption.Name = "startHiddenOption";
            this.startHiddenOption.Size = new System.Drawing.Size(83, 17);
            this.startHiddenOption.TabIndex = 1;
            this.startHiddenOption.Text = "Start hidden";
            this.startHiddenOption.UseVisualStyleBackColor = true;
            // 
            // startBalloonOption
            // 
            this.startBalloonOption.AutoSize = true;
            this.startBalloonOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBalloonOption.Location = new System.Drawing.Point(22, 65);
            this.startBalloonOption.Name = "startBalloonOption";
            this.startBalloonOption.Size = new System.Drawing.Size(125, 17);
            this.startBalloonOption.TabIndex = 2;
            this.startBalloonOption.Text = "Show balloon at start";
            this.startBalloonOption.UseVisualStyleBackColor = true;
            // 
            // showPopupOption
            // 
            this.showPopupOption.AutoSize = true;
            this.showPopupOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPopupOption.Location = new System.Drawing.Point(6, 88);
            this.showPopupOption.Name = "showPopupOption";
            this.showPopupOption.Size = new System.Drawing.Size(154, 17);
            this.showPopupOption.TabIndex = 3;
            this.showPopupOption.Text = "Show balloon when hidden";
            this.showPopupOption.UseVisualStyleBackColor = true;
            // 
            // autostartOption
            // 
            this.autostartOption.AutoSize = true;
            this.autostartOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autostartOption.Location = new System.Drawing.Point(6, 18);
            this.autostartOption.Name = "autostartOption";
            this.autostartOption.Size = new System.Drawing.Size(114, 17);
            this.autostartOption.TabIndex = 0;
            this.autostartOption.Text = "Start with windows";
            this.autostartOption.UseVisualStyleBackColor = true;
            this.autostartOption.CheckedChanged += new System.EventHandler(this.ChkAutostart_CheckedChanged);
            // 
            // applicationInfo
            // 
            this.applicationInfo.Location = new System.Drawing.Point(77, 16);
            this.applicationInfo.Name = "applicationInfo";
            this.applicationInfo.Size = new System.Drawing.Size(194, 64);
            this.applicationInfo.TabIndex = 0;
            this.applicationInfo.Text = "Application settings:\r\nHere you can configure \r\nhow the program will behave.";
            // 
            // settingsPic
            // 
            this.settingsPic.Image = global::TopWinPrio.Properties.Resources.SettingsIcon;
            this.settingsPic.Location = new System.Drawing.Point(8, 16);
            this.settingsPic.Name = "settingsPic";
            this.settingsPic.Size = new System.Drawing.Size(64, 64);
            this.settingsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.settingsPic.TabIndex = 6;
            this.settingsPic.TabStop = false;
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
            this.trayIcon.Visible = true;
            this.trayIcon.BalloonTipClicked += new System.EventHandler(this.TrayIcon_BalloonTipClicked);
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.Location = new System.Drawing.Point(137, 19);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(83, 17);
            this.checkBox5.TabIndex = 9;
            this.checkBox5.Text = "Start hidden";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.Location = new System.Drawing.Point(137, 38);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(125, 17);
            this.checkBox6.TabIndex = 8;
            this.checkBox6.Text = "Show balloon at start";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox7.Location = new System.Drawing.Point(6, 38);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(154, 17);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.Text = "Show balloon when hidden";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox8.Location = new System.Drawing.Point(7, 19);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(114, 17);
            this.checkBox8.TabIndex = 6;
            this.checkBox8.Text = "Start with windows";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Default",
            "Normal",
            "BelowNormal",
            "Idle (not a good idea)"});
            this.comboBox1.Location = new System.Drawing.Point(134, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(143, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Force inactive window to";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "AboveNormal",
            "High",
            "RealTime (dangerous)"});
            this.comboBox2.Location = new System.Drawing.Point(134, 68);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(143, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Set active window to";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(119, 39);
            this.hScrollBar1.Maximum = 69;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(163, 17);
            this.hScrollBar1.TabIndex = 7;
            this.hScrollBar1.Value = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Refresh every 5 secs.";
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox9.Location = new System.Drawing.Point(6, 19);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(93, 17);
            this.checkBox9.TabIndex = 5;
            this.checkBox9.Text = "Boost explorer";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(310, 396);
            this.ControlBox = false;
            this.Controls.Add(this.allTabs);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "MarcusMedinaPro (formerly LunaWorX.net) TopWinPrio";
            this.Activated += new System.EventHandler(this.FrmPrio_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrio_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrio_Load);
            this.allTabs.ResumeLayout(false);
            this.prioList.ResumeLayout(false);
            this.prioList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.boostSettings.ResumeLayout(false);
            this.boostSettings.PerformLayout();
            this.boostFrame.ResumeLayout(false);
            this.boostFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolsPic)).EndInit();
            this.applicationSettings.ResumeLayout(false);
            this.applicationSettings.PerformLayout();
            this.applicationFrame.ResumeLayout(false);
            this.applicationFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPic)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// The TimerTopWindowCheck_Tick
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="EventArgs"/></param>
        private void TimerTopWindowCheck_Tick(object sender, EventArgs e)
        {
            timerTopWindowCheck.Enabled = false;
            var i = NativeMethods.GetTopWindowHandle;
            if (i != lastHandle)
            {
                SetProcessPrio(oldProc, oldProc.LastPrio);
                lastHandle = i;
                var process = Process.GetProcessById(NativeMethods.GetTopWindowProcessID);
                var flag = process != null;
                if (flag)
                {
                    flag = process.Id > 0;
                }

                if (flag && !boostExplorerOption.Checked)
                {
                    flag = process.ProcessName != "explorer";
                }

                if (flag)
                {
                    flag = process.Id != Process.GetCurrentProcess().Id;
                }

                if (flag)
                {
                    MainForm.ProcessData processData1 = null;
                    try
                    {
                        var processData2 = new MainForm.ProcessData
                        {
                            ProcessID = process.Id,
                            LastPrio = process.PriorityClass,
                        };
                        processData1 = processData2;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                    // if (processData1 != null) // Testing to see if the If is necessary.
                    {
                        if (inactiveList.Text != "Default")
                        {
                            processData1.LastPrio = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), inactiveList.Text);
                        }

                        var processPriorityClass = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), activeList.Text);
                        if (SetProcessPrio(processData1, processPriorityClass))
                        {
                            var dateTime = DateTime.Now;
                            var listViewItem = new ListViewItem(dateTime.ToShortTimeString());
                            var s = NativeMethods.GetTopWindowText;
                            if (s?.Length == 0)
                            {
                                s = process.ProcessName;
                            }

                            listViewItem.SubItems.Add(s);
                            logList.Items.Insert(0, listViewItem);
                            if (logList.Items.Count > 13)
                            {
                                logList.Items.RemoveAt(13);
                            }
                        }

                        oldProc = processData1;
                    }
                }
            }

            timerTopWindowCheck.Enabled = true;
        }

        /// <summary>
        /// The TrayIcon_BalloonTipClicked
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="EventArgs"/></param>
        private void TrayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Visible = false;
            TrayIcon_MouseClick(null, null);
        }

        /// <summary>
        /// The TrayIcon_MouseClick
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="e">The e <see cref="MouseEventArgs"/></param>
        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Visible = !Visible;
            if (Visible)
            {
                TopMost = true;
                Application.DoEvents();
                TopMost = false;
                Focus();
            }
        }

        /// <summary>
        /// Defines the <see cref="ProcessData"/>.
        /// </summary>
        private class ProcessData
        {
            /// <summary>
            /// Gets or sets the LastPrio Gets or sets LastPrio.
            /// </summary>
            public ProcessPriorityClass LastPrio { get; set; }

            /// <summary>
            /// Gets or sets the ProcessID
            /// </summary>
            public int ProcessID { get; set; }
        }
    }
}

#pragma warning restore CA1031 // Do not catch general exception types
#pragma warning restore IDE0003 // Remove qualification
#pragma warning restore IDE0007 // Use implicit type
#pragma warning restore RCS1032 // Remove redundant parentheses.
#pragma warning restore RCS1114 // Remove redundant delegate creation.
#pragma warning restore SA1013 // Closing braces should be spaced correctly
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1119 // Statement should not use unnecessary parenthesis
#pragma warning restore SA1120 // Comments should contain text
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
#pragma warning restore SA1500 // Braces for multi-line statements should not share line
