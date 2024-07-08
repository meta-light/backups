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
    public partial class Classes : Form
    {
        DataTable dtClasses = new DataTable();
        private void FillClassesDGV()
        {
            string sqlClasses = "SELECT * From CLASS";
            if (Walton_DB.FillDataTable_ViaSql(ref dtClasses, sqlClasses) == true)
            {
                dgvClasses.DataSource = dtClasses;
                dgvClasses.Refresh();
            }
            else
            {
                MessageBox.Show("An error occurred while populating the classes data grid view");
                return;
            }
        }
        public Classes()
        {
            InitializeComponent();
        }
        private void Report_Load(object sender, EventArgs e)
        {
            FillClassesDGV();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FillClassesDGV();  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("DELETE FROM CLASS WHERE CID = '" + txtCID.Text + "'");
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Class '" + txtCID.Text + "' has been succesfully deleted");
                txtCID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while deleting class " + txtCID.Text);
                MessageBox.Show("DELETE FROM CLASS WHERE CID = " + txtCID.Text);
            }
            FillClassesDGV();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("INSERT INTO CLASS (CID, CLSTIME, TID, ROOM) VALUES ('" + txtCID.Text.Trim() + "', '" + txtClassTime.Text.Trim() + "', '" + txtTID.Text.Trim() + "', '" + txtRoom.Text.Trim() + "')");
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Class '" + txtCID.Text + "' has been succesfully added");
                txtCID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while adding class " + txtCID.Text);
                MessageBox.Show("INSERT INTO CLASS (CID, CLSTIME, TID, ROOM) VALUES ('" + txtCID.Text.Trim() + "', '" + txtClassTime.Text.Trim() + "', '" + txtTID.Text.Trim() + "', '" + txtRoom.Text.Trim() + "')");
            }
            FillClassesDGV();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("UPDATE CLASS SET CID = '" + txtCID.Text + "', CLSTIME = '" + txtClassTime.Text + "', TID = '" + txtTID.Text + "', ROOM = '" + txtRoom.Text + "' WHERE CID = '" + txtCID.Text + "'");
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                // Name successfully entered, notify user and clear textbox
                MessageBox.Show("Class '" + txtCID.Text + "' has been succesfully updated");
                txtCID.Text = "";
            }
            else
            {
                // Error occurred, notify user, do not clear textbox
                MessageBox.Show("An error occurred while updating class " + txtCID.Text);
                MessageBox.Show("UPDATE CLASS SET CID = '" + txtCID.Text + "', CLSTIME = '" + txtClassTime.Text + "', TID = '" + txtTID.Text + "', ROOM = '" + txtRoom.Text + "' WHERE CID = '" + txtCID.Text + "'");
            }
            FillClassesDGV();
        }
    }
}
