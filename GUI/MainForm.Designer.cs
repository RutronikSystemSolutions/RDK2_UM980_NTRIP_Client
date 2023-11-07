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
            this.ntripClientConnectButton = new System.Windows.Forms.Button();
            this.ntripClientLogLabel = new System.Windows.Forms.Label();
            this.receptionSpeedLabel = new System.Windows.Forms.Label();
            this.bytesReceivedLabel = new System.Windows.Forms.Label();
            this.casterPortTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.casterAddressTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storePositionToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.um980SerialPortConfigurationGroupBox.SuspendLayout();
            this.ntripCasterConfigurationGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(243, 21);
            this.connectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // portsComboBox
            // 
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(5, 21);
            this.portsComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(231, 24);
            this.portsComboBox.TabIndex = 3;
            // 
            // lastPacketLabel
            // 
            this.lastPacketLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastPacketLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lastPacketLabel.Location = new System.Drawing.Point(5, 48);
            this.lastPacketLabel.Name = "lastPacketLabel";
            this.lastPacketLabel.Size = new System.Drawing.Size(525, 127);
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
            this.mapControl.Location = new System.Drawing.Point(12, 225);
            this.mapControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mapControl.Name = "mapControl";
            this.mapControl.ShowThumbnails = true;
            this.mapControl.Size = new System.Drawing.Size(1255, 548);
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
            this.um980SerialPortConfigurationGroupBox.Location = new System.Drawing.Point(15, 32);
            this.um980SerialPortConfigurationGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.um980SerialPortConfigurationGroupBox.Name = "um980SerialPortConfigurationGroupBox";
            this.um980SerialPortConfigurationGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.um980SerialPortConfigurationGroupBox.Size = new System.Drawing.Size(749, 189);
            this.um980SerialPortConfigurationGroupBox.TabIndex = 8;
            this.um980SerialPortConfigurationGroupBox.TabStop = false;
            this.um980SerialPortConfigurationGroupBox.Text = "UM980 - Serial port configuration";
            // 
            // satCountTextBox
            // 
            this.satCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.satCountTextBox.Location = new System.Drawing.Point(621, 130);
            this.satCountTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.satCountTextBox.Name = "satCountTextBox";
            this.satCountTextBox.ReadOnly = true;
            this.satCountTextBox.Size = new System.Drawing.Size(100, 22);
            this.satCountTextBox.TabIndex = 15;
            // 
            // satCountLabel
            // 
            this.satCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.satCountLabel.AutoSize = true;
            this.satCountLabel.Location = new System.Drawing.Point(540, 134);
            this.satCountLabel.Name = "satCountLabel";
            this.satCountLabel.Size = new System.Drawing.Size(76, 17);
            this.satCountLabel.TabIndex = 14;
            this.satCountLabel.Text = "Sat. count:";
            // 
            // qualityTextBox
            // 
            this.qualityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qualityTextBox.Location = new System.Drawing.Point(621, 102);
            this.qualityTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.qualityTextBox.Name = "qualityTextBox";
            this.qualityTextBox.ReadOnly = true;
            this.qualityTextBox.Size = new System.Drawing.Size(100, 22);
            this.qualityTextBox.TabIndex = 13;
            // 
            // signalQualityLabel
            // 
            this.signalQualityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.signalQualityLabel.AutoSize = true;
            this.signalQualityLabel.Location = new System.Drawing.Point(558, 105);
            this.signalQualityLabel.Name = "signalQualityLabel";
            this.signalQualityLabel.Size = new System.Drawing.Size(56, 17);
            this.signalQualityLabel.TabIndex = 12;
            this.signalQualityLabel.Text = "Quality:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(726, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "°";
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.latitudeTextBox.Location = new System.Drawing.Point(621, 74);
            this.latitudeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.ReadOnly = true;
            this.latitudeTextBox.Size = new System.Drawing.Size(100, 22);
            this.latitudeTextBox.TabIndex = 10;
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Location = new System.Drawing.Point(552, 77);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(63, 17);
            this.latitudeLabel.TabIndex = 9;
            this.latitudeLabel.Text = "Latitude:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(726, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "°";
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.longitudeTextBox.Location = new System.Drawing.Point(621, 46);
            this.longitudeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.ReadOnly = true;
            this.longitudeTextBox.Size = new System.Drawing.Size(100, 22);
            this.longitudeTextBox.TabIndex = 7;
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Location = new System.Drawing.Point(540, 49);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(75, 17);
            this.longitudeLabel.TabIndex = 6;
            this.longitudeLabel.Text = "Longitude:";
            // 
            // ntripCasterConfigurationGroupBox
            // 
            this.ntripCasterConfigurationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.passwordTextBox);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.passwordLabel);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.loginTextBox);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.loginLabel);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.ntripClientConnectButton);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.ntripClientLogLabel);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.receptionSpeedLabel);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.bytesReceivedLabel);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.casterPortTextBox);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.portLabel);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.casterAddressTextBox);
            this.ntripCasterConfigurationGroupBox.Controls.Add(this.addressLabel);
            this.ntripCasterConfigurationGroupBox.Location = new System.Drawing.Point(769, 32);
            this.ntripCasterConfigurationGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ntripCasterConfigurationGroupBox.Name = "ntripCasterConfigurationGroupBox";
            this.ntripCasterConfigurationGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ntripCasterConfigurationGroupBox.Size = new System.Drawing.Size(501, 189);
            this.ntripCasterConfigurationGroupBox.TabIndex = 9;
            this.ntripCasterConfigurationGroupBox.TabStop = false;
            this.ntripCasterConfigurationGroupBox.Text = "NTRIP Caster - Connection configuration";
            // 
            // ntripClientConnectButton
            // 
            this.ntripClientConnectButton.Location = new System.Drawing.Point(391, 18);
            this.ntripClientConnectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ntripClientConnectButton.Name = "ntripClientConnectButton";
            this.ntripClientConnectButton.Size = new System.Drawing.Size(100, 28);
            this.ntripClientConnectButton.TabIndex = 7;
            this.ntripClientConnectButton.Text = "Connect";
            this.ntripClientConnectButton.UseVisualStyleBackColor = true;
            this.ntripClientConnectButton.Click += new System.EventHandler(this.ntripClientConnectButton_Click);
            // 
            // ntripClientLogLabel
            // 
            this.ntripClientLogLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntripClientLogLabel.Location = new System.Drawing.Point(22, 77);
            this.ntripClientLogLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntripClientLogLabel.Name = "ntripClientLogLabel";
            this.ntripClientLogLabel.Size = new System.Drawing.Size(469, 84);
            this.ntripClientLogLabel.TabIndex = 6;
            this.ntripClientLogLabel.Text = "---";
            // 
            // receptionSpeedLabel
            // 
            this.receptionSpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.receptionSpeedLabel.AutoSize = true;
            this.receptionSpeedLabel.Location = new System.Drawing.Point(373, 165);
            this.receptionSpeedLabel.Name = "receptionSpeedLabel";
            this.receptionSpeedLabel.Size = new System.Drawing.Size(72, 17);
            this.receptionSpeedLabel.TabIndex = 5;
            this.receptionSpeedLabel.Text = "--- bytes/s";
            // 
            // bytesReceivedLabel
            // 
            this.bytesReceivedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bytesReceivedLabel.AutoSize = true;
            this.bytesReceivedLabel.Location = new System.Drawing.Point(5, 165);
            this.bytesReceivedLabel.Name = "bytesReceivedLabel";
            this.bytesReceivedLabel.Size = new System.Drawing.Size(123, 17);
            this.bytesReceivedLabel.TabIndex = 4;
            this.bytesReceivedLabel.Text = "--- bytes received.";
            // 
            // casterPortTextBox
            // 
            this.casterPortTextBox.Location = new System.Drawing.Point(311, 21);
            this.casterPortTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.casterPortTextBox.Name = "casterPortTextBox";
            this.casterPortTextBox.Size = new System.Drawing.Size(72, 22);
            this.casterPortTextBox.TabIndex = 3;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(271, 25);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(38, 17);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port:";
            // 
            // casterAddressTextBox
            // 
            this.casterAddressTextBox.Location = new System.Drawing.Point(83, 21);
            this.casterAddressTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.casterAddressTextBox.Name = "casterAddressTextBox";
            this.casterAddressTextBox.Size = new System.Drawing.Size(183, 22);
            this.casterAddressTextBox.TabIndex = 1;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(19, 25);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(64, 17);
            this.addressLabel.TabIndex = 0;
            this.addressLabel.Text = "Address:";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1279, 28);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storePositionToFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // storePositionToFileToolStripMenuItem
            // 
            this.storePositionToFileToolStripMenuItem.Name = "storePositionToFileToolStripMenuItem";
            this.storePositionToFileToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.storePositionToFileToolStripMenuItem.Text = "Store to file";
            this.storePositionToFileToolStripMenuItem.Click += new System.EventHandler(this.storePositionToFileToolStripMenuItem_Click);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(83, 49);
            this.loginTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(124, 22);
            this.loginTextBox.TabIndex = 9;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(19, 53);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(47, 17);
            this.loginLabel.TabIndex = 8;
            this.loginLabel.Text = "Login:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(288, 50);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(124, 22);
            this.passwordTextBox.TabIndex = 11;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(213, 54);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(73, 17);
            this.passwordLabel.TabIndex = 10;
            this.passwordLabel.Text = "Password:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 787);
            this.Controls.Add(this.ntripCasterConfigurationGroupBox);
            this.Controls.Add(this.um980SerialPortConfigurationGroupBox);
            this.Controls.Add(this.mapControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "UM980 - Positioning";
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
        private System.Windows.Forms.TextBox casterAddressTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox casterPortTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label bytesReceivedLabel;
        private System.Windows.Forms.Label receptionSpeedLabel;
        private System.Windows.Forms.Label ntripClientLogLabel;
        private System.Windows.Forms.Button ntripClientConnectButton;
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
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
    }
}

