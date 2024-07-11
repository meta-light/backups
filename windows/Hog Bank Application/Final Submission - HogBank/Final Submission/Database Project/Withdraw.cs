using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            decimal SqlOutput;
            SqlOutput = Walton_DB.RetrieveScalar("SELECT Balance FROM Accounts WHERE CustomerID = " + Login.inputedCustomerID);
            txtAccBalance.Text = SqlOutput.ToString("C");
        }

        private void txtChecking2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            decimal SqlOutput;
            SqlOutput = Walton_DB.RetrieveScalar("SELECT Balance FROM Accounts WHERE CustomerID = " + Login.inputedCustomerID);

            decimal n1;
            decimal.TryParse(txtWithdraw.Text, out n1);

            decimal x = (SqlOutput - n1);

            textBox1.Text = x.ToString("C");

            //Walton_DB.ExecSqlString("UPDATE Accounts SET CustomerID = " + x + "WHERE CustomerID = " + Login.inputedCustomerID);

            SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Balance = " + x + "WHERE CustomerID = " + Login.inputedCustomerID);
            Walton_DB.ExecSqlCommand(ref cmd);
        }
    }
}
