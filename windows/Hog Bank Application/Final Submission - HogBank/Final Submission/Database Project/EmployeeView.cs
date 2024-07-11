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
    public partial class EmployeeView : Form
    {
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void accountBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Customer();
            newForm.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Investments();
            newForm.Show();
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Employees();
            newForm.Show();
        }

        private void investingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new InvestmentReport();
            newForm.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new EmployeeReport();
            newForm.Show();
        }

        private void loansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new CustomerProfile();
            newForm.Show();
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void returnToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Login();
            newForm.Show();
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
