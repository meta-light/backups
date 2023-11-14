using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Two
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void radioButton_FruitSalad_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_FruitSalad.Checked == true)
            {
                textBox_SaladPrice.Text = "$9.95";
                label_salad.Text = "Fruit Salad Selected";
            }
        }

        private void radioButton_PastaSalad_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_PastaSalad.Checked == true)
            {
                textBox_SaladPrice.Text = "$12.00";
                label_salad.Text = "Pasta Salad Selected";
            }

        }

        private void radioButton_Smoothie_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Smoothie.Checked == true)
            {
                textBox_DrinksPrice.Text = "$4.95";
                label_drinks.Text = "Smoothie Selected";
            }
        }

        private void radioButton_FruitJuice_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_FruitJuice.Checked == true)
            {
                textBox_DrinksPrice.Text = "$3.95";
                label_drinks.Text = "Fruit Juice Selected";
            }
        }

        private void radioButton_Cupcake_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Cupcake.Checked == true)
            {
                textBox_DessertsPrice.Text = "$3.00";
                label_desserts.Text = "Cupcake Selected";
            }
        }

        private void radioButton_ShortCake_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_ShortCake.Checked == true)
            {
                textBox_DessertsPrice.Text = "$6.00";
                label_desserts.Text = "Shortcake Selected";
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearAll()
        {
            label_salad.Text = "";

            radioButton_FruitSalad.Checked = false;
            radioButton_PastaSalad.Checked = false;
            radioButton_Smoothie.Checked = false;
            radioButton_FruitJuice.Checked = false;
            radioButton_Cupcake.Checked = false;
            radioButton_ShortCake.Checked = false;

            textBox_SaladPrice.Text = "";
            textBox_SaladQty.Text = "";
            textBox_DrinksPrice.Text = "";
            textBox_DrinksQty.Text = "";
            textBox_DessertsPrice.Text = "";
            textBox_DessertsQty.Text = "";

            label_salad.Text = "";
            label_drinks.Text = "";
            label_desserts.Text = "";

          
            
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button_Calc_Click(object sender, EventArgs e)
        {
            double SaladPrice = 0;
            double DrinkPrice = 0;
            double DessertsPrice = 0;
            int SaladQty = 0;
            int DrinkQty = 0;
            int DessertsQty = 0;
            // Salad Price
            if (radioButton_FruitSalad.Checked == false && radioButton_PastaSalad.Checked == false)
            {
                MessageBox.Show("You must select a salad!");
                return;
            }
            else
            {
                if (radioButton_FruitSalad.Checked == true) SaladPrice = 9.95;
                if (radioButton_PastaSalad.Checked == true) SaladPrice = 12.00;
            }
            //Salad Quant
            if (int.TryParse(textBox_SaladQty.Text, out SaladQty) == false)
            {
                MessageBox.Show("You must enter a valid number for salad qty!");
                return;
            }

            // Drink Price
            if (radioButton_Smoothie.Checked == false && radioButton_FruitJuice.Checked == false)
            {
                MessageBox.Show("You must select a drink!");
                return;
            }
            else
            {
                if (radioButton_Smoothie.Checked == true) DrinkPrice = 4.95;
                if (radioButton_FruitJuice.Checked == true) DrinkPrice = 3.95;
            }
            //Drink Quant
            if (int.TryParse(textBox_DrinksQty.Text, out DrinkQty) == false)
            {
                MessageBox.Show("You must enter a valid number for drink qty!");
                return;
            }
            // Dessert Price
            if (radioButton_Cupcake.Checked == false && radioButton_ShortCake.Checked == false)
            {
                MessageBox.Show("You must select a dessert!");
                return;
            }
            else
            {
                if (radioButton_Cupcake.Checked == true) DessertsPrice = 3.00;
                if (radioButton_ShortCake.Checked == true) DessertsPrice = 6.00;
            }
            //Dessert Quant
            if (int.TryParse(textBox_DessertsQty.Text, out DessertsQty) == false)
            {
                MessageBox.Show("You must enter a valid number for dessert qty!");
                return;
            }
            double Total = (SaladPrice * SaladQty) + (DrinkPrice * DrinkQty) + (DessertsPrice * DessertsQty);
            label_message.Text = "Total: " + Total.ToString("C");
        }
    }
}
