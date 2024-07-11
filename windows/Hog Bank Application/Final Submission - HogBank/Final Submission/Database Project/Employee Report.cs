using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class EmployeeReport : Form
    {
        DataTable dtCustomers = new DataTable();

        private void FillCustomerDGV()
        {
            string sqlCustomers = ("SELECT * From Employee WHERE EmployeeID = " + txtEmployeeID.Text);

            if (Walton_DB.FillDataTable_ViaSql(ref dtCustomers, sqlCustomers) == true)
            {
                dgvEmployee.DataSource = dtCustomers;
                dgvEmployee.Refresh();

            }

            else
            {
                MessageBox.Show("An error occurred while populating the customer data grid view");
                return;
            }
        }

        public static string inputedEmployeeID;
        public EmployeeReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new EmployeeView();
            newForm.Show();
        }

        private void EmployeeReport_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillCustomerDGV();
        }
    }
}
