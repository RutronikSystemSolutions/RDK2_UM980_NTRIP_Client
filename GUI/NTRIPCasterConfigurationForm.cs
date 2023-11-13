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
    public partial class NTRIPCasterConfigurationForm : Form
    {
        private NTRIPSocketClient ntripClient = null;
        private string selectedStation = string.Empty;

        public NTRIPCasterConfigurationForm()
        {
            InitializeComponent();
        }

        public NTRIPCasterConfigurationForm(NTRIPSocketClient ntripClient)
        {
            InitializeComponent();
            this.ntripClient = ntripClient;

            ntripClient.OnNewConnectionState += NtripClient_OnNewConnectionState;
            ntripClient.OnNewCorrectionStations += NtripClient_OnNewCorrectionStations;
            ntripClient.OnError += NtripClient_OnError;
        }

        private void NtripClient_OnError(object sender, string errorMsg)
        {
            logBox.AddLog(errorMsg);
        }

        private void NtripClient_OnNewCorrectionStations(object sender, List<CorrectionStation> stations)
        {
            dataGridView.Rows.Clear();
            foreach(CorrectionStation station in stations)
            {
                string[] row = new string[]
                {
                    station.name,
                    station.identifier,
                    station.format,
                    station.navigationSystem,
                    station.country,
                    station.lat.ToString(),
                    station.lon.ToString(),
                    station.nmeaRequested.ToString()
                };
                if (dataGridView.Columns.Count == row.Length) dataGridView.Rows.Add(row);
            }

            if (stations.Count > 0) connectToNearestButton.Enabled = true;
        }

        private void NtripClient_OnNewConnectionState(object sender, NTRIPSocketClient.ConnectionState state)
        {
            logBox.AddLog(state.ToString());

            if ((state == NTRIPSocketClient.ConnectionState.Iddle) || (state == NTRIPSocketClient.ConnectionState.Error))
            {
                casterAddressTextBox.Enabled = true;
                casterPortTextBox.Enabled = true;
                loginTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                getSourceTableButton.Enabled = true;
            }
            else
            {
                casterAddressTextBox.Enabled = false;
                casterPortTextBox.Enabled = false;
                loginTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                getSourceTableButton.Enabled = false;
            }
        }

        private void NTRIPCasterConfigurationForm_Load(object sender, EventArgs e)
        {
            casterAddressTextBox.Text = Properties.Settings.Default.casterAddress;
            casterPortTextBox.Text = Properties.Settings.Default.casterPort;
            loginTextBox.Text = Properties.Settings.Default.userName;
            passwordTextBox.Text = Properties.Settings.Default.password;
        }

        private void getSourceTableButton_Click(object sender, EventArgs e)
        {
            connectToNearestButton.Enabled = false;
            connectToSelectedButton.Enabled = false;
            dataGridView.Rows.Clear();

            string addr = casterAddressTextBox.Text;
            if (addr.Length == 0)
            {
                MessageBox.Show("Address cannot be empty!");
                return;
            }

            int port = 0;
            try
            {
                port = Convert.ToInt32(casterPortTextBox.Text);
                if (port < 0) throw new Exception("Invalid port");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Port is invalid: " + ex.Message);
                return;
            }

            // Allright store the parameters
            Properties.Settings.Default.casterAddress = casterAddressTextBox.Text;
            Properties.Settings.Default.casterPort = casterPortTextBox.Text;
            Properties.Settings.Default.userName = loginTextBox.Text;
            Properties.Settings.Default.password = passwordTextBox.Text;
            Properties.Settings.Default.Save();

            // Request source table
            ntripClient.RequestSourceTable(addr, port, loginTextBox.Text, passwordTextBox.Text);
        }

        private void NTRIPCasterConfigurationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ntripClient != null)
            {
                ntripClient.OnNewConnectionState -= NtripClient_OnNewConnectionState;
                ntripClient.OnNewCorrectionStations -= NtripClient_OnNewCorrectionStations;
                ntripClient.OnError -= NtripClient_OnError;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            List<CorrectionStation> correctionStations = ntripClient.GetCorrectionStations();
            int selectedRowCount = dataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);

            connectToSelectedButton.Enabled = false;

            if (correctionStations == null) return;
            if (selectedRowCount != 1) return;
            if (dataGridView.SelectedRows[0].Index >= correctionStations.Count) return;

            selectedStation = correctionStations[dataGridView.SelectedRows[0].Index].name;
            connectToSelectedButton.Enabled = true;
        }

        private void connectToNearestButton_Click(object sender, EventArgs e)
        {
            ntripClient.RequestCorrectionValues(NTRIPSocketClient.ConfigurationMode.ConnectToNearest, string.Empty);
            Close();
        }

        private void connectToSelectedButton_Click(object sender, EventArgs e)
        {
            ntripClient.RequestCorrectionValues(NTRIPSocketClient.ConfigurationMode.ConnectToSelected, selectedStation);
            Close();
        }
    }
}
