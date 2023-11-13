namespace UM980PositioningGUI
{
    partial class NTRIPCasterConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTRIPCasterConfigurationForm));
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.getSourceTableButton = new System.Windows.Forms.Button();
            this.casterPortTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.casterAddressTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.mountPointColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.navSystemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmeaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectToNearestButton = new System.Windows.Forms.Button();
            this.connectToSelectedButton = new System.Windows.Forms.Button();
            this.logBox = new UM980PositioningGUI.Controls.LogBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(282, 40);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(124, 22);
            this.passwordTextBox.TabIndex = 20;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(207, 44);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(73, 17);
            this.passwordLabel.TabIndex = 19;
            this.passwordLabel.Text = "Password:";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(77, 39);
            this.loginTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(124, 22);
            this.loginTextBox.TabIndex = 18;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(13, 43);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(47, 17);
            this.loginLabel.TabIndex = 17;
            this.loginLabel.Text = "Login:";
            // 
            // getSourceTableButton
            // 
            this.getSourceTableButton.Location = new System.Drawing.Point(413, 9);
            this.getSourceTableButton.Margin = new System.Windows.Forms.Padding(4);
            this.getSourceTableButton.Name = "getSourceTableButton";
            this.getSourceTableButton.Size = new System.Drawing.Size(139, 53);
            this.getSourceTableButton.TabIndex = 16;
            this.getSourceTableButton.Text = "Get source table";
            this.getSourceTableButton.UseVisualStyleBackColor = true;
            this.getSourceTableButton.Click += new System.EventHandler(this.getSourceTableButton_Click);
            // 
            // casterPortTextBox
            // 
            this.casterPortTextBox.Location = new System.Drawing.Point(305, 11);
            this.casterPortTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.casterPortTextBox.Name = "casterPortTextBox";
            this.casterPortTextBox.Size = new System.Drawing.Size(101, 22);
            this.casterPortTextBox.TabIndex = 15;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(265, 15);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(38, 17);
            this.portLabel.TabIndex = 14;
            this.portLabel.Text = "Port:";
            // 
            // casterAddressTextBox
            // 
            this.casterAddressTextBox.Location = new System.Drawing.Point(77, 11);
            this.casterAddressTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.casterAddressTextBox.Name = "casterAddressTextBox";
            this.casterAddressTextBox.Size = new System.Drawing.Size(183, 22);
            this.casterAddressTextBox.TabIndex = 13;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(13, 15);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(64, 17);
            this.addressLabel.TabIndex = 12;
            this.addressLabel.Text = "Address:";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mountPointColumn,
            this.identifierColumn,
            this.formatColumn,
            this.navSystemColumn,
            this.countryColumn,
            this.latColumn,
            this.lonColumn,
            this.nmeaColumn});
            this.dataGridView.Location = new System.Drawing.Point(16, 84);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1087, 510);
            this.dataGridView.TabIndex = 21;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // mountPointColumn
            // 
            this.mountPointColumn.HeaderText = "Mount Point";
            this.mountPointColumn.MinimumWidth = 6;
            this.mountPointColumn.Name = "mountPointColumn";
            this.mountPointColumn.ReadOnly = true;
            // 
            // identifierColumn
            // 
            this.identifierColumn.HeaderText = "Identifier";
            this.identifierColumn.MinimumWidth = 6;
            this.identifierColumn.Name = "identifierColumn";
            this.identifierColumn.ReadOnly = true;
            // 
            // formatColumn
            // 
            this.formatColumn.HeaderText = "Format";
            this.formatColumn.MinimumWidth = 6;
            this.formatColumn.Name = "formatColumn";
            this.formatColumn.ReadOnly = true;
            // 
            // navSystemColumn
            // 
            this.navSystemColumn.HeaderText = "Navigation system";
            this.navSystemColumn.MinimumWidth = 6;
            this.navSystemColumn.Name = "navSystemColumn";
            this.navSystemColumn.ReadOnly = true;
            // 
            // countryColumn
            // 
            this.countryColumn.HeaderText = "Country";
            this.countryColumn.MinimumWidth = 6;
            this.countryColumn.Name = "countryColumn";
            this.countryColumn.ReadOnly = true;
            // 
            // latColumn
            // 
            this.latColumn.HeaderText = "Latitude";
            this.latColumn.MinimumWidth = 6;
            this.latColumn.Name = "latColumn";
            this.latColumn.ReadOnly = true;
            // 
            // lonColumn
            // 
            this.lonColumn.HeaderText = "Longitude";
            this.lonColumn.MinimumWidth = 6;
            this.lonColumn.Name = "lonColumn";
            this.lonColumn.ReadOnly = true;
            // 
            // nmeaColumn
            // 
            this.nmeaColumn.HeaderText = "NMEA requested";
            this.nmeaColumn.MinimumWidth = 6;
            this.nmeaColumn.Name = "nmeaColumn";
            this.nmeaColumn.ReadOnly = true;
            // 
            // connectToNearestButton
            // 
            this.connectToNearestButton.Enabled = false;
            this.connectToNearestButton.Location = new System.Drawing.Point(559, 9);
            this.connectToNearestButton.Name = "connectToNearestButton";
            this.connectToNearestButton.Size = new System.Drawing.Size(160, 53);
            this.connectToNearestButton.TabIndex = 22;
            this.connectToNearestButton.Text = "Connect to nearest";
            this.connectToNearestButton.UseVisualStyleBackColor = true;
            this.connectToNearestButton.Click += new System.EventHandler(this.connectToNearestButton_Click);
            // 
            // connectToSelectedButton
            // 
            this.connectToSelectedButton.Enabled = false;
            this.connectToSelectedButton.Location = new System.Drawing.Point(725, 9);
            this.connectToSelectedButton.Name = "connectToSelectedButton";
            this.connectToSelectedButton.Size = new System.Drawing.Size(160, 53);
            this.connectToSelectedButton.TabIndex = 24;
            this.connectToSelectedButton.Text = "Connect to selected mount point";
            this.connectToSelectedButton.UseVisualStyleBackColor = true;
            this.connectToSelectedButton.Click += new System.EventHandler(this.connectToSelectedButton_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Location = new System.Drawing.Point(16, 600);
            this.logBox.MaxLineCount = 10;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(1087, 124);
            this.logBox.TabIndex = 25;
            // 
            // NTRIPCasterConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 736);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.connectToSelectedButton);
            this.Controls.Add(this.connectToNearestButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.getSourceTableButton);
            this.Controls.Add(this.casterPortTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.casterAddressTextBox);
            this.Controls.Add(this.addressLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NTRIPCasterConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NTRIP Caster Configuration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NTRIPCasterConfigurationForm_FormClosed);
            this.Load += new System.EventHandler(this.NTRIPCasterConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Button getSourceTableButton;
        private System.Windows.Forms.TextBox casterPortTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox casterAddressTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn mountPointColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn navSystemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmeaColumn;
        private System.Windows.Forms.Button connectToNearestButton;
        private System.Windows.Forms.Button connectToSelectedButton;
        private Controls.LogBox logBox;
    }
}