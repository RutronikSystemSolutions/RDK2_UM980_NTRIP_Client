namespace UM980PositioningGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.connectButton = new System.Windows.Forms.Button();
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.lastPacketLabel = new System.Windows.Forms.Label();
            this.mapControl = new System.Windows.Forms.MapControl();
            this.um980SerialPortConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.hdopTextBox = new System.Windows.Forms.TextBox();
            this.hdopLabel = new System.Windows.Forms.Label();
            this.rawGGAMSgTextBox = new System.Windows.Forms.TextBox();
            this.disconnectUM980Button = new System.Windows.Forms.Button();
            this.satCountTextBox = new System.Windows.Forms.TextBox();
            this.satCountLabel = new System.Windows.Forms.Label();
            this.qualityTextBox = new System.Windows.Forms.TextBox();
            this.signalQualityLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.ntripCasterConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.lastRTCMTypeLabel = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.configureNtripStreamButton = new System.Windows.Forms.Button();
            this.receptionSpeedLabel = new System.Windows.Forms.Label();
            this.bytesReceivedLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storePositionToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerOnPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsReferencePointButton = new System.Windows.Forms.Button();
            this.distanceToRefPointTextBox = new System.Windows.Forms.TextBox();
            this.distanceToRefPointLabel = new System.Windows.Forms.Label();
            this.logBox = new UM980PositioningGUI.Controls.LogBox();
            this.hdopPanel = new UM980PositioningGUI.HDOPPanel();
            this.blinkingPanel = new UM980PositioningGUI.BlinkingPanel();
            this.um980SerialPortConfigurationGroupBox.SuspendLayout();
            this.ntripCasterConfigurationGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(182, 17);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(56, 19);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // portsComboBox
            // 
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(4, 17);
            this.portsComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(174, 21);
            this.portsComboBox.TabIndex = 3;
            // 
            // lastPacketLabel
            // 
            this.lastPacketLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastPacketLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lastPacketLabel.Location = new System.Drawing.Point(4, 63);
            this.lastPacketLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastPacketLabel.Name = "lastPacketLabel";
            this.lastPacketLabel.Size = new System.Drawing.Size(393, 108);
            this.lastPacketLabel.TabIndex = 5;
            this.lastPacketLabel.Text = "---";
            // 
            // mapControl
            // 
            this.mapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapControl.BackColor = System.Drawing.Color.White;
            this.mapControl.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapControl.ErrorColor = System.Drawing.Color.Red;
            this.mapControl.FitToBounds = true;
            this.mapControl.Location = new System.Drawing.Point(9, 213);
            this.mapControl.Margin = new System.Windows.Forms.Padding(2);
            this.mapControl.Name = "mapControl";
            this.mapControl.ShowThumbnails = true;
            this.mapControl.Size = new System.Drawing.Size(942, 396);
            this.mapControl.TabIndex = 7;
            this.mapControl.Text = "mapControl";
            this.mapControl.ThumbnailBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mapControl.ThumbnailForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.mapControl.ThumbnailText = "Downloading...";
            this.mapControl.TileImageAttributes = null;
            this.mapControl.ZoomLevel = 0;
            // 
            // um980SerialPortConfigurationGroupBox
            // 
            this.um980SerialPortConfigurationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.hdopPanel);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.hdopTextBox);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.hdopLabel);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.blinkingPanel);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.rawGGAMSgTextBox);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.disconnectUM980Button);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.satCountTextBox);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.satCountLabel);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.qualityTextBox);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.signalQualityLabel);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.label2);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.latitudeTextBox);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.latitudeLabel);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.label1);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.longitudeTextBox);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.longitudeLabel);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.portsComboBox);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.connectButton);
            this.um980SerialPortConfigurationGroupBox.Controls.Add(this.lastPacketLabel);
            this.um980SerialPortConfigurationGroupBox.Location = new System.Drawing.Point(11, 26);
            this.um980SerialPortConfigurationGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.um980SerialPortConfigurationGroupBox.Name = "um980SerialPortConfigurationGroupBox";
            this.um980SerialPortConfigurationGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.um980SerialPortConfigurationGroupBox.Size = new System.Drawing.Size(560, 183);
            this.um980SerialPortConfigurationGroupBox.TabIndex = 8;
            this.um980SerialPortConfigurationGroupBox.TabStop = false;
            this.um980SerialPortConfigurationGroupBox.Text = "UM980 - Serial port configuration";
            // 
            // hdopTextBox
            // 
            this.hdopTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hdopTextBox.Location = new System.Drawing.Point(464, 128);
            this.hdopTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.hdopTextBox.Name = "hdopTextBox";
            this.hdopTextBox.ReadOnly = true;
            this.hdopTextBox.Size = new System.Drawing.Size(50, 20);
            this.hdopTextBox.TabIndex = 20;
            // 
            // hdopLabel
            // 
            this.hdopLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hdopLabel.AutoSize = true;
            this.hdopLabel.Location = new System.Drawing.Point(409, 130);
            this.hdopLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hdopLabel.Name = "hdopLabel";
            this.hdopLabel.Size = new System.Drawing.Size(41, 13);
            this.hdopLabel.TabIndex = 19;
            this.hdopLabel.Text = "HDOP:";
            // 
            // rawGGAMSgTextBox
            // 
            this.rawGGAMSgTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawGGAMSgTextBox.Location = new System.Drawing.Point(4, 40);
            this.rawGGAMSgTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.rawGGAMSgTextBox.Name = "rawGGAMSgTextBox";
            this.rawGGAMSgTextBox.ReadOnly = true;
            this.rawGGAMSgTextBox.Size = new System.Drawing.Size(367, 20);
            this.rawGGAMSgTextBox.TabIndex = 17;
            // 
            // disconnectUM980Button
            // 
            this.disconnectUM980Button.Enabled = false;
            this.disconnectUM980Button.Location = new System.Drawing.Point(243, 17);
            this.disconnectUM980Button.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectUM980Button.Name = "disconnectUM980Button";
            this.disconnectUM980Button.Size = new System.Drawing.Size(78, 19);
            this.disconnectUM980Button.TabIndex = 16;
            this.disconnectUM980Button.Text = "Disconnect";
            this.disconnectUM980Button.UseVisualStyleBackColor = true;
            this.disconnectUM980Button.Click += new System.EventHandler(this.disconnectUM980Button_Click);
            // 
            // satCountTextBox
            // 
            this.satCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.satCountTextBox.Location = new System.Drawing.Point(464, 106);
            this.satCountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.satCountTextBox.Name = "satCountTextBox";
            this.satCountTextBox.ReadOnly = true;
            this.satCountTextBox.Size = new System.Drawing.Size(76, 20);
            this.satCountTextBox.TabIndex = 15;
            // 
            // satCountLabel
            // 
            this.satCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.satCountLabel.AutoSize = true;
            this.satCountLabel.Location = new System.Drawing.Point(403, 109);
            this.satCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.satCountLabel.Name = "satCountLabel";
            this.satCountLabel.Size = new System.Drawing.Size(59, 13);
            this.satCountLabel.TabIndex = 14;
            this.satCountLabel.Text = "Sat. count:";
            // 
            // qualityTextBox
            // 
            this.qualityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qualityTextBox.Location = new System.Drawing.Point(464, 83);
            this.qualityTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.qualityTextBox.Name = "qualityTextBox";
            this.qualityTextBox.ReadOnly = true;
            this.qualityTextBox.Size = new System.Drawing.Size(76, 20);
            this.qualityTextBox.TabIndex = 13;
            // 
            // signalQualityLabel
            // 
            this.signalQualityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.signalQualityLabel.AutoSize = true;
            this.signalQualityLabel.Location = new System.Drawing.Point(416, 85);
            this.signalQualityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.signalQualityLabel.Name = "signalQualityLabel";
            this.signalQualityLabel.Size = new System.Drawing.Size(42, 13);
            this.signalQualityLabel.TabIndex = 12;
            this.signalQualityLabel.Text = "Quality:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "°";
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.latitudeTextBox.Location = new System.Drawing.Point(464, 60);
            this.latitudeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.ReadOnly = true;
            this.latitudeTextBox.Size = new System.Drawing.Size(76, 20);
            this.latitudeTextBox.TabIndex = 10;
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Location = new System.Drawing.Point(412, 63);
            this.latitudeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(48, 13);
            this.latitudeLabel.TabIndex = 9;
            this.latitudeLabel.Text = "Latitude:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "°";
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.longitudeTextBox.Location = new System.Drawing.Point(464, 37);
            this.longitudeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.ReadOnly = true;
            this.longitudeTextBox.Size = new System.Drawing.Size(76, 20);
            this.longitudeTextBox.TabIndex = 7;
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Location = new System.Drawing.Point(403, 40);
            this.longitudeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(57, 13);
            this.longitudeLabel.TabIndex = 6;
            this.longitudeLabel.Text = "Longitude:";
            // 
            // ntripCasterConfigurationGroupBox
            // 
            this.ntripCasterConfigurationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.lastRTCMTypeLabel);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.logBox);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.disconnectButton);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.configureNtripStreamButton);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.receptionSpeedLabel);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.bytesReceivedLabel);
            this.ntripCasterConfigurationGroupBox.Location = new System.Drawing.Point(575, 32);
            this.ntripCasterConfigurationGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.ntripCasterConfigurationGroupBox.Name = "ntripCasterConfigurationGroupBox";
            this.ntripCasterConfigurationGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.ntripCasterConfigurationGroupBox.Size = new System.Drawing.Size(376, 177);
            this.ntripCasterConfigurationGroupBox.TabIndex = 9;
            this.ntripCasterConfigurationGroupBox.TabStop = false;
            this.ntripCasterConfigurationGroupBox.Text = "NTRIP Caster - Connection configuration";
            // 
            // lastRTCMTypeLabel
            // 
            this.lastRTCMTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lastRTCMTypeLabel.AutoSize = true;
            this.lastRTCMTypeLabel.Location = new System.Drawing.Point(159, 157);
            this.lastRTCMTypeLabel.Name = "lastRTCMTypeLabel";
            this.lastRTCMTypeLabel.Size = new System.Drawing.Size(19, 13);
            this.lastRTCMTypeLabel.TabIndex = 15;
            this.lastRTCMTypeLabel.Text = "----";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(141, 17);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(120, 23);
            this.disconnectButton.TabIndex = 13;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // configureNtripStreamButton
            // 
            this.configureNtripStreamButton.Location = new System.Drawing.Point(16, 17);
            this.configureNtripStreamButton.Margin = new System.Windows.Forms.Padding(2);
            this.configureNtripStreamButton.Name = "configureNtripStreamButton";
            this.configureNtripStreamButton.Size = new System.Drawing.Size(120, 23);
            this.configureNtripStreamButton.TabIndex = 12;
            this.configureNtripStreamButton.Text = "Configure stream";
            this.configureNtripStreamButton.UseVisualStyleBackColor = true;
            this.configureNtripStreamButton.Click += new System.EventHandler(this.configureNtripStreamButton_Click);
            // 
            // receptionSpeedLabel
            // 
            this.receptionSpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.receptionSpeedLabel.AutoSize = true;
            this.receptionSpeedLabel.Location = new System.Drawing.Point(311, 157);
            this.receptionSpeedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.receptionSpeedLabel.Name = "receptionSpeedLabel";
            this.receptionSpeedLabel.Size = new System.Drawing.Size(60, 13);
            this.receptionSpeedLabel.TabIndex = 5;
            this.receptionSpeedLabel.Text = "----- bytes/s";
            // 
            // bytesReceivedLabel
            // 
            this.bytesReceivedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bytesReceivedLabel.AutoSize = true;
            this.bytesReceivedLabel.Location = new System.Drawing.Point(4, 157);
            this.bytesReceivedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bytesReceivedLabel.Name = "bytesReceivedLabel";
            this.bytesReceivedLabel.Size = new System.Drawing.Size(91, 13);
            this.bytesReceivedLabel.TabIndex = 4;
            this.bytesReceivedLabel.Text = "--- bytes received.";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(962, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storePositionToFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // storePositionToFileToolStripMenuItem
            // 
            this.storePositionToFileToolStripMenuItem.Name = "storePositionToFileToolStripMenuItem";
            this.storePositionToFileToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.storePositionToFileToolStripMenuItem.Text = "Store to file";
            this.storePositionToFileToolStripMenuItem.Click += new System.EventHandler(this.storePositionToFileToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerOnPositionToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // centerOnPositionToolStripMenuItem
            // 
            this.centerOnPositionToolStripMenuItem.Checked = true;
            this.centerOnPositionToolStripMenuItem.CheckOnClick = true;
            this.centerOnPositionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.centerOnPositionToolStripMenuItem.Name = "centerOnPositionToolStripMenuItem";
            this.centerOnPositionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.centerOnPositionToolStripMenuItem.Text = "Center on position";
            this.centerOnPositionToolStripMenuItem.Click += new System.EventHandler(this.centerOnPositionToolStripMenuItem_Click);
            // 
            // setAsReferencePointButton
            // 
            this.setAsReferencePointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setAsReferencePointButton.Location = new System.Drawing.Point(9, 613);
            this.setAsReferencePointButton.Margin = new System.Windows.Forms.Padding(2);
            this.setAsReferencePointButton.Name = "setAsReferencePointButton";
            this.setAsReferencePointButton.Size = new System.Drawing.Size(197, 24);
            this.setAsReferencePointButton.TabIndex = 11;
            this.setAsReferencePointButton.Text = "Set actual position as reference point";
            this.setAsReferencePointButton.UseVisualStyleBackColor = true;
            this.setAsReferencePointButton.Click += new System.EventHandler(this.setAsReferencePointButton_Click);
            // 
            // distanceToRefPointTextBox
            // 
            this.distanceToRefPointTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.distanceToRefPointTextBox.Location = new System.Drawing.Point(352, 617);
            this.distanceToRefPointTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.distanceToRefPointTextBox.Name = "distanceToRefPointTextBox";
            this.distanceToRefPointTextBox.ReadOnly = true;
            this.distanceToRefPointTextBox.Size = new System.Drawing.Size(599, 20);
            this.distanceToRefPointTextBox.TabIndex = 13;
            // 
            // distanceToRefPointLabel
            // 
            this.distanceToRefPointLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.distanceToRefPointLabel.AutoSize = true;
            this.distanceToRefPointLabel.Location = new System.Drawing.Point(209, 620);
            this.distanceToRefPointLabel.Name = "distanceToRefPointLabel";
            this.distanceToRefPointLabel.Size = new System.Drawing.Size(138, 13);
            this.distanceToRefPointLabel.TabIndex = 14;
            this.distanceToRefPointLabel.Text = "Distance to reference point:";
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Location = new System.Drawing.Point(16, 45);
            this.logBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logBox.MaxLineCount = 10;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(355, 110);
            this.logBox.TabIndex = 14;
            // 
            // hdopPanel
            // 
            this.hdopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hdopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hdopPanel.Location = new System.Drawing.Point(517, 129);
            this.hdopPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hdopPanel.Name = "hdopPanel";
            this.hdopPanel.Size = new System.Drawing.Size(22, 18);
            this.hdopPanel.TabIndex = 21;
            // 
            // blinkingPanel
            // 
            this.blinkingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blinkingPanel.BackColor = System.Drawing.Color.Gray;
            this.blinkingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.blinkingPanel.Location = new System.Drawing.Point(375, 40);
            this.blinkingPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blinkingPanel.Name = "blinkingPanel";
            this.blinkingPanel.Size = new System.Drawing.Size(21, 20);
            this.blinkingPanel.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 648);
            this.Controls.Add(this.distanceToRefPointLabel);
            this.Controls.Add(this.distanceToRefPointTextBox);
            this.Controls.Add(this.setAsReferencePointButton);
            this.Controls.Add(this.ntripCasterConfigurationGroupBox);
            this.Controls.Add(this.um980SerialPortConfigurationGroupBox);
            this.Controls.Add(this.mapControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UM980 - Positioning - v1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.um980SerialPortConfigurationGroupBox.ResumeLayout(false);
            this.um980SerialPortConfigurationGroupBox.PerformLayout();
            this.ntripCasterConfigurationGroupBox.ResumeLayout(false);
            this.ntripCasterConfigurationGroupBox.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox portsComboBox;
        private System.Windows.Forms.Label lastPacketLabel;
        private System.Windows.Forms.MapControl mapControl;
        private System.Windows.Forms.GroupBox um980SerialPortConfigurationGroupBox;
        private System.Windows.Forms.GroupBox ntripCasterConfigurationGroupBox;
        private System.Windows.Forms.Label bytesReceivedLabel;
        private System.Windows.Forms.Label receptionSpeedLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox longitudeTextBox;
        private System.Windows.Forms.Label longitudeLabel;
        private System.Windows.Forms.TextBox qualityTextBox;
        private System.Windows.Forms.Label signalQualityLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox latitudeTextBox;
        private System.Windows.Forms.Label latitudeLabel;
        private System.Windows.Forms.TextBox satCountTextBox;
        private System.Windows.Forms.Label satCountLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storePositionToFileToolStripMenuItem;
        private System.Windows.Forms.Button configureNtripStreamButton;
        private System.Windows.Forms.Button disconnectButton;
        private Controls.LogBox logBox;
        private System.Windows.Forms.Button disconnectUM980Button;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerOnPositionToolStripMenuItem;
        private System.Windows.Forms.Label lastRTCMTypeLabel;
        private System.Windows.Forms.TextBox rawGGAMSgTextBox;
        private BlinkingPanel blinkingPanel;
        private System.Windows.Forms.TextBox hdopTextBox;
        private System.Windows.Forms.Label hdopLabel;
        private HDOPPanel hdopPanel;
        private System.Windows.Forms.Button setAsReferencePointButton;
        private System.Windows.Forms.TextBox distanceToRefPointTextBox;
        private System.Windows.Forms.Label distanceToRefPointLabel;
    }
}

