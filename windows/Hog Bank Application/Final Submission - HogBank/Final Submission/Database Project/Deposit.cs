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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void txtCurrentBalance1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal SqlOutput;
            SqlOutput = Walton_DB.RetrieveScalar("SELECT Balance FROM Accounts WHERE CustomerID = " + Login.inputedCustomerID);

            decimal n1;
            decimal.TryParse(DepositAmount.Text, out n1);

            decimal x = (SqlOutput + n1);

            UpdatedAccbalance.Text = x.ToString("C");

            //Walton_DB.ExecSqlString("UPDATE Accounts SET Balance = " + x + "WHERE CustomerID = " + Login.inputedCustomerID);

            SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Balance = " + x + "WHERE CustomerID = " + Login.inputedCustomerID);
            Walton_DB.ExecSqlCommand(ref cmd);
        }


        private void Deposit_Load(object sender, EventArgs e)
        {
            decimal SqlOutput;
            SqlOutput = Walton_DB.RetrieveScalar("SELECT Balance FROM Accounts WHERE CustomerID = " + Login.inputedCustomerID);
            txtAccBalance.Text = SqlOutput.ToString("C");
        }
    }
}
