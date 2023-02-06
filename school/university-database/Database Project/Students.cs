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
    public partial class Students : Form
    {
        DataTable dtStudents = new DataTable();
        public Students()
        {
            InitializeComponent();
            FillStudentDGV();
        }
        private void FillStudentDGV()
        {
            string sqlStudents = "SELECT * From STUDENT";

            if (Walton_DB.FillDataTable_ViaSql(ref dtStudents, sqlStudents) == true)
            {
                dgvStudent.DataSource = dtStudents;
                dgvStudent.Refresh();

            }
            else
            {
                MessageBox.Show("An error occurred while populating the STUDENT data grid view");
                return;
            }
        }
        private void Students_Load(object sender, EventArgs e)
        {
            FillStudentDGV();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("UPDATE STUDENT SET SID = '" + txtSID.Text + "' , NAME = '" + txtName.Text + "' , MAJOR = '" + txtMajor.Text + "' , GRADELVL = '" + txtGrade.Text + "' , AGE = '" + txtAge.Text + "' WHERE SID = '" + txtSID.Text + "'");
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);

            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Student '" + txtSID.Text + "' has been succesfully updated");
                txtSID.Text = "";
                FillStudentDGV();
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while updating student " + txtSID.Text);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("DELETE FROM STUDENT WHERE SID = " + txtSID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Student '" + txtSID.Text + "' has been succesfully deleted");
                txtSID.Text = "";
                FillStudentDGV();
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while deleting student " + txtSID.Text);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT (SID, NAME, MAJOR, GRADELVL, AGE) VALUES (" + txtSID.Text + ", '" + txtName.Text + "', '" + txtMajor.Text + "', '" + txtGrade.Text + "', " + txtAge.Text +")");
            //QuerySuccessful = Walton_DB.ExecSqlString("INSERT INTO STUDENT (SID, NAME, MAJOR, GRADELVL, AGE) VALUES (" + txtSID.Text.Trim() + ",'" + txtName.Text.Trim() + "','" + txtMajor.Text.Trim() + "','" + txtGrade.Text.Trim() + "','" + txtAge.Text.Trim() + "'," + ")");
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);

            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Student '" + txtSID.Text + "' has been succesfully added");
                txtName.Text = "";
                FillStudentDGV();
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while entering student " + txtSID.Text + " into the database.");
                MessageBox.Show("INSERT INTO STUDENT (SID, NAME, MAJOR, GRADELVL, AGE) VALUES (" + txtSID.Text + ", '" + txtName.Text + "', '" + txtMajor.Text + "', '" + txtGrade.Text + "', " + txtAge.Text + ")");

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void Students_Load_1(object sender, EventArgs e)
        {

        }
    }
    }
    

