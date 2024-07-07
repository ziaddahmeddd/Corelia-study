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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login L = new Login(); 
            L.Show();
            this.Hide();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Signup S = new Signup();
            S.Show();
            this.Hide();
        }
    }
}
