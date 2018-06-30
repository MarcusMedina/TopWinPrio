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

    public class frmPrio : Form
    {

        private class ProcessData
        {

            public ProcessPriorityClass lastPrio;
            public int processID;

            public ProcessData()
            {
            }

        } // class ProcessData

        private string assemblyLocation;
        private Button btnClose;
        private Button btnExit;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckBox chkAutostart;
        private CheckBox chkExplorer;
        private CheckBox chkShowBallonAtStart;
        private CheckBox chkShowBalloonWhenHidden;
        private CheckBox chkStartHidden;
        private ColumnHeader clmTime;
        private ColumnHeader clmWindow;
        private ComboBox cmbDefaultAppPrio;
        private ComboBox cmbResetPrio;
        private ComboBox cmbSetPrio;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private HScrollBar hsbTimer;
        private HScrollBar hScrollBar1;
        private bool isFirstRun;
        private string keyName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private int lastHandle;
        private Label lbTimer;
        private ListView listView1;
        private frmPrio.ProcessData oldProc;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPrio;
        private TabPage tabSettings;
        private Timer timerTopWindowCheck;
        private NotifyIcon trayIcon;

        public frmPrio()
        {
            oldProc = new frmPrio.ProcessData();
            isFirstRun = true;
            keyName = "LunaWorX.net TopWinPrio";
            assemblyLocation = Assembly.GetExecutingAssembly().Location;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.BalloonTipText = "The program is running in the background";
            trayIcon.BalloonTipTitle = "LunaWorX.net TopWinPrio";
            trayIcon.ShowBalloonTip(3000);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkAutostart_CheckedChanged(object sender, EventArgs e)
        {
            if (Util.IsAutoStartEnabled(keyName, assemblyLocation))
            {
                Util.UnSetAutoStart(keyName);
                return;
            }
            Util.SetAutoStart(keyName, assemblyLocation);
        }

        private void cmbResetPrio_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void frmPrio_Activated(object sender, EventArgs e)
        {
            if (isFirstRun)
            {
                isFirstRun = false;
                Visible = !chkStartHidden.Checked;
                if (!Visible)
                {
                    ClientSize = new Size(0, 0);
                    int i1 = Top;
                    int i2 = Left;
                    Top = -100;
                    Left = -100;
                    trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                    trayIcon.BalloonTipText = "The program is running in the background";
                    trayIcon.BalloonTipTitle = "LunaWorX.net TopWinPrio";
                    trayIcon.ShowBalloonTip(3000);
                    ProcessPriorityClass processPriorityClass = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), cmbDefaultAppPrio.Text);
                    Process.GetCurrentProcess().PriorityClass = processPriorityClass;
                    ClientSize = new Size(310, 396);
                    Top = i1;
                    Left = i2;
                }
            }
        }

        private void frmPrio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.BoostExplorer = chkExplorer.Checked;
            Settings.Default.RefreshTime = hsbTimer.Value;
            Settings.Default.InactiveWinPrio = cmbResetPrio.SelectedIndex;
            Settings.Default.ActiveWinPrio = cmbSetPrio.SelectedIndex;
            Settings.Default.BalloonHidden = chkShowBalloonWhenHidden.Checked;
            Settings.Default.BalloonStart = chkShowBallonAtStart.Checked;
            Settings.Default.StartHidden = chkStartHidden.Checked;
            Settings.Default.ApplicationPrio = cmbDefaultAppPrio.SelectedIndex;
            Settings.Default.Save();
            SetProcessPrio(oldProc, oldProc.lastPrio);
        }

        private void frmPrio_Load(object sender, EventArgs e)
        {
            chkExplorer.Checked = Settings.Default.BoostExplorer;
            hsbTimer.Value = Settings.Default.RefreshTime;
            cmbResetPrio.SelectedIndex = Settings.Default.InactiveWinPrio;
            cmbSetPrio.SelectedIndex = Settings.Default.ActiveWinPrio;
            chkStartHidden.Checked = Settings.Default.StartHidden;
            chkShowBallonAtStart.Checked = Settings.Default.BalloonStart;
            chkShowBalloonWhenHidden.Checked = Settings.Default.BalloonHidden;
            cmbDefaultAppPrio.SelectedIndex = Settings.Default.ApplicationPrio;
            chkAutostart.Checked = Util.IsAutoStartEnabled(keyName, assemblyLocation);
            hsbTimer_Scroll(null, null);
        }

        private void hsbTimer_Scroll(object sender, ScrollEventArgs e)
        {
            int i = hsbTimer.Value;
            lbTimer.Text = "Refresh every " + i.ToString() + " secs";
            timerTopWindowCheck.Interval = i * 1000;
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPrio));
            timerTopWindowCheck = new Timer(components);
            btnClose = new Button();
            btnExit = new Button();
            tabControl1 = new TabControl();
            tabPrio = new TabPage();
            listView1 = new ListView();
            clmTime = new ColumnHeader();
            clmWindow = new ColumnHeader();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            tabSettings = new TabPage();
            groupBox1 = new GroupBox();
            cmbResetPrio = new ComboBox();
            label4 = new Label();
            cmbSetPrio = new ComboBox();
            label3 = new Label();
            hsbTimer = new HScrollBar();
            lbTimer = new Label();
            chkExplorer = new CheckBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            tabPage1 = new TabPage();
            groupBox2 = new GroupBox();
            cmbDefaultAppPrio = new ComboBox();
            label9 = new Label();
            chkStartHidden = new CheckBox();
            chkShowBallonAtStart = new CheckBox();
            chkShowBalloonWhenHidden = new CheckBox();
            chkAutostart = new CheckBox();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            trayIcon = new NotifyIcon(components);
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            comboBox2 = new ComboBox();
            label6 = new Label();
            hScrollBar1 = new HScrollBar();
            label7 = new Label();
            checkBox9 = new CheckBox();
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
            timerTopWindowCheck.Tick += new EventHandler(timerTopWindowCheck_Tick);
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(231, 370);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new EventHandler(btnClose_Click);
            btnExit.Location = new Point(4, 370);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 0;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += new EventHandler(btnExit_Click);
            tabControl1.Controls.Add(tabPrio);
            tabControl1.Controls.Add(tabSettings);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(310, 364);
            tabControl1.TabIndex = 0;
            tabPrio.Controls.Add(listView1);
            tabPrio.Controls.Add(label1);
            tabPrio.Controls.Add(pictureBox1);
            tabPrio.Location = new Point(4, 22);
            tabPrio.Name = "tabPrio";
            tabPrio.Padding = new Padding(3);
            tabPrio.Size = new Size(302, 338);
            tabPrio.TabIndex = 0;
            tabPrio.Text = "Priolist";
            tabPrio.UseVisualStyleBackColor = true;
            ColumnHeader[] columnHeaderArr = new ColumnHeader[] {
                                                                  clmTime, 
                                                                  clmWindow };
            listView1.Columns.AddRange(columnHeaderArr);
            listView1.Dock = DockStyle.Bottom;
            listView1.Location = new Point(3, 80);
            listView1.Name = "listView1";
            listView1.Size = new Size(296, 255);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            clmTime.Text = "Time";
            clmTime.Width = 48;
            clmWindow.Text = "Window title";
            clmWindow.Width = 242;
            label1.Location = new Point(77, 16);
            label1.Name = "label1";
            label1.Size = new Size(217, 49);
            label1.TabIndex = 0;
            label1.Text = "List of applications boosted with higher prio, when having focus.";
            pictureBox1.Image = Resources.GameIcon;
            pictureBox1.Location = new Point(8, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            tabSettings.Controls.Add(groupBox1);
            tabSettings.Controls.Add(label2);
            tabSettings.Controls.Add(pictureBox2);
            tabSettings.Location = new Point(4, 22);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new Padding(3);
            tabSettings.Size = new Size(302, 338);
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
            groupBox1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(9, 87);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(285, 245);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Boost settings";
            cmbResetPrio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResetPrio.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbResetPrio.FormattingEnabled = true;
            object[] objArr1 = new object[] {
                                              "Default", 
                                              "Normal", 
                                              "BelowNormal", 
                                              "Idle (not a good idea)" };
            cmbResetPrio.Items.AddRange(objArr1);
            cmbResetPrio.Location = new Point(134, 95);
            cmbResetPrio.Name = "cmbResetPrio";
            cmbResetPrio.Size = new Size(143, 21);
            cmbResetPrio.TabIndex = 6;
            cmbResetPrio.SelectedIndexChanged += new EventHandler(cmbResetPrio_SelectedIndexChanged);
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 98);
            label4.Name = "label4";
            label4.Size = new Size(125, 13);
            label4.TabIndex = 5;
            label4.Text = "Force inactive window to";
            cmbSetPrio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSetPrio.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSetPrio.FormattingEnabled = true;
            object[] objArr2 = new object[] {
                                              "AboveNormal", 
                                              "High", 
                                              "RealTime (dangerous)" };
            cmbSetPrio.Items.AddRange(objArr2);
            cmbSetPrio.Location = new Point(134, 68);
            cmbSetPrio.Name = "cmbSetPrio";
            cmbSetPrio.Size = new Size(143, 21);
            cmbSetPrio.TabIndex = 4;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 71);
            label3.Name = "label3";
            label3.Size = new Size(106, 13);
            label3.TabIndex = 3;
            label3.Text = "Set active window to";
            hsbTimer.Location = new Point(119, 39);
            hsbTimer.Maximum = 69;
            hsbTimer.Minimum = 1;
            hsbTimer.Name = "hsbTimer";
            hsbTimer.Size = new Size(163, 17);
            hsbTimer.TabIndex = 2;
            hsbTimer.TabStop = true;
            hsbTimer.Value = 1;
            hsbTimer.Scroll += new ScrollEventHandler(hsbTimer_Scroll);
            lbTimer.AutoSize = true;
            lbTimer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTimer.Location = new Point(3, 43);
            lbTimer.Name = "lbTimer";
            lbTimer.Size = new Size(110, 13);
            lbTimer.TabIndex = 1;
            lbTimer.Text = "Refresh every 5 secs.";
            chkExplorer.AutoSize = true;
            chkExplorer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkExplorer.Location = new Point(6, 19);
            chkExplorer.Name = "chkExplorer";
            chkExplorer.Size = new Size(93, 17);
            chkExplorer.TabIndex = 0;
            chkExplorer.Text = "Boost explorer";
            chkExplorer.UseVisualStyleBackColor = true;
            label2.Location = new Point(77, 16);
            label2.Name = "label2";
            label2.Size = new Size(194, 64);
            label2.TabIndex = 0;
            label2.Text = "Boost settings:\r\nHere you can configure \r\nhow the program will boost \r\nyour applications.\r\n";
            pictureBox2.Image = Resources.ThemeSettingsIcon;
            pictureBox2.Location = new Point(8, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(pictureBox3);
            tabPage1.Location = new Point(4, 22);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(302, 338);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Application settings";
            tabPage1.UseVisualStyleBackColor = true;
            groupBox2.Controls.Add(cmbDefaultAppPrio);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(chkStartHidden);
            groupBox2.Controls.Add(chkShowBallonAtStart);
            groupBox2.Controls.Add(chkShowBalloonWhenHidden);
            groupBox2.Controls.Add(chkAutostart);
            groupBox2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(9, 88);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(285, 231);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Application settings";
            cmbDefaultAppPrio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDefaultAppPrio.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbDefaultAppPrio.FormattingEnabled = true;
            object[] objArr3 = new object[] {
                                              "Normal", 
                                              "BelowNormal" };
            cmbDefaultAppPrio.Items.AddRange(objArr3);
            cmbDefaultAppPrio.Location = new Point(136, 109);
            cmbDefaultAppPrio.Name = "cmbDefaultAppPrio";
            cmbDefaultAppPrio.Size = new Size(143, 21);
            cmbDefaultAppPrio.TabIndex = 8;
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(5, 112);
            label9.Name = "label9";
            label9.Size = new Size(92, 13);
            label9.TabIndex = 7;
            label9.Text = "Application priority";
            chkStartHidden.AutoSize = true;
            chkStartHidden.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkStartHidden.Location = new Point(6, 42);
            chkStartHidden.Name = "chkStartHidden";
            chkStartHidden.Size = new Size(83, 17);
            chkStartHidden.TabIndex = 1;
            chkStartHidden.Text = "Start hidden";
            chkStartHidden.UseVisualStyleBackColor = true;
            chkShowBallonAtStart.AutoSize = true;
            chkShowBallonAtStart.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowBallonAtStart.Location = new Point(22, 65);
            chkShowBallonAtStart.Name = "chkShowBallonAtStart";
            chkShowBallonAtStart.Size = new Size(125, 17);
            chkShowBallonAtStart.TabIndex = 2;
            chkShowBallonAtStart.Text = "Show balloon at start";
            chkShowBallonAtStart.UseVisualStyleBackColor = true;
            chkShowBalloonWhenHidden.AutoSize = true;
            chkShowBalloonWhenHidden.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowBalloonWhenHidden.Location = new Point(6, 88);
            chkShowBalloonWhenHidden.Name = "chkShowBalloonWhenHidden";
            chkShowBalloonWhenHidden.Size = new Size(154, 17);
            chkShowBalloonWhenHidden.TabIndex = 3;
            chkShowBalloonWhenHidden.Text = "Show balloon when hidden";
            chkShowBalloonWhenHidden.UseVisualStyleBackColor = true;
            chkAutostart.AutoSize = true;
            chkAutostart.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkAutostart.Location = new Point(6, 18);
            chkAutostart.Name = "chkAutostart";
            chkAutostart.Size = new Size(114, 17);
            chkAutostart.TabIndex = 0;
            chkAutostart.Text = "Start with windows";
            chkAutostart.UseVisualStyleBackColor = true;
            chkAutostart.CheckedChanged += new EventHandler(chkAutostart_CheckedChanged);
            label8.Location = new Point(77, 16);
            label8.Name = "label8";
            label8.Size = new Size(194, 64);
            label8.TabIndex = 0;
            label8.Text = "Application settings:\r\nHere you can configure \r\nhow the program will behave.";
            pictureBox3.Image = Resources.SettingsIcon;
            pictureBox3.Location = new Point(8, 16);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(64, 64);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.Icon = (Icon)componentResourceManager.GetObject("trayIcon.Icon");
            trayIcon.Text = "LunaWorX.net TopWinPrio";
            trayIcon.Visible = true;
            trayIcon.BalloonTipClicked += new EventHandler(trayIcon_BalloonTipClicked);
            trayIcon.MouseClick += new MouseEventHandler(trayIcon_MouseClick);
            checkBox5.AutoSize = true;
            checkBox5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox5.Location = new Point(137, 19);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(83, 17);
            checkBox5.TabIndex = 9;
            checkBox5.Text = "Start hidden";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox6.AutoSize = true;
            checkBox6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox6.Location = new Point(137, 38);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(125, 17);
            checkBox6.TabIndex = 8;
            checkBox6.Text = "Show balloon at start";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox7.AutoSize = true;
            checkBox7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox7.Location = new Point(6, 38);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(154, 17);
            checkBox7.TabIndex = 7;
            checkBox7.Text = "Show balloon when hidden";
            checkBox7.UseVisualStyleBackColor = true;
            checkBox8.AutoSize = true;
            checkBox8.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox8.Location = new Point(7, 19);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(114, 17);
            checkBox8.TabIndex = 6;
            checkBox8.Text = "Start with windows";
            checkBox8.UseVisualStyleBackColor = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            object[] objArr4 = new object[] {
                                              "Default", 
                                              "Normal", 
                                              "BelowNormal", 
                                              "Idle (not a good idea)" };
            comboBox1.Items.AddRange(objArr4);
            comboBox1.Location = new Point(134, 95);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(143, 21);
            comboBox1.TabIndex = 11;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 98);
            label5.Name = "label5";
            label5.Size = new Size(125, 13);
            label5.TabIndex = 10;
            label5.Text = "Force inactive window to";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            object[] objArr5 = new object[] {
                                              "AboveNormal", 
                                              "High", 
                                              "RealTime (dangerous)" };
            comboBox2.Items.AddRange(objArr5);
            comboBox2.Location = new Point(134, 68);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(143, 21);
            comboBox2.TabIndex = 9;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 71);
            label6.Name = "label6";
            label6.Size = new Size(106, 13);
            label6.TabIndex = 8;
            label6.Text = "Set active window to";
            hScrollBar1.Location = new Point(119, 39);
            hScrollBar1.Maximum = 69;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(163, 17);
            hScrollBar1.TabIndex = 7;
            hScrollBar1.Value = 1;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(3, 43);
            label7.Name = "label7";
            label7.Size = new Size(110, 13);
            label7.TabIndex = 6;
            label7.Text = "Refresh every 5 secs.";
            checkBox9.AutoSize = true;
            checkBox9.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox9.Location = new Point(6, 19);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(93, 17);
            checkBox9.TabIndex = 5;
            checkBox9.Text = "Boost explorer";
            checkBox9.UseVisualStyleBackColor = true;
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(310, 396);
            ControlBox = false;
            Controls.Add(tabControl1);
            Controls.Add(btnExit);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            Name = "frmPrio";
            Text = "LunaWorX.net TopWinPrio";
            Load += new EventHandler(frmPrio_Load);
            Activated += new EventHandler(frmPrio_Activated);
            FormClosed += new FormClosedEventHandler(frmPrio_FormClosed);
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

        private bool SetProcessPrio(frmPrio.ProcessData theProc, ProcessPriorityClass processPriorityClass)
        {
            bool flag2;
            Process process;

            bool flag1 = false;
            try
            {
                process = Process.GetProcessById(theProc.processID);
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

        private void timerTopWindowCheck_Tick(object sender, EventArgs e)
        {
            timerTopWindowCheck.Enabled = false;
            int i = WinAPI.GetTopWindowHandle;
            bool flag = false;
            if (i != lastHandle)
            {
                SetProcessPrio(oldProc, oldProc.lastPrio);
                lastHandle = i;
                Process process = null;
                try
                {
                    process = Process.GetProcessById(WinAPI.GetTopWindowProcessID);
                    flag = process != null;
                    if (flag)
                        flag = process.Id > 0;
                    if (flag && !chkExplorer.Checked)
                        flag = process.ProcessName != "explorer";
                    if (flag)
                        flag = process.Id != Process.GetCurrentProcess().Id;
                }
                catch 
                {
                    flag = false;
                }
                if (flag)
                {
                    frmPrio.ProcessData processData1 = null;
                    try
                    {
                        frmPrio.ProcessData processData2 = new frmPrio.ProcessData();
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
                            processData1.lastPrio = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), cmbResetPrio.Text);
                        ProcessPriorityClass processPriorityClass = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), cmbSetPrio.Text);
                        if (SetProcessPrio(processData1, processPriorityClass))
                        {
                            DateTime dateTime = DateTime.Now;
                            ListViewItem listViewItem = new ListViewItem(dateTime.ToShortTimeString());
                            string s = WinAPI.GetTopWindowText;
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

        private void trayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Visible = false;
            trayIcon_MouseClick(null, null);
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

    } // class frmPrio

}

