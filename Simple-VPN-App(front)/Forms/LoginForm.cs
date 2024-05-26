using Simple_VPN_App_front_.Data.Services;
using Simple_VPN_App_front_.Dto;
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
    public partial class LoginForm : Form
    {
        private readonly ApiService _apiService;

        public LoginForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Login button click
            var user = new UserLoginDto
            {
                Username = textBox1.Text,
                Password = textBox2.Text
            };

            var token = await _apiService.LoginUser(user);

            if (token != null)
            {
                MessageBox.Show("Login successful!");
                var vpnForm = new VpnForm(token);
                vpnForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Register button click
            var registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true; // Mask the password field
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
