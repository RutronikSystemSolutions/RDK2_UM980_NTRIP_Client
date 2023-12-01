using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UM980PositioningGUI
{
    public partial class StoreToFileForm : Form
    {
        private DataRecorder positionRecorder;

        public StoreToFileForm()
        {
            InitializeComponent();
        }

        public StoreToFileForm(DataRecorder positionRecorder)
        {
            InitializeComponent();
            this.positionRecorder = positionRecorder;
            this.positionRecorder.OnNewState += PositionRecorder_OnNewState;
            PositionRecorder_OnNewState(null);
        }

        private void PositionRecorder_OnNewState(object sender)
        {
            if (positionRecorder == null) return;

            if (positionRecorder.IsStarted())
            {
                storePositionButton.Enabled = false;
                stopRecordingPositionButton.Enabled = true;
                storePositionPathTextBox.Text = positionRecorder.Path;
            }
            else
            {
                storePositionButton.Enabled = true;
                stopRecordingPositionButton.Enabled = false;
            }
        }

        private void storePositionButton_Click(object sender, EventArgs e)
        {
            if (this.positionRecorder == null) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files | *.csv";
            sfd.DefaultExt = "csv";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            positionRecorder.Start(sfd.FileName);
            string toStore = GGAPacket.GetCsvHeader();
            positionRecorder.Store(Encoding.ASCII.GetBytes(toStore));
        }

        private void stopRecordingPositionButton_Click(object sender, EventArgs e)
        {
            positionRecorder.Stop();
        }

        private void StoreToFileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (positionRecorder != null) positionRecorder.OnNewState -= PositionRecorder_OnNewState;
        }
    }
}
