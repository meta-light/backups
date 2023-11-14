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
    public partial class Enroll : Form
    {
        DataTable dtEnroll = new DataTable();
        public Enroll()
        {
            InitializeComponent();
            FillEnrollDGV();
        }
        private void FillEnrollDGV()
        {
            string sqlEnroll = "SELECT * From ENROLL";
            if (Walton_DB.FillDataTable_ViaSql(ref dtEnroll, sqlEnroll) == true)
            {
                dgvEnroll.DataSource = dtEnroll;
                dgvEnroll.Refresh();
            }
            else
            {
                MessageBox.Show("An error occurred while populating the enrollment data grid view");
                return;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("INSERT INTO ENROLL (SID, CID) VALUES ('" + txtSID.Text.Trim() + "','" + txtCID.Text.Trim() + "')");
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Enrollment for student '" + txtSID.Text + "' has been succesfully added");
                txtSID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while entering the Enrollment for Student " + txtSID.Text + " into the database.");
            }
            FillEnrollDGV();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("UPDATE ENROLL SET SID = '" + txtSID.Text + "', CID = '" + txtCID.Text + "' WHERE SID = '" + txtSID.Text + "'");
            QuerySuccessful=Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Enrollment for student '" + txtSID.Text + "' has been succesfully updated");
                txtSID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while updating " + txtSID.Text);
            }
            FillEnrollDGV();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("DELETE FROM ENROLL WHERE SID = " + txtSID.Text);
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Enrollment for student '" + txtSID.Text + "' has been succesfully deleted");
                txtSID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while deleting " + txtSID.Text);
            }
            FillEnrollDGV();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void Enroll_Load(object sender, EventArgs e)
        {

        }
    }
}
