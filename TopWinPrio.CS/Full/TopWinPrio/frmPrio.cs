using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Root;
using TopWinPrio.Properties;

namespace TopWinPrio
{

    public class frmPrio : System.Windows.Forms.Form
    {

        private class ProcessData
        {

            public System.Diagnostics.ProcessPriorityClass lastPrio;
            public int processID;

            public ProcessData()
            {
            }

        } // class ProcessData

        private string assemblyLocation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox chkAutostart;
        private System.Windows.Forms.CheckBox chkExplorer;
        private System.Windows.Forms.CheckBox chkShowBallonAtStart;
        private System.Windows.Forms.CheckBox chkShowBalloonWhenHidden;
        private System.Windows.Forms.CheckBox chkStartHidden;
        private System.Windows.Forms.ColumnHeader clmTime;
        private System.Windows.Forms.ColumnHeader clmWindow;
        private System.Windows.Forms.ComboBox cmbDefaultAppPrio;
        private System.Windows.Forms.ComboBox cmbResetPrio;
        private System.Windows.Forms.ComboBox cmbSetPrio;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.HScrollBar hsbTimer;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private bool isFirstRun;
        private string keyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private int lastHandle;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.ListView listView1;
        private TopWinPrio.frmPrio.ProcessData oldProc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPrio;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Timer timerTopWindowCheck;
        private System.Windows.Forms.NotifyIcon trayIcon;

        public frmPrio()
        {
            oldProc = new TopWinPrio.frmPrio.ProcessData();
            isFirstRun = true;
            keyName = "LunaWorX.net TopWinPrio";
            assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Visible = false;
            trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            trayIcon.BalloonTipText = "The program is running in the background";
            trayIcon.BalloonTipTitle = "LunaWorX.net TopWinPrio";
            trayIcon.ShowBalloonTip(3000);
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void chkAutostart_CheckedChanged(object sender, System.EventArgs e)
        {
            if (Root.Util.IsAutoStartEnabled(keyName, assemblyLocation))
            {
                Root.Util.UnSetAutoStart(keyName);
                return;
            }
            Root.Util.SetAutoStart(keyName, assemblyLocation);
        }

        private void cmbResetPrio_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        private void frmPrio_Activated(object sender, System.EventArgs e)
        {
            if (isFirstRun)
            {
                isFirstRun = false;
                Visible = !chkStartHidden.Checked;
                if (!Visible)
                {
                    ClientSize = new System.Drawing.Size(0, 0);
                    int i1 = Top;
                    int i2 = Left;
                    Top = -100;
                    Left = -100;
                    trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                    trayIcon.BalloonTipText = "The program is running in the background";
                    trayIcon.BalloonTipTitle = "LunaWorX.net TopWinPrio";
                    trayIcon.ShowBalloonTip(3000);
                    System.Diagnostics.ProcessPriorityClass processPriorityClass = (System.Diagnostics.ProcessPriorityClass)System.Enum.Parse(typeof(System.Diagnostics.ProcessPriorityClass), cmbDefaultAppPrio.Text);
                    System.Diagnostics.Process.GetCurrentProcess().PriorityClass = processPriorityClass;
                    ClientSize = new System.Drawing.Size(310, 396);
                    Top = i1;
                    Left = i2;
                }
            }
        }

        private void frmPrio_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            TopWinPrio.Properties.Settings.Default.BoostExplorer = chkExplorer.Checked;
            TopWinPrio.Properties.Settings.Default.RefreshTime = hsbTimer.Value;
            TopWinPrio.Properties.Settings.Default.InactiveWinPrio = cmbResetPrio.SelectedIndex;
            TopWinPrio.Properties.Settings.Default.ActiveWinPrio = cmbSetPrio.SelectedIndex;
            TopWinPrio.Properties.Settings.Default.BalloonHidden = chkShowBalloonWhenHidden.Checked;
            TopWinPrio.Properties.Settings.Default.BalloonStart = chkShowBallonAtStart.Checked;
            TopWinPrio.Properties.Settings.Default.StartHidden = chkStartHidden.Checked;
            TopWinPrio.Properties.Settings.Default.ApplicationPrio = cmbDefaultAppPrio.SelectedIndex;
            TopWinPrio.Properties.Settings.Default.Save();
            SetProcessPrio(oldProc, oldProc.lastPrio);
        }

