using Database_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            bool QuerySuccessful = false;
            SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE UN = '" + txtUN.Text + "', PW = '" + txtPW.Text + "' ");
            QuerySuccessful = Walton_DB.ExecSqlCommand(ref cmd);
            if (QuerySuccessful)
            {
                MessageBox.Show("Succesful Login");
                this.Hide();
                var newForm = new HomePage();
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Adding User");
                bool LoginSuccessful = false;
                SqlCommand uncmd = new SqlCommand("INSERT INTO USERS (UN, PW) VALUES ('" + txtUN.Text + "', PW = '" + txtPW.Text + "')");
                LoginSuccessful = Walton_DB.ExecSqlCommand(ref uncmd);
                this.Hide();
                var newForm = new HomePage();
                newForm.Show();
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}