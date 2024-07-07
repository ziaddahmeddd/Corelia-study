using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_task
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            Database DB = new Database();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                bool success = DB.Insert(username, password);

                if (success)
                {
                    MessageBox.Show("Signup successful!");
                    Login L = new Login();
                    L.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Signup failed. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
        }
    }
}