        private void frmPrio_Load(object sender, System.EventArgs e)
        {
            chkExplorer.Checked = TopWinPrio.Properties.Settings.Default.BoostExplorer;
            hsbTimer.Value = TopWinPrio.Properties.Settings.Default.RefreshTime;
            cmbResetPrio.SelectedIndex = TopWinPrio.Properties.Settings.Default.InactiveWinPrio;
            cmbSetPrio.SelectedIndex = TopWinPrio.Properties.Settings.Default.ActiveWinPrio;
            chkStartHidden.Checked = TopWinPrio.Properties.Settings.Default.StartHidden;
            chkShowBallonAtStart.Checked = TopWinPrio.Properties.Settings.Default.BalloonStart;
            chkShowBalloonWhenHidden.Checked = TopWinPrio.Properties.Settings.Default.BalloonHidden;
            cmbDefaultAppPrio.SelectedIndex = TopWinPrio.Properties.Settings.Default.ApplicationPrio;
            chkAutostart.Checked = Root.Util.IsAutoStartEnabled(keyName, assemblyLocation);
            hsbTimer_Scroll(null, null);
        }

        private void hsbTimer_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            int i = hsbTimer.Value;
            lbTimer.Text = "Refresh every " + i.ToString() + " secs";
            timerTopWindowCheck.Interval = i * 1000;
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(TopWinPrio.frmPrio));
            timerTopWindowCheck = new System.Windows.Forms.Timer(components);
            btnClose = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPrio = new System.Windows.Forms.TabPage();
            listView1 = new System.Windows.Forms.ListView();
            clmTime = new System.Windows.Forms.ColumnHeader();
            clmWindow = new System.Windows.Forms.ColumnHeader();
            label1 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            tabSettings = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            cmbResetPrio = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cmbSetPrio = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            hsbTimer = new System.Windows.Forms.HScrollBar();
            lbTimer = new System.Windows.Forms.Label();
            chkExplorer = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            tabPage1 = new System.Windows.Forms.TabPage();
            groupBox2 = new System.Windows.Forms.GroupBox();
            cmbDefaultAppPrio = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            chkStartHidden = new System.Windows.Forms.CheckBox();
            chkShowBallonAtStart = new System.Windows.Forms.CheckBox();
            chkShowBalloonWhenHidden = new System.Windows.Forms.CheckBox();
            chkAutostart = new System.Windows.Forms.CheckBox();
            label8 = new System.Windows.Forms.Label();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            trayIcon = new System.Windows.Forms.NotifyIcon(components);
            checkBox5 = new System.Windows.Forms.CheckBox();
            checkBox6 = new System.Windows.Forms.CheckBox();
            checkBox7 = new System.Windows.Forms.CheckBox();
            checkBox8 = new System.Windows.Forms.CheckBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            comboBox2 = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            hScrollBar1 = new System.Windows.Forms.HScrollBar();
            label7 = new System.Windows.Forms.Label();
            checkBox9 = new System.Windows.Forms.CheckBox();
            tabControl1.SuspendLayout();
            tabPrio.SuspendLayout();
            pictureBox1.BeginInit();
            tabSettings.SuspendLayout();
            groupBox1.SuspendLayout();
            pictureBox2.BeginInit();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            pictureBox3.BeginInit();
            SuspendLayout();
            timerTopWindowCheck.Enabled = true;
            timerTopWindowCheck.Interval = 1000;
            timerTopWindowCheck.Tick += new System.EventHandler(timerTopWindowCheck_Tick);
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(231, 370);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(btnClose_Click);
            btnExit.Location = new System.Drawing.Point(4, 370);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(75, 23);
            btnExit.TabIndex = 0;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += new System.EventHandler(btnExit_Click);
            tabControl1.Controls.Add(tabPrio);
            tabControl1.Controls.Add(tabSettings);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(310, 364);
            tabControl1.TabIndex = 0;
            tabPrio.Controls.Add(listView1);
            tabPrio.Controls.Add(label1);
            tabPrio.Controls.Add(pictureBox1);
            tabPrio.Location = new System.Drawing.Point(4, 22);
            tabPrio.Name = "tabPrio";
            tabPrio.Padding = new System.Windows.Forms.Padding(3);
            tabPrio.Size = new System.Drawing.Size(302, 338);
            tabPrio.TabIndex = 0;
            tabPrio.Text = "Priolist";
            tabPrio.UseVisualStyleBackColor = true;
            System.Windows.Forms.ColumnHeader[] columnHeaderArr = new System.Windows.Forms.ColumnHeader[] {
                                                                                                            clmTime, 
                                                                                                            clmWindow };
            listView1.Columns.AddRange(columnHeaderArr);
            listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            listView1.Location = new System.Drawing.Point(3, 80);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(296, 255);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            clmTime.Text = "Time";
            clmTime.Width = 48;
            clmWindow.Text = "Window title";
            clmWindow.Width = 242;
            label1.Location = new System.Drawing.Point(77, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(217, 49);
            label1.TabIndex = 0;
            label1.Text = "List of applications boosted with higher prio, when having focus.";
            pictureBox1.Image = TopWinPrio.Properties.Resources.GameIcon;
            pictureBox1.Location = new System.Drawing.Point(8, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(64, 64);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            tabSettings.Controls.Add(groupBox1);
            tabSettings.Controls.Add(label2);
            tabSettings.Controls.Add(pictureBox2);
            tabSettings.Location = new System.Drawing.Point(4, 22);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new System.Windows.Forms.Padding(3);
            tabSettings.Size = new System.Drawing.Size(302, 338);
            tabSettings.TabIndex = 1;
            tabSettings.Text = "Boost settings";
            tabSettings.UseVisualStyleBackColor = true;
            groupBox1.Controls.Add(cmbResetPrio);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbSetPrio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(hsbTimer);
            groupBox1.Controls.Add(lbTimer);
            groupBox1.Controls.Add(chkExplorer);
            groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(9, 87);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(285, 245);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Boost settings";
            cmbResetPrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbResetPrio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbResetPrio.FormattingEnabled = true;
            object[] objArr1 = new object[] {
                                              "Default", 
                                              "Normal", 
                                              "BelowNormal", 
                                              "Idle (not a good idea)" };
            cmbResetPrio.Items.AddRange(objArr1);
            cmbResetPrio.Location = new System.Drawing.Point(134, 95);
            cmbResetPrio.Name = "cmbResetPrio";
            cmbResetPrio.Size = new System.Drawing.Size(143, 21);
            cmbResetPrio.TabIndex = 6;
            cmbResetPrio.SelectedIndexChanged += new System.EventHandler(cmbResetPrio_SelectedIndexChanged);
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(3, 98);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(125, 13);
            label4.TabIndex = 5;
            label4.Text = "Force inactive window to";
            cmbSetPrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSetPrio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbSetPrio.FormattingEnabled = true;
            object[] objArr2 = new object[] {
                                              "AboveNormal", 
                                              "High", 
                                              "RealTime (dangerous)" };
            cmbSetPrio.Items.AddRange(objArr2);
            cmbSetPrio.Location = new System.Drawing.Point(134, 68);
            cmbSetPrio.Name = "cmbSetPrio";
            cmbSetPrio.Size = new System.Drawing.Size(143, 21);
            cmbSetPrio.TabIndex = 4;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(3, 71);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 3;
            label3.Text = "Set active window to";
            hsbTimer.Location = new System.Drawing.Point(119, 39);
            hsbTimer.Maximum = 69;
            hsbTimer.Minimum = 1;
            hsbTimer.Name = "hsbTimer";
            hsbTimer.Size = new System.Drawing.Size(163, 17);
            hsbTimer.TabIndex = 2;
            hsbTimer.TabStop = true;
            hsbTimer.Value = 1;
            hsbTimer.Scroll += new System.Windows.Forms.ScrollEventHandler(hsbTimer_Scroll);
            lbTimer.AutoSize = true;
            lbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbTimer.Location = new System.Drawing.Point(3, 43);
            lbTimer.Name = "lbTimer";
            lbTimer.Size = new System.Drawing.Size(110, 13);
            lbTimer.TabIndex = 1;
            lbTimer.Text = "Refresh every 5 secs.";
            chkExplorer.AutoSize = true;
            chkExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkExplorer.Location = new System.Drawing.Point(6, 19);
            chkExplorer.Name = "chkExplorer";
            chkExplorer.Size = new System.Drawing.Size(93, 17);
            chkExplorer.TabIndex = 0;
            chkExplorer.Text = "Boost explorer";
            chkExplorer.UseVisualStyleBackColor = true;
            label2.Location = new System.Drawing.Point(77, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(194, 64);
            label2.TabIndex = 0;
            label2.Text = "Boost settings:\r\nHere you can configure \r\nhow the program will boost \r\nyour applications.\r\n";
            pictureBox2.Image = TopWinPrio.Properties.Resources.ThemeSettingsIcon;
            pictureBox2.Location = new System.Drawing.Point(8, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(64, 64);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(pictureBox3);
            tabPage1.Location = new System.Drawing.Point(4, 22);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new System.Drawing.Size(302, 338);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Application settings";
            tabPage1.UseVisualStyleBackColor = true;
            groupBox2.Controls.Add(cmbDefaultAppPrio);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(chkStartHidden);
            groupBox2.Controls.Add(chkShowBallonAtStart);
            groupBox2.Controls.Add(chkShowBalloonWhenHidden);
            groupBox2.Controls.Add(chkAutostart);
            groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox2.Location = new System.Drawing.Point(9, 88);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(285, 231);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Application settings";
            cmbDefaultAppPrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDefaultAppPrio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbDefaultAppPrio.FormattingEnabled = true;
            object[] objArr3 = new object[] {
                                              "Normal", 
                                              "BelowNormal" };
            cmbDefaultAppPrio.Items.AddRange(objArr3);
            cmbDefaultAppPrio.Location = new System.Drawing.Point(136, 109);
            cmbDefaultAppPrio.Name = "cmbDefaultAppPrio";
            cmbDefaultAppPrio.Size = new System.Drawing.Size(143, 21);
            cmbDefaultAppPrio.TabIndex = 8;
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(5, 112);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(92, 13);
            label9.TabIndex = 7;
            label9.Text = "Application priority";
            chkStartHidden.AutoSize = true;
            chkStartHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkStartHidden.Location = new System.Drawing.Point(6, 42);
            chkStartHidden.Name = "chkStartHidden";
            chkStartHidden.Size = new System.Drawing.Size(83, 17);
            chkStartHidden.TabIndex = 1;
            chkStartHidden.Text = "Start hidden";
            chkStartHidden.UseVisualStyleBackColor = true;
            chkShowBallonAtStart.AutoSize = true;
            chkShowBallonAtStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkShowBallonAtStart.Location = new System.Drawing.Point(22, 65);
            chkShowBallonAtStart.Name = "chkShowBallonAtStart";
            chkShowBallonAtStart.Size = new System.Drawing.Size(125, 17);
            chkShowBallonAtStart.TabIndex = 2;
            chkShowBallonAtStart.Text = "Show balloon at start";
            chkShowBallonAtStart.UseVisualStyleBackColor = true;
            chkShowBalloonWhenHidden.AutoSize = true;
            chkShowBalloonWhenHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkShowBalloonWhenHidden.Location = new System.Drawing.Point(6, 88);
            chkShowBalloonWhenHidden.Name = "chkShowBalloonWhenHidden";
            chkShowBalloonWhenHidden.Size = new System.Drawing.Size(154, 17);
            chkShowBalloonWhenHidden.TabIndex = 3;
            chkShowBalloonWhenHidden.Text = "Show balloon when hidden";
            chkShowBalloonWhenHidden.UseVisualStyleBackColor = true;
            chkAutostart.AutoSize = true;
            chkAutostart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkAutostart.Location = new System.Drawing.Point(6, 18);
            chkAutostart.Name = "chkAutostart";
            chkAutostart.Size = new System.Drawing.Size(114, 17);
            chkAutostart.TabIndex = 0;
            chkAutostart.Text = "Start with windows";
            chkAutostart.UseVisualStyleBackColor = true;
            chkAutostart.CheckedChanged += new System.EventHandler(chkAutostart_CheckedChanged);
            label8.Location = new System.Drawing.Point(77, 16);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(194, 64);
            label8.TabIndex = 0;
            label8.Text = "Application settings:\r\nHere you can configure \r\nhow the program will behave.";
            pictureBox3.Image = TopWinPrio.Properties.Resources.SettingsIcon;
            pictureBox3.Location = new System.Drawing.Point(8, 16);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(64, 64);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            trayIcon.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("trayIcon.Icon");
            trayIcon.Text = "LunaWorX.net TopWinPrio";
            trayIcon.Visible = true;
            trayIcon.BalloonTipClicked += new System.EventHandler(trayIcon_BalloonTipClicked);
            trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(trayIcon_MouseClick);
            checkBox5.AutoSize = true;
            checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox5.Location = new System.Drawing.Point(137, 19);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new System.Drawing.Size(83, 17);
            checkBox5.TabIndex = 9;
            checkBox5.Text = "Start hidden";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox6.AutoSize = true;
            checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox6.Location = new System.Drawing.Point(137, 38);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new System.Drawing.Size(125, 17);
            checkBox6.TabIndex = 8;
            checkBox6.Text = "Show balloon at start";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox7.AutoSize = true;
            checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox7.Location = new System.Drawing.Point(6, 38);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new System.Drawing.Size(154, 17);
            checkBox7.TabIndex = 7;
            checkBox7.Text = "Show balloon when hidden";
            checkBox7.UseVisualStyleBackColor = true;
            checkBox8.AutoSize = true;
            checkBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox8.Location = new System.Drawing.Point(7, 19);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new System.Drawing.Size(114, 17);
            checkBox8.TabIndex = 6;
            checkBox8.Text = "Start with windows";
            checkBox8.UseVisualStyleBackColor = true;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            object[] objArr4 = new object[] {
                                              "Default", 
                                              "Normal", 
                                              "BelowNormal", 
                                              "Idle (not a good idea)" };
            comboBox1.Items.AddRange(objArr4);
            comboBox1.Location = new System.Drawing.Point(134, 95);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(143, 21);
            comboBox1.TabIndex = 11;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(3, 98);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(125, 13);
            label5.TabIndex = 10;
            label5.Text = "Force inactive window to";
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            object[] objArr5 = new object[] {
                                              "AboveNormal", 
                                              "High", 
                                              "RealTime (dangerous)" };
            comboBox2.Items.AddRange(objArr5);
            comboBox2.Location = new System.Drawing.Point(134, 68);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(143, 21);
            comboBox2.TabIndex = 9;
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(3, 71);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(106, 13);
            label6.TabIndex = 8;
            label6.Text = "Set active window to";
            hScrollBar1.Location = new System.Drawing.Point(119, 39);
            hScrollBar1.Maximum = 69;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new System.Drawing.Size(163, 17);
            hScrollBar1.TabIndex = 7;
            hScrollBar1.Value = 1;
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(3, 43);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(110, 13);
            label7.TabIndex = 6;
            label7.Text = "Refresh every 5 secs.";
            checkBox9.AutoSize = true;
            checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox9.Location = new System.Drawing.Point(6, 19);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new System.Drawing.Size(93, 17);
            checkBox9.TabIndex = 5;
            checkBox9.Text = "Boost explorer";
            checkBox9.UseVisualStyleBackColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new System.Drawing.Size(310, 396);
            ControlBox = false;
            Controls.Add(tabControl1);
            Controls.Add(btnExit);
            Controls.Add(btnClose);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            Name = "frmPrio";
            Text = "LunaWorX.net TopWinPrio";
            Load += new System.EventHandler(frmPrio_Load);
            Activated += new System.EventHandler(frmPrio_Activated);
            FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmPrio_FormClosed);
            tabControl1.ResumeLayout(false);
            tabPrio.ResumeLayout(false);
            tabPrio.PerformLayout();
            pictureBox1.EndInit();
            tabSettings.ResumeLayout(false);
            tabSettings.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pictureBox2.EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            pictureBox3.EndInit();
            ResumeLayout(false);
        }

        private bool SetProcessPrio(TopWinPrio.frmPrio.ProcessData theProc, System.Diagnostics.ProcessPriorityClass processPriorityClass)
        {
            bool flag2;
            System.Diagnostics.Process process;

            bool flag1 = false;
            try
            {
                process = System.Diagnostics.Process.GetProcessById(theProc.processID);
            }
            catch 
            {
                return false;
            }
            if (process == null)
                return false;
            try
            {
                process.PriorityClass = processPriorityClass;
                flag1 = true;
            }
            catch 
            {
            }
            return flag1;
        }

        private void timerTopWindowCheck_Tick(object sender, System.EventArgs e)
        {
            timerTopWindowCheck.Enabled = false;
            int i = TopWinPrio.WinAPI.GetTopWindowHandle;
            bool flag = false;
            if (i != lastHandle)
            {
                SetProcessPrio(oldProc, oldProc.lastPrio);
                lastHandle = i;
                System.Diagnostics.Process process = null;
                try
                {
                    process = System.Diagnostics.Process.GetProcessById(TopWinPrio.WinAPI.GetTopWindowProcessID);
                    flag = process != null;
                    if (flag)
                        flag = process.Id > 0;
                    if (flag && !chkExplorer.Checked)
                        flag = process.ProcessName != "explorer";
                    if (flag)
                        flag = process.Id != System.Diagnostics.Process.GetCurrentProcess().Id;
                }
                catch 
                {
                    flag = false;
                }
                if (flag)
                {
                    TopWinPrio.frmPrio.ProcessData processData1 = null;
                    try
                    {
                        TopWinPrio.frmPrio.ProcessData processData2 = new TopWinPrio.frmPrio.ProcessData();
                        processData2.processID = process.Id;
                        processData2.lastPrio = process.PriorityClass;
                        processData1 = processData2;
                    }
                    catch 
                    {
                    }
                    if (processData1 != null)
                    {
                        if (cmbResetPrio.Text != "Default")
                            processData1.lastPrio = (System.Diagnostics.ProcessPriorityClass)System.Enum.Parse(typeof(System.Diagnostics.ProcessPriorityClass), cmbResetPrio.Text);
                        System.Diagnostics.ProcessPriorityClass processPriorityClass = (System.Diagnostics.ProcessPriorityClass)System.Enum.Parse(typeof(System.Diagnostics.ProcessPriorityClass), cmbSetPrio.Text);
                        if (SetProcessPrio(processData1, processPriorityClass))
                        {
                            System.DateTime dateTime = System.DateTime.Now;
                            System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem(dateTime.ToShortTimeString());
                            string s = TopWinPrio.WinAPI.GetTopWindowText;
                            if (s == "")
                                s = process.ProcessName;
                            listViewItem.SubItems.Add(s);
                            listView1.Items.Insert(0, listViewItem);
                            if (listView1.Items.Count > 13)
                                listView1.Items.RemoveAt(13);
                        }
                        oldProc = processData1;
                    }
                }
            }
            timerTopWindowCheck.Enabled = true;
        }

        private void trayIcon_BalloonTipClicked(object sender, System.EventArgs e)
        {
            Visible = false;
            trayIcon_MouseClick(null, null);
        }

        private void trayIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Visible = !Visible;
            if (Visible)
            {
                TopMost = true;
                System.Windows.Forms.Application.DoEvents();
                TopMost = false;
                Focus();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

    } // class frmPrio

}

