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
    public partial class Accbalance : Form
    {
        public Accbalance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void Accbalance_Load(object sender, EventArgs e)
        {
            decimal SqlOutput;
            SqlOutput = Walton_DB.RetrieveScalar("SELECT Balance FROM Accounts WHERE CustomerID = " + Login.inputedCustomerID);
            txtAccBalance.Text = SqlOutput.ToString("C");
        }
    }
}
