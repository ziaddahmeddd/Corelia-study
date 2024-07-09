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
    public partial class login : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DataTable dataTable = new DataTable();
            string username = textBox1.Text;
            string password = textBox2.Text;
            dataTable= db.ValidateUser(username, password);
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                ProfileForm data = new ProfileForm(dr);
                data.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("failed!");
            }
        }
    }
}
