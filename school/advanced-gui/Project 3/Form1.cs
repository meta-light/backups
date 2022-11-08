using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_3
{
    public partial class Form1 : Form
    {
        string[] SauceNames = new string[] { "Drawn Butter", "Aioli", "Garlic Sauce", "Hollandaise", "Renoulande" };
        double[] SaucePrices = new double[] { 1, 2.5, 1.5, 3, 2.5};
        string[] SideNames = new string[] { "Brussles Sprouts", "Butternut Squash", "Macironi Salad", "Roasted Broccoli"};
        double[] SidePrices = new double[] { 3.0, 4.0, 2.5, 2.0};

        private double Calc()
        {
            int NumberOfGuest = 0;
            double MenuChoicePrice = 0;
            double SelectedSaucePrice = 0;
            double SelectedSidePrice = 0;
            double BarPrice = 0;

            if(int.TryParse(txtGuests.Text, out NumberOfGuest) == false)
            {
                MessageBox.Show("You must enter a number for guests!");
                return 0;
            }

            if (!rdoSteak.Checked && !rdoChicken.Checked && !rdoPasta.Checked)
            {
                MessageBox.Show("You must select a menu choice!");
                return 0;
            } 

            else if (rdoSteak.Checked)
            {
                MenuChoicePrice = 31.95;
            }

            else if (rdoChicken.Checked)
            {
                MenuChoicePrice = 19.95;
            }

            else if (rdoPasta.Checked)
            {
                MenuChoicePrice = 14.95;
            }

            if (cboSauce.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a sauce!");
                return 0;
            }

            else
            {
                int SauceIndex = cboSauce.SelectedIndex;
                SelectedSaucePrice = SaucePrices[SauceIndex];
            }

            if (cboSides.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a side!");
                return 0;
            }

            else
            {
                int SideIndex = cboSides.SelectedIndex;
                SelectedSidePrice = SidePrices[SideIndex];
            }



            if (chkOpenBar.Checked) BarPrice = 25;
            if (chkWine.Checked) BarPrice = BarPrice + 8;
            return NumberOfGuest * (MenuChoicePrice + SelectedSidePrice + SelectedSaucePrice + BarPrice);

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblTodaysDate.Text = DateTime.Now.ToString("D");

            for(int i = 0; i < SauceNames.Length; i++)
            {
                cboSauce.Items.Add(SauceNames[i]);
            }

            for(int i = 0; i < SideNames.Length; i++)
            {
                cboSides.Items.Add(SideNames[i]);
            }
        }
        private void ClearAll()
        {
            cboSauce.SelectedIndex = -1;
            cboSides.SelectedIndex = -1;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            lblAmountDue.Text = Calc().ToString("C");
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            double total = Calc();
            if (total == 0) return;

            string MessageText =
                "Total Guests:" + txtGuests.Text + System.Environment.NewLine +
                "Total Amount Due" + total.ToString("C") + System.Environment.NewLine + System.Environment.NewLine +
                "Do you want to clear?";
            if (MessageBox.Show(MessageText, "Carpinito Catering", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearAll();
            }
        }
    }
}
