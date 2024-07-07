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
    public partial class profile : Form
    {
        private DataRow row;
        public profile()
        {
            InitializeComponent();
        }
        public profile(DataRow x)
        {
            InitializeComponent();
            this.row = x;
            label1.Text = $"Welcome {x["username"].ToString()}!";   
        }
        
    }
}
