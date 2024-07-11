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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Accounts();
            newForm.Show();


        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Deposit();
            newForm.Show();

        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Withdraw();
            newForm.Show();

        }

        private void investingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Investing();
            newForm.Show();
        }

        private void accountBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Accbalance();
            newForm.Show();

        }

        private void loansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Loans();
            newForm.Show();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Walton_DB.OpenConnection().ToString());
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void returnToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Login();
            newForm.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //public void RetreiveAccountBalance()
        //{
        //    int accountBalance = Walton_DB.CreateArrayList_ViaSql("")
        //}
    }
}
