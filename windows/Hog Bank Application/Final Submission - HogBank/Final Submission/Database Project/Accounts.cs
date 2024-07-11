using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Accounts : Form
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void Accounts_Load(object sender, EventArgs e)
        {

        }
    }
}
