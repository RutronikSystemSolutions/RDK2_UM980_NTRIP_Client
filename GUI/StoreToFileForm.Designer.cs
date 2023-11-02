namespace UM980PositioningGUI
{
    partial class StoreToFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreToFileForm));
            this.storePositionGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.storePositionPathTextBox = new System.Windows.Forms.TextBox();
            this.storePositionButton = new System.Windows.Forms.Button();
            this.stopRecordingPositionButton = new System.Windows.Forms.Button();
            this.storePositionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // storePositionGroupBox
            // 
            this.storePositionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storePositionGroupBox.Controls.Add(this.stopRecordingPositionButton);
            this.storePositionGroupBox.Controls.Add(this.storePositionButton);
            this.storePositionGroupBox.Controls.Add(this.storePositionPathTextBox);
            this.storePositionGroupBox.Controls.Add(this.label1);
            this.storePositionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.storePositionGroupBox.Name = "storePositionGroupBox";
            this.storePositionGroupBox.Size = new System.Drawing.Size(776, 85);
            this.storePositionGroupBox.TabIndex = 0;
            this.storePositionGroupBox.TabStop = false;
            this.storePositionGroupBox.Text = "Store position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path:";
            // 
            // storePositionPathTextBox
            // 
            this.storePositionPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storePositionPathTextBox.Location = new System.Drawing.Point(44, 25);
            this.storePositionPathTextBox.Name = "storePositionPathTextBox";
            this.storePositionPathTextBox.ReadOnly = true;
            this.storePositionPathTextBox.Size = new System.Drawing.Size(645, 20);
            this.storePositionPathTextBox.TabIndex = 1;
            // 
            // storePositionButton
            // 
            this.storePositionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.storePositionButton.Location = new System.Drawing.Point(695, 23);
            this.storePositionButton.Name = "storePositionButton";
            this.storePositionButton.Size = new System.Drawing.Size(75, 23);
            this.storePositionButton.TabIndex = 2;
            this.storePositionButton.Text = "...";
            this.storePositionButton.UseVisualStyleBackColor = true;
            this.storePositionButton.Click += new System.EventHandler(this.storePositionButton_Click);
            // 
            // stopRecordingPositionButton
            // 
            this.stopRecordingPositionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopRecordingPositionButton.Location = new System.Drawing.Point(44, 51);
            this.stopRecordingPositionButton.Name = "stopRecordingPositionButton";
            this.stopRecordingPositionButton.Size = new System.Drawing.Size(645, 23);
            this.stopRecordingPositionButton.TabIndex = 1;
            this.stopRecordingPositionButton.Text = "Stop recording";
            this.stopRecordingPositionButton.UseVisualStyleBackColor = true;
            this.stopRecordingPositionButton.Click += new System.EventHandler(this.stopRecordingPositionButton_Click);
            // 
            // StoreToFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 108);
            this.Controls.Add(this.storePositionGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StoreToFileForm";
            this.Text = "Store to file";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StoreToFileForm_FormClosed);
            this.storePositionGroupBox.ResumeLayout(false);
            this.storePositionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox storePositionGroupBox;
        private System.Windows.Forms.TextBox storePositionPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button storePositionButton;
        private System.Windows.Forms.Button stopRecordingPositionButton;
    }
}