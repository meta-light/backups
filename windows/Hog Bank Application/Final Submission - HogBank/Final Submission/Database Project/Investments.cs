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
using System.Xml.Linq;

namespace Database_Project
{
    public partial class Investments : Form
    {
        DataTable dtInvestments = new DataTable();
        public Investments()
        {
            InitializeComponent();
            FillInvestmentDGV();
        }

        private void FillInvestmentDGV()
        {
            string sqlInvestments = "SELECT * From Investments ORDER BY CustomerID";

            if (Walton_DB.FillDataTable_ViaSql(ref dtInvestments, sqlInvestments) == true)
            {
                dgvInvestment.DataSource = dtInvestments;
                dgvInvestment.Refresh();

            }

            else
            {
                MessageBox.Show("An error occurred while populating the investment data grid view");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new EmployeeView();
            newForm.Show();
        }

        private void Investments_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("UPDATE Investments SET InvestmentID = '" + txtInvID.Text + "' , InvestmentName = '" + txtInvName.Text + "' , Type = '" + txtInvType.Text + "' , InvestmentAmount = '" + txtInvAmount.Text + "' , Interest = '" + txtInvInterest.Text + "' , CustomerID = " + txtInvCustomerID.Text + " WHERE InvestmentID = " + txtInvID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);


            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Investment '" + txtInvID.Text + "' has been succesfully updated");
                txtInvCustomerID.Text = "";
                FillInvestmentDGV();
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while updating " + txtInvCustomerID.Text);
            }





        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("DELETE FROM Investments WHERE InvestmentID = " + txtInvID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);

            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Investment '" + txtInvID.Text + "' has been succesfully deleted");
                txtInvID.Text = "";
                FillInvestmentDGV();
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while deleting " + txtInvID.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            //SqlCommand cmd = new SqlCommand("INSERT INTO Investments Values (InvestmentID = " + txtInvID + ", InvestmentName = " + txtInvName.Text + ", Type = " + txtInvType.Text + ", InvestmentAmount = " + txtInvAmount.Text + ", Interest = " + txtInvInterest.Text + ", CustomerID = " + txtInvCustomerID.Text + ") ");
            QuerySuccessful = Walton_DB.ExecSqlString("INSERT INTO Investments (InvestmentID, InvestmentName, Type, InvestmentAmount, Interest, CustomerID) VALUES (" + txtInvID.Text.Trim() + ",'" + txtInvName.Text.Trim() + "','" + txtInvType.Text.Trim() + "','" + txtInvAmount.Text.Trim() + "','" + txtInvInterest.Text.Trim() + "'," + txtInvCustomerID.Text.Trim() + ")");
            //QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);

            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Investment '" + txtInvName.Text + "' has been succesfully added");
                txtInvName.Text = "";
                FillInvestmentDGV();
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while entering the " + txtInvName.Text + " Investment into the database.");
                //MessageBox.Show("INSERT INTO Investments (InvestmentID, InvestmentName, Type, InvestmentAmount, Interest, CustomerID) VALUES (" + txtInvID.Text.Trim() + ",'" + txtInvName.Text.Trim() + "','" + txtInvType.Text.Trim() + "','" + txtInvAmount.Text.Trim() + "','" + txtInvInterest.Text.Trim() + "'," + txtInvCustomerID.Text.Trim() + ")");
            }
        }
    }
    }

