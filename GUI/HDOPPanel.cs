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
    public partial class HDOPPanel : UserControl
    {
        public HDOPPanel()
        {
            InitializeComponent();
        }

        public void SetValue(double hdopValue)
        {
            if (hdopValue < 1)
            {
                // Ideal
                BackColor = Color.Lime;
            }
            else if (hdopValue < 2)
            {
                // Excellent
                BackColor = Color.Lime;
            }
            else if (hdopValue < 5)
            {
                // Good
                BackColor = Color.Lime;
            }
            else if (hdopValue < 10)
            {
                // Moderate
                BackColor = Color.Yellow;
            }
            else if (hdopValue < 20)
            {
                // Fair
                BackColor = Color.Orange;
            }
            else
            {
                // Poor
                BackColor = Color.Red;
            }
        }
    }
}
