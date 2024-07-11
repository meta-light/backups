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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database_Project
{
    public partial class Loans : Form
    {
        public Loans()
        {
            InitializeComponent();
        }

        private void Loans_Load(object sender, EventArgs e)
        {
            object SqlOutput;
            SqlOutput = Walton_DB.RetrieveSingleValue("SELECT Balance FROM Loans WHERE CustomerID = " + Login.inputedCustomerID);
            textBox2.Text = "$" + SqlOutput.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            object SqlOutput;
            SqlOutput = Walton_DB.RetrieveSingleValue("SELECT Balance FROM Loans WHERE CustomerID = " + Login.inputedCustomerID);

            int n1;
            int.TryParse(textBox1.Text, out n1);

            Int64 x = (Convert.ToInt64(SqlOutput) + Convert.ToInt64(n1));

            textBox4.Text = "$" + x.ToString();

            SqlCommand cmd = new SqlCommand("UPDATE Loan SET Balance = " + x + "WHERE CustomerID = " + Login.inputedCustomerID);
            Walton_DB.ExecSqlCommand(ref cmd);

        }
    }
}
