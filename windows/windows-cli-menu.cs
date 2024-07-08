using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double FruitSaladPrice = 9.95;
            double PastaSaladPrice = 12.00;
            double SmoothiePrice = 4.95;
            double FruitJuicePrice = 3.95;
            double CupCakePrice = 3.00;
            double ShortCakePrice = 6.00;

            int FruitSaladQty = 0;
            int PastaSaladQty = 0;
            int SmoothieQty = 0;
            int FruitJuiceQty = 0;
            int CupCakeQty = 0;
            int ShortCakeQty = 0;

            Console.WriteLine("*****************Menu*****************");
            Console.WriteLine("Fruit Salad: $9.95");
            Console.WriteLine("Pasta Salad: $12.00");
            Console.WriteLine("Smoothie: $4.95");
            Console.WriteLine("Fruit Juice: $3.95");
            Console.WriteLine("Cup Cake: $3.00");
            Console.WriteLine("Short Cake: $6.00");
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter Your Order");
            Console.WriteLine("How Many Fruit Salad?");
            FruitSaladQty = int.Parse(Console.ReadLine());
            Console.WriteLine("How Many Pasta Salad?");
            PastaSaladQty =  int.Parse(Console.ReadLine());
            Console.WriteLine("How many Smoothie?");
            SmoothieQty = int.Parse(Console.ReadLine());
            Console.WriteLine("How Many Fruit Juice?");
            FruitJuiceQty = int.Parse(Console.ReadLine());
            Console.WriteLine("How Many Cup Cake?");
            CupCakeQty = int.Parse(Console.ReadLine());
            Console.WriteLine("How Many Short Cake?");
            ShortCakeQty = int.Parse(Console.ReadLine());

            //double FruitSaladTotal = FruitSaladPrice * FruitSaladQty;
            //double PastaSaladTotal = PastaSaladPrice * PastaSaladQty;
            //double SmoothieTotal = SmoothiePrice * SmoothieQty;
            //double FruitJuiceTotal = FruitJuicePrice * FruitJuiceQty;
            //double CupCakeTotal = CupCakePrice * CupCakeQty;
            //double ShortCakeTotal = ShortCakePrice * ShortCakeQty;
            //double SubTotal = FruitSaladTotal + PastaSaladTotal + SmoothieTotal + FruitJuiceTotal + CupCakeTotal + ShortCakeTotal;
            
            double SubTotal = (FruitSaladPrice * FruitSaladQty) + (PastaSaladPrice * PastaSaladQty) + (SmoothiePrice * SmoothieQty) + (FruitJuicePrice * FruitJuiceQty) + (CupCakePrice * CupCakeQty) + (ShortCakePrice * ShortCakeQty);
            double Tax = SubTotal * 0.095;
            double Total = Tax + SubTotal;
            Console.WriteLine("SubTotal: " + SubTotal.ToString("C"));
            Console.WriteLine("Tax: " + Tax.ToString("C"));
            Console.WriteLine("Total: " + Total.ToString("C"));

            Console.ReadKey();
        }
    }
}
