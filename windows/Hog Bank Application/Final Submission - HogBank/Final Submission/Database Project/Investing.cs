using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Investing : Form
    {
        public Investing()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void Investing_Load(object sender, EventArgs e)
        {
            object SqlOutput;
            SqlOutput = Walton_DB.RetrieveSingleValue("SELECT InvestmentAmount FROM Investments WHERE CustomerID = " + Login.inputedCustomerID);
            txtCurrent.Text = "$" + SqlOutput.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            object SqlOutput;
            SqlOutput = Walton_DB.RetrieveSingleValue("SELECT InvestmentAmount FROM Investments WHERE CustomerID = " + Login.inputedCustomerID);

            int n1;
            int.TryParse(textBox1.Text, out n1);

            int x = (Convert.ToInt32(SqlOutput) + n1);

            textBox3.Text = "$" + x.ToString();

            SqlCommand cmd = new SqlCommand("UPDATE Investments SET InvestmentAmount = " + x + "WHERE CustomerID = " + Login.inputedCustomerID);
            Walton_DB.ExecSqlCommand(ref cmd);
        }
    }
}
