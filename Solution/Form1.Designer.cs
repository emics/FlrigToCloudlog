namespace FlrigToCloudlog
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtCloudApiKey = new TextBox();
            labelCloudApiKey = new Label();
            labelCloudUrl = new Label();
            labelFlRigUrl = new Label();
            txtCloudUrl = new TextBox();
            txtFlRigUrl = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            numDelaySec = new NumericUpDown();
            labelDelaySec = new Label();
            statusStrip = new StatusStrip();
            ssLabel = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            MenuItemShow = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            MenuItemStart = new ToolStripMenuItem();
            MenuItemStop = new ToolStripMenuItem();
            chkboxMinimized = new CheckBox();
            groupBox1 = new GroupBox();
            lblRigDataMode = new Label();
            lblRigDataFrequency = new Label();
            lblRigDataName = new Label();
            chkboxShow = new CheckBox();
            labelAbout = new Label();
            tabControl = new TabControl();
            tabPageRun = new TabPage();
            groupBox2 = new GroupBox();
            lblAdifData = new Label();
            label2 = new Label();
            label1 = new Label();
            pbUDP = new PictureBox();
            pbFlrig = new PictureBox();
            tabPageCloudLog = new TabPage();
            numIdStation = new NumericUpDown();
            labelIdStation = new Label();
            chkboxRigServer = new CheckBox();
            chkboxUDPServer = new CheckBox();
            numListenPort = new NumericUpDown();
            labelListenPort = new Label();
            ((System.ComponentModel.ISupportInitialize)numDelaySec).BeginInit();
            statusStrip.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageRun.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUDP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFlrig).BeginInit();
            tabPageCloudLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIdStation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numListenPort).BeginInit();
            SuspendLayout();
            // 
            // txtCloudApiKey
            // 
            txtCloudApiKey.Location = new Point(150, 10);
            txtCloudApiKey.Name = "txtCloudApiKey";
            txtCloudApiKey.PasswordChar = '*';
            txtCloudApiKey.Size = new Size(131, 27);
            txtCloudApiKey.TabIndex = 0;
            txtCloudApiKey.Leave += txtCloudApiKey_Leave;
            // 
            // labelCloudApiKey
            // 
            labelCloudApiKey.AutoSize = true;
            labelCloudApiKey.Location = new Point(5, 13);
            labelCloudApiKey.Name = "labelCloudApiKey";
            labelCloudApiKey.Size = new Size(128, 20);
            labelCloudApiKey.TabIndex = 1;
            labelCloudApiKey.Text = "CloudLog Api Key";
            // 
            // labelCloudUrl
            // 
            labelCloudUrl.AutoSize = true;
            labelCloudUrl.Location = new Point(5, 46);
            labelCloudUrl.Name = "labelCloudUrl";
            labelCloudUrl.Size = new Size(96, 20);
            labelCloudUrl.TabIndex = 2;
            labelCloudUrl.Text = "CloudLog Url";
            // 
            // labelFlRigUrl
            // 
            labelFlRigUrl.AutoSize = true;
            labelFlRigUrl.Location = new Point(5, 79);
            labelFlRigUrl.Name = "labelFlRigUrl";
            labelFlRigUrl.Size = new Size(99, 20);
            labelFlRigUrl.TabIndex = 3;
            labelFlRigUrl.Text = "flig Server Url";
            // 
            // txtCloudUrl
            // 
            txtCloudUrl.Location = new Point(150, 43);
            txtCloudUrl.Name = "txtCloudUrl";
            txtCloudUrl.Size = new Size(408, 27);
            txtCloudUrl.TabIndex = 1;
            txtCloudUrl.Leave += txtCloudUrl_Leave;
            // 
            // txtFlRigUrl
            // 
            txtFlRigUrl.Enabled = false;
            txtFlRigUrl.Location = new Point(150, 76);
            txtFlRigUrl.Name = "txtFlRigUrl";
            txtFlRigUrl.Size = new Size(408, 27);
            txtFlRigUrl.TabIndex = 2;
            txtFlRigUrl.Leave += txtFlRigUrl_Leave;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 16);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(120, 50);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(156, 16);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(120, 50);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // numDelaySec
            // 
            numDelaySec.Enabled = false;
            numDelaySec.Location = new Point(150, 109);
            numDelaySec.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numDelaySec.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDelaySec.Name = "numDelaySec";
            numDelaySec.Size = new Size(67, 27);
            numDelaySec.TabIndex = 3;
            numDelaySec.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numDelaySec.Leave += numDelaySec_Leave;
            // 
            // labelDelaySec
            // 
            labelDelaySec.AutoSize = true;
            labelDelaySec.Location = new Point(5, 111);
            labelDelaySec.Name = "labelDelaySec";
            labelDelaySec.Size = new Size(138, 20);
            labelDelaySec.TabIndex = 9;
            labelDelaySec.Text = "Update Delay (sec.)";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { ssLabel, toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 276);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(587, 22);
            statusStrip.TabIndex = 10;
            // 
            // ssLabel
            // 
            ssLabel.Name = "ssLabel";
            ssLabel.Size = new Size(0, 16);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 16);
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "Running";
            notifyIcon.BalloonTipTitle = "FlrigToCloudlog";
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "isActive";
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { MenuItemShow, toolStripSeparator, MenuItemStart, MenuItemStop });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(121, 88);
            // 
            // MenuItemShow
            // 
            MenuItemShow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            MenuItemShow.Name = "MenuItemShow";
            MenuItemShow.Size = new Size(120, 26);
            MenuItemShow.Text = "Show";
            MenuItemShow.Click += MenuItemShow_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(117, 6);
            // 
            // MenuItemStart
            // 
            MenuItemStart.Image = (Image)resources.GetObject("MenuItemStart.Image");
            MenuItemStart.Name = "MenuItemStart";
            MenuItemStart.Size = new Size(120, 26);
            MenuItemStart.Text = "Start";
            MenuItemStart.Click += MenuItemStart_Click;
            // 
            // MenuItemStop
            // 
            MenuItemStop.Enabled = false;
            MenuItemStop.Image = (Image)resources.GetObject("MenuItemStop.Image");
            MenuItemStop.Name = "MenuItemStop";
            MenuItemStop.Size = new Size(120, 26);
            MenuItemStop.Text = "Stop";
            MenuItemStop.Click += MenuItemStop_Click;
            // 
            // chkboxMinimized
            // 
            chkboxMinimized.AutoSize = true;
            chkboxMinimized.Location = new Point(8, 210);
            chkboxMinimized.Name = "chkboxMinimized";
            chkboxMinimized.Size = new Size(172, 24);
            chkboxMinimized.TabIndex = 4;
            chkboxMinimized.Text = "Auto Start Minimized";
            chkboxMinimized.UseVisualStyleBackColor = true;
            chkboxMinimized.Leave += chkboxMinimized_Leave;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblRigDataMode);
            groupBox1.Controls.Add(lblRigDataFrequency);
            groupBox1.Controls.Add(lblRigDataName);
            groupBox1.Location = new Point(12, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(264, 98);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "flrig Data";
            // 
            // lblRigDataMode
            // 
            lblRigDataMode.AutoSize = true;
            lblRigDataMode.Location = new Point(8, 69);
            lblRigDataMode.Name = "lblRigDataMode";
            lblRigDataMode.Size = new Size(51, 20);
            lblRigDataMode.TabIndex = 2;
            lblRigDataMode.Text = "Mode:";
            // 
            // lblRigDataFrequency
            // 
            lblRigDataFrequency.AutoSize = true;
            lblRigDataFrequency.Location = new Point(18, 49);
            lblRigDataFrequency.Name = "lblRigDataFrequency";
            lblRigDataFrequency.Size = new Size(41, 20);
            lblRigDataFrequency.TabIndex = 1;
            lblRigDataFrequency.Text = "Freq:";
            // 
            // lblRigDataName
            // 
            lblRigDataName.AutoSize = true;
            lblRigDataName.Location = new Point(26, 29);
            lblRigDataName.Name = "lblRigDataName";
            lblRigDataName.Size = new Size(34, 20);
            lblRigDataName.TabIndex = 0;
            lblRigDataName.Text = "Rig:";
            // 
            // chkboxShow
            // 
            chkboxShow.AutoSize = true;
            chkboxShow.Location = new Point(287, 13);
            chkboxShow.Name = "chkboxShow";
            chkboxShow.Size = new Size(67, 24);
            chkboxShow.TabIndex = 7;
            chkboxShow.Text = "Show";
            chkboxShow.UseVisualStyleBackColor = true;
            chkboxShow.CheckedChanged += chkboxShow_CheckedChanged;
            // 
            // labelAbout
            // 
            labelAbout.AutoSize = true;
            labelAbout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAbout.Location = new Point(551, 2);
            labelAbout.Name = "labelAbout";
            labelAbout.Size = new Size(16, 20);
            labelAbout.TabIndex = 8;
            labelAbout.Text = "?";
            labelAbout.MouseClick += labelAbout_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageRun);
            tabControl.Controls.Add(tabPageCloudLog);
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(578, 272);
            tabControl.TabIndex = 13;
            // 
            // tabPageRun
            // 
            tabPageRun.Controls.Add(groupBox2);
            tabPageRun.Controls.Add(label2);
            tabPageRun.Controls.Add(label1);
            tabPageRun.Controls.Add(pbUDP);
            tabPageRun.Controls.Add(pbFlrig);
            tabPageRun.Controls.Add(groupBox1);
            tabPageRun.Controls.Add(btnStop);
            tabPageRun.Controls.Add(labelAbout);
            tabPageRun.Controls.Add(btnStart);
            tabPageRun.Location = new Point(4, 29);
            tabPageRun.Margin = new Padding(0);
            tabPageRun.Name = "tabPageRun";
            tabPageRun.Size = new Size(570, 239);
            tabPageRun.TabIndex = 0;
            tabPageRun.Text = "Server";
            tabPageRun.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblAdifData);
            groupBox2.Location = new Point(293, 82);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(260, 150);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "ADIF Data";
            // 
            // lblAdifData
            // 
            lblAdifData.AutoSize = true;
            lblAdifData.Location = new Point(6, 23);
            lblAdifData.Name = "lblAdifData";
            lblAdifData.Size = new Size(0, 20);
            lblAdifData.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(397, 53);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 16;
            label2.Text = "UDP ADIF status";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(435, 23);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 15;
            label1.Text = "flrig status";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pbUDP
            // 
            pbUDP.Image = (Image)resources.GetObject("pbUDP.Image");
            pbUDP.InitialImage = (Image)resources.GetObject("pbUDP.InitialImage");
            pbUDP.Location = new Point(523, 52);
            pbUDP.Margin = new Padding(0);
            pbUDP.Name = "pbUDP";
            pbUDP.Size = new Size(26, 26);
            pbUDP.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUDP.TabIndex = 14;
            pbUDP.TabStop = false;
            // 
            // pbFlrig
            // 
            pbFlrig.Image = (Image)resources.GetObject("pbFlrig.Image");
            pbFlrig.InitialImage = (Image)resources.GetObject("pbFlrig.InitialImage");
            pbFlrig.Location = new Point(523, 22);
            pbFlrig.Margin = new Padding(0);
            pbFlrig.Name = "pbFlrig";
            pbFlrig.Size = new Size(26, 26);
            pbFlrig.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFlrig.TabIndex = 13;
            pbFlrig.TabStop = false;
            // 
            // tabPageCloudLog
            // 
            tabPageCloudLog.Controls.Add(numIdStation);
            tabPageCloudLog.Controls.Add(labelIdStation);
            tabPageCloudLog.Controls.Add(chkboxRigServer);
            tabPageCloudLog.Controls.Add(chkboxUDPServer);
            tabPageCloudLog.Controls.Add(numListenPort);
            tabPageCloudLog.Controls.Add(numDelaySec);
            tabPageCloudLog.Controls.Add(labelListenPort);
            tabPageCloudLog.Controls.Add(chkboxMinimized);
            tabPageCloudLog.Controls.Add(txtCloudApiKey);
            tabPageCloudLog.Controls.Add(labelFlRigUrl);
            tabPageCloudLog.Controls.Add(txtFlRigUrl);
            tabPageCloudLog.Controls.Add(txtCloudUrl);
            tabPageCloudLog.Controls.Add(labelCloudUrl);
            tabPageCloudLog.Controls.Add(labelCloudApiKey);
            tabPageCloudLog.Controls.Add(labelDelaySec);
            tabPageCloudLog.Controls.Add(chkboxShow);
            tabPageCloudLog.Location = new Point(4, 29);
            tabPageCloudLog.Name = "tabPageCloudLog";
            tabPageCloudLog.Size = new Size(570, 239);
            tabPageCloudLog.TabIndex = 3;
            tabPageCloudLog.Text = "Configuration";
            tabPageCloudLog.UseVisualStyleBackColor = true;
            // 
            // numIdStation
            // 
            numIdStation.Enabled = false;
            numIdStation.Location = new Point(150, 175);
            numIdStation.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numIdStation.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIdStation.Name = "numIdStation";
            numIdStation.Size = new Size(67, 27);
            numIdStation.TabIndex = 16;
            numIdStation.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numIdStation.Leave += numIdStation_Leave;
            // 
            // labelIdStation
            // 
            labelIdStation.AutoSize = true;
            labelIdStation.Location = new Point(5, 177);
            labelIdStation.Name = "labelIdStation";
            labelIdStation.Size = new Size(136, 20);
            labelIdStation.TabIndex = 17;
            labelIdStation.Text = "ID Station Location";
            // 
            // chkboxRigServer
            // 
            chkboxRigServer.AutoSize = true;
            chkboxRigServer.Location = new Point(228, 111);
            chkboxRigServer.Name = "chkboxRigServer";
            chkboxRigServer.Size = new Size(254, 24);
            chkboxRigServer.TabIndex = 15;
            chkboxRigServer.Text = "Enable Rig Data to CloudLog task";
            chkboxRigServer.UseVisualStyleBackColor = true;
            chkboxRigServer.CheckedChanged += chkboxRigServer_CheckedChanged;
            chkboxRigServer.Leave += chkboxRigServer_Leave;
            // 
            // chkboxUDPServer
            // 
            chkboxUDPServer.AutoSize = true;
            chkboxUDPServer.Location = new Point(228, 144);
            chkboxUDPServer.Name = "chkboxUDPServer";
            chkboxUDPServer.Size = new Size(257, 24);
            chkboxUDPServer.TabIndex = 14;
            chkboxUDPServer.Text = "Enable ADIF Log to CloudLog task";
            chkboxUDPServer.UseVisualStyleBackColor = true;
            chkboxUDPServer.CheckedChanged += chkboxUDPServer_CheckedChanged;
            chkboxUDPServer.Leave += chkboxUDPServer_Leave;
            // 
            // numListenPort
            // 
            numListenPort.Enabled = false;
            numListenPort.Location = new Point(150, 142);
            numListenPort.Maximum = new decimal(new int[] { 49151, 0, 0, 0 });
            numListenPort.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            numListenPort.Name = "numListenPort";
            numListenPort.Size = new Size(67, 27);
            numListenPort.TabIndex = 11;
            numListenPort.Value = new decimal(new int[] { 2878, 0, 0, 0 });
            numListenPort.Leave += numListenPort_Leave;
            // 
            // labelListenPort
            // 
            labelListenPort.AutoSize = true;
            labelListenPort.Location = new Point(5, 144);
            labelListenPort.Name = "labelListenPort";
            labelListenPort.Size = new Size(110, 20);
            labelListenPort.TabIndex = 13;
            labelListenPort.Text = "Listen UDP Port";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(587, 298);
            Controls.Add(tabControl);
            Controls.Add(statusStrip);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FlrigToCloudlog";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)numDelaySec).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageRun.ResumeLayout(false);
            tabPageRun.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbUDP).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFlrig).EndInit();
            tabPageCloudLog.ResumeLayout(false);
            tabPageCloudLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIdStation).EndInit();
            ((System.ComponentModel.ISupportInitialize)numListenPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCloudApiKey;
        private Label labelCloudApiKey;
        private Label labelCloudUrl;
        private Label labelFlRigUrl;
        private TextBox txtCloudUrl;
        private TextBox txtFlRigUrl;
        private Button btnStart;
        private Button btnStop;
        private NumericUpDown numDelaySec;
        private Label labelDelaySec;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel ssLabel;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private NotifyIcon notifyIcon;
        private CheckBox chkboxMinimized;
        private GroupBox groupBox1;
        private Label lblRigDataName;
        private Label lblRigDataFrequency;
        private Label lblRigDataMode;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem MenuItemShow;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem MenuItemStart;
        private ToolStripMenuItem MenuItemStop;
        private CheckBox chkboxShow;
        private Label labelAbout;
        private TabControl tabControl;
        private TabPage tabPageRun;
        private TabPage tabPageCloudLog;
        private NumericUpDown numListenPort;
        private Label labelListenPort;
        private CheckBox chkboxUDPServer;
        private PictureBox pbFlrig;
        private PictureBox pbUDP;
        private Label label1;
        private Label label2;
        private CheckBox chkboxRigServer;
        private NumericUpDown numIdStation;
        private Label labelIdStation;
        private GroupBox groupBox2;
        private Label lblAdifData;
    }
}
