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
    public partial class Employees : Form
    {
        DataTable dtEmployees = new DataTable();
        public Employees()
        {
            InitializeComponent();
            FillEmployeeDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new EmployeeView();
            newForm.Show();
        }

        private void FillEmployeeDGV()
        {
            string sqlEmployees = "SELECT * From Employee ORDER BY EmployeeName";

            if (Walton_DB.FillDataTable_ViaSql(ref dtEmployees, sqlEmployees) == true)
            {
                dgvEmployee.DataSource = dtEmployees;
                dgvEmployee.Refresh();

            }

            else
            {
                MessageBox.Show("An error occurred while populating the employee data grid view");
                return;
            }
        }

            private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            //SqlCommand cmd = new SqlCommand("INSERT INTO Employee Values (EmployeeID = " + txtID + ", EmployeeName = " + txtName.Text + ", Address = " + txtAddress.Text + ", Email = " + txtEmail.Text + ", PhoneNumber = " + txtPhone.Text + ", Status = " + txtStatus.Text + ", HourlyRate = " + txtHourlyRate.Text + ", HireDate = " + txtHireDate.Text + ", BuildingNumber = " + txtBuildingNum.Text + ", WHERE EmployeeID = " + txtID.Text + ") ");
            //QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            QuerySuccessful = Walton_DB.ExecSqlString("INSERT INTO Employee (EmployeeID, EmployeeName, Address, Email, PhoneNumber, Status, Type, HourlyRate, HireDate, BuildingNumber) Values (" + txtID.Text.Trim() + ",'" + txtName.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + txtStatus.Text.Trim() + "','" +  txtType.Text + "','" + txtHourlyRate.Text.Trim() + "','" + txtHireDate.Text + "'," + txtBuildingNum.Text + ")");

            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Employee '" + txtName.Text + "' has been succesfully added");
                txtName.Text = "";
                FillEmployeeDGV();
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while entering the employee " + txtName.Text + " into the database.");
            }

            
        }


        

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtHourlyRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("UPDATE Employee SET EmployeeName = '" + txtName.Text + "' , Address = '" + txtAddress.Text + "', Email = '" + txtEmail.Text + "', PhoneNumber = '" + txtPhone.Text + "', Status = '" + txtStatus.Text + "', Type = '" + txtType.Text + "', HourlyRate = '" + txtHourlyRate.Text + "', HireDate = '" + txtHireDate.Text + "', BuildingNumber = " + txtBuildingNum.Text + " WHERE EmployeeID = " + txtID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);


            if (QuerySuccessful)
            {
               // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Employee '" + txtName.Text + "' has been succesfully updated");
                txtName.Text = "";
                FillEmployeeDGV();
            }
            else
            {
               // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while updating " + txtName.Text);
               // MessageBox.Show("UPDATE Employee SET EmployeeName = '" + txtName.Text + "' , Address = '" + txtAddress.Text + "', Email = '" + txtEmail.Text + "', PhoneNumber = '" + txtPhone.Text + "', Status = '" + txtStatus.Text + "', Type = '" + txtType.Text + "', HourlyRate = '" + txtHourlyRate.Text + "', HireDate = '" + txtHireDate.Text + "', BuildingNumber = " + txtBuildingNum.Text + ", WHERE EmployeeID = " + txtID.Text);
            }

            
            
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE EmployeeID = " + txtID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);

            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Employee '" + txtID.Text + "' has been succesfully deleted");
                txtID.Text = "";
                FillEmployeeDGV();
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while deleting " + txtID.Text);
            }

            
        }
    }
}
