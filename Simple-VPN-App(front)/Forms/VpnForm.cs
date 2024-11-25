using Simple_VPN_App_front_.Data.Services;
using Timer = System.Windows.Forms.Timer;

namespace Simple_VPN_App_front_.Forms
{
    public partial class VpnForm : Form
    {
        private readonly ApiService _apiService;
        private readonly string _token;
        private readonly Timer statusTimer;

        public VpnForm(string token)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _token = token;
            _apiService.SetToken(_token);

            buttonDisconnect.Enabled = false; // Disable disconnect button by default

            // Set up the status timer
            statusTimer = new Timer();
            statusTimer.Interval = 5000; // 5000ms = 5 seconds
            statusTimer.Tick += async (s, e) => await UpdateStatusAsync();
            statusTimer.Start();
        }

        private async Task UpdateStatusAsync()
        {
            // Call the status API to get the current VPN status
            var status = await _apiService.GetVpnStatus();
            if (status == "Connected")
            {
                labelStatus.Text = "CONNECTED";
                labelStatus.ForeColor = Color.Green;
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
            }
            else
            {
                labelStatus.Text = "DISCONNECTED";
                labelStatus.ForeColor = Color.Red;
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
            }
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            bool useTcp = radioButtonTcp.Checked;

            var result = await _apiService.ConnectVpn(useTcp);

            if (result)
            {
                labelStatus.Text = "CONNECTED";
                labelStatus.ForeColor = Color.Green;
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
            }
            else
            {
                labelStatus.Text = "Failed to connect VPN.";
                labelStatus.ForeColor = Color.Red;
            }
        }

        private async void buttonDisconnect_Click(object sender, EventArgs e)
        {
            var result = await _apiService.DisconnectVpn();

            if (result)
            {
                labelStatus.Text = "DISCONNECTED";
                labelStatus.ForeColor = Color.Red;
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
            }
            else
            {
                labelStatus.Text = "Failed to disconnect VPN.";
                labelStatus.ForeColor = Color.Red;
            }
        }

        private async void buttonStatus_Click(object sender, EventArgs e)
        {
            await UpdateStatusAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = await _apiService.LogoutUser();

            if (result)
            {
                MessageBox.Show("Logout successful!");
                this.Close(); // Close the VPN form
                var loginForm = new LoginForm();
                loginForm.Show(); // Show the login form again
            }
            else
            {
                MessageBox.Show("Logout failed. Please try again.");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Stop the timer to avoid memory leaks
            statusTimer?.Stop();
            statusTimer?.Dispose();
        }
    }
}
