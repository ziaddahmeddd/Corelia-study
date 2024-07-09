using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class register : Form
    {
        private DatabaseHelper databaseHelper = new DatabaseHelper();

        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string email = (string)textBox1.Text;
            string username = (string)textBox2.Text;
            string password = (string)textBox3.Text;
            bool IsRegister = databaseHelper.RegisterUser(email, username, password);
            if (IsRegister)
            {
                MessageBox.Show("register success");
                login l = new login();
                l.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("failed!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
