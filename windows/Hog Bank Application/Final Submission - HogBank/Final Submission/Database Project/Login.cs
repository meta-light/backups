using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Login : Form
    {
        public static string inputedCustomerID;
        
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            inputedCustomerID = txtCustomerID.Text;
            this.Hide();
            var newForm = new HomePage();
            newForm.Show();
 
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Walton_DB.OpenConnection().ToString());
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            //String value = txtCustomerID.Text;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new EmployeeView();
            newForm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
