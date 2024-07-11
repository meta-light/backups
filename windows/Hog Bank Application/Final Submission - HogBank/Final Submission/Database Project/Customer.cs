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
    public partial class Customer : Form
    {
        DataTable dtCustomers = new DataTable();
        public Customer()
        {
            InitializeComponent();
            FillCustomerDGV();
        }

        private void FillCustomerDGV()
        {
            string sqlCustomers = "SELECT * From Customer ORDER BY CustomerName";

            if (Walton_DB.FillDataTable_ViaSql(ref dtCustomers, sqlCustomers) == true)
            {
                dgvCustomer.DataSource = dtCustomers;
                dgvCustomer.Refresh();

            }

            else
            {
                MessageBox.Show("An error occurred while populating the customer data grid view");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new EmployeeView();
            newForm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            //SqlCommand cmd = new SqlCommand("INSERT INTO Customer (CustomerID, CustomerName, PhoneNumber, EmailAddress, Status, JoinDate, OtherAuthorizedUsers) Values (" + txtID.Text.Trim() + ",'" + txtName.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtStatus.Text.Trim() + "','" + txtJoinDate.Text.Trim() + "'," + txtAuth.Text.Trim() + ")");
            //QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            QuerySuccessful = Walton_DB.ExecSqlString("INSERT INTO Customer (CustomerID, CustomerName, PhoneNumber, EmailAddress, Status, JoinDate, OtherAuthorizedUsers) Values (" + txtID.Text.Trim() + ",'" + txtName.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtStatus.Text.Trim() + "','" + txtJoinDate.Text.Trim() + "'," + txtAuth.Text.Trim() + ")");

            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Customer '" + txtName.Text + "' has been succesfully added");
                txtName.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                //MessageBox.Show("INSERT INTO Customer (CustomerID, CustomerName, PhoneNumber, EmailAddress, Status, JoinDate, OtherAuthorizedUsers) Values (" + txtID.Text.Trim() + ",'" + txtName.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtStatus.Text.Trim() + "','" + txtJoinDate.Text.Trim() + "'," + AuthLabel.Text.Trim() + ")");
                MessageBox.Show("An error occurred while entering the customer " + txtName.Text + " into the database.");
            }

            FillCustomerDGV();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("UPDATE Customer SET CustomerName = '" + txtName.Text + "', PhoneNumber = '" + txtPhone.Text + "', EmailAddress = '" + txtEmail.Text + "', Status = '" + txtStatus.Text + "', JoinDate = '" + txtJoinDate.Text + "', OtherAuthorizedUsers = '" + txtAuth.Text + "' WHERE CustomerID = " + txtID.Text);
            QuerySuccessful=Walton_DB.ExecSqlCommand(ref cmd);


            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Customer '" + txtName.Text + "' has been succesfully updated");
                txtName.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while updating " + txtName.Text);
            }

            FillCustomerDGV();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE CustomerID = " + txtID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);

            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Customer '" + txtID.Text + "' has been succesfully deleted");
                txtID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while deleting " + txtID.Text);
            }

            FillCustomerDGV();
        }
    }
}
