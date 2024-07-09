using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ProfileForm : Form
    {
        private DataRow row;

        public ProfileForm(DataRow x)
        {
            InitializeComponent();
            this.row = x;
            usernameLabel.Text = "Username: " + x["username"];
            emailLabel.Text = "Email: " + x["email"];
        }




    }
}
