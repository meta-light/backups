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
    public partial class EmployeeReport : Form
    {
        DataTable dtInstructors = new DataTable();
        private void FillInstructorDGV()
        {
            string sqlInstructors = "SELECT * From INSTRUCTOR";

            if (Walton_DB.FillDataTable_ViaSql(ref dtInstructors, sqlInstructors) == true)
            {
                dgvInstructors.DataSource = dtInstructors;
                dgvInstructors.Refresh();
            }
            else
            {
                MessageBox.Show("An error occurred while populating the instructor data grid view");
                return;
            }
        }
        public static string inputedInstructor;
        public EmployeeReport()
        {
            InitializeComponent();
        }
        private void EmployeeReport_Load(object sender, EventArgs e)
        {
            FillInstructorDGV();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FillInstructorDGV();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("INSERT INTO INSTRUCTOR (TID, NAME) VALUES (" + txtTID.Text.Trim() + ",'" + txtName.Text.Trim() + "')");
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Instructor '" + txtTID.Text + "' has been succesfully added");
                txtTID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while adding instructor " + txtTID.Text);
            }
            FillInstructorDGV();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("UPDATE INSTRUCTOR SET TID = '" + txtTID.Text + "', NAME = '" + txtName.Text + "' WHERE TID = " + txtTID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Instructor '" + txtTID.Text + "' has been succesfully updated");
                txtTID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while updating instructor" + txtTID.Text);
            }
            FillInstructorDGV();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("DELETE FROM INSTRUCTOR WHERE TID = " + txtTID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Instructor '" + txtTID.Text + "' has been succesfully deleted");
                txtTID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while deleting instructor" + txtTID.Text);
            }
            FillInstructorDGV();
        }
    }
    }

