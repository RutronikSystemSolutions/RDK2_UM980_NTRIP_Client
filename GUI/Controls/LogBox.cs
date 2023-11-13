using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UM980PositioningGUI.Controls
{
    public partial class LogBox : UserControl
    {
        private List<string> logs = new List<string>();
        private int maxLineCount = 10;

        public LogBox()
        {
            InitializeComponent();
        }

        public int MaxLineCount
        {
            get { return maxLineCount; }
            set { maxLineCount = value; }
        }

        public void AddLog(string text)
        {
            logs.Add(text);
            if (logs.Count > maxLineCount) logs.RemoveAt(0);

            StringBuilder builder = new StringBuilder();
            for(int i = logs.Count - 1; i >= 0; --i)
            {
                builder.AppendLine(logs[i]);
            }

            logLabel.Text = builder.ToString();
        }
    }
}
