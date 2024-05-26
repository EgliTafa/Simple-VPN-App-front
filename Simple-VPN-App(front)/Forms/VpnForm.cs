using Simple_VPN_App_front_.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_VPN_App_front_.Forms
{
    public partial class VpnForm : Form
    {
        private readonly ApiService _apiService;
        private readonly string _token;

        public VpnForm(string token)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _token = token;

            // Set the token in the ApiService
            _apiService.SetToken(_token);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Logout button click
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
    }
}
