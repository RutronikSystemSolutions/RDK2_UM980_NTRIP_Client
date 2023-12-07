using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UM980PositioningGUI
{
    public partial class BlinkingPanel : UserControl
    {
        public BlinkingPanel()
        {
            InitializeComponent();
        }

        public void Trigger()
        {
            BackColor = Color.Green;
            if (backgroundWorker.IsBusy == false) backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(250);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackColor = Color.Gray;
        }
    }
}
