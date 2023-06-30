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

        

        private void HomePage_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Walton_DB.OpenConnection().ToString());
            lblDay.Text = DateTime.Now.ToShortDateString();
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

        private void accountBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Students();
            newForm.Show();
        }

        private void instructorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new EmployeeReport(); //globally named EmployeeReport, Actual name is Teachers
            newForm.Show();
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Classes();
            newForm.Show();
        }

        private void enrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new Enroll();
            newForm.Show();
        }
    }
}
