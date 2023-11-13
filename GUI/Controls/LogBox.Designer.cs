namespace UM980PositioningGUI.Controls
{
    partial class LogBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logLabel
            // 
            this.logLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logLabel.Location = new System.Drawing.Point(0, 0);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(821, 471);
            this.logLabel.TabIndex = 0;
            // 
            // LogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.logLabel);
            this.Name = "LogBox";
            this.Size = new System.Drawing.Size(657, 377);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label logLabel;
    }
}
