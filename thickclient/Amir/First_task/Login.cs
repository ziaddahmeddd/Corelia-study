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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Database DB = new Database();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                DataTable userData = DB.Login(username, password);

                if (userData != null && userData.Rows.Count > 0)
                {
                    
                    MessageBox.Show("Login successful!");
                    DataRow dataRow = userData.Rows[0];
                    profile user = new profile(dataRow);
                    user.Show();
                    this.Hide();
                }
                else
                {
                    // User authentication failed
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
        }
    }
}
