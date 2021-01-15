using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Amount = ");

            var amount = double.Parse(Console.ReadLine());

            Console.Write("From ");

            var fromcur = Console.ReadLine();

            Console.Write("To ");

            var tocur = Console.ReadLine();

            if (fromcur == "BGN" && tocur == "USD")
            {
                Console.WriteLine(amount + " BGN = " + Math.Round(amount * 0.56, 4) + " USD");
            }
            if (fromcur == "USD" && tocur == "BGN")
            {
                Console.WriteLine(amount + " USD = " + Math.Round(amount * 1.79549, 4) + " BGN");
            }
            if (fromcur == "BGN" && tocur == "EUR")
            {
                Console.WriteLine(amount + " BGN = " + Math.Round(amount * 0.51, 4) + " EUR");
            }
            if (fromcur == "EUR" && tocur == "BGN")
            {
                Console.WriteLine(amount + " EUR = " + Math.Round(amount * 1.95583, 4) + " BGN");
            }
            if (fromcur == "BGN" && tocur == "GBP")
            {
                Console.WriteLine(amount + " BGN = " + Math.Round(amount * 0.43, 4) + " GBP");
            }
            if (fromcur == "GBP" && tocur == "BGN")
            {
                Console.WriteLine(amount + " GBP = " + Math.Round(amount * 2.53405, 4) + " BGN");
            }
            if (fromcur == "USD" && tocur == "EUR")
            {
                Console.WriteLine(amount + " USD = " + Math.Round(amount * 0.91, 4) + " EUR");
            }
            if (fromcur == "EUR" && tocur == "USD")
            {
                Console.WriteLine(amount + " EUR = " + Math.Round(amount * 1.10, 4) + " USD");
            }
            if (fromcur == "USD" && tocur == "GBP")
            {
                Console.WriteLine(amount + " USD = " + Math.Round(amount * 0.78, 4) + " GBP");
            }
            if (fromcur == "GBP" && tocur == "USD")
            {
                Console.WriteLine(amount + " GBP = " + Math.Round(amount * 1.29, 4) + " USD");
            }
            if (fromcur == "GBP" && tocur == "EUR")
            {
                Console.WriteLine(amount + " GBP = " + Math.Round(amount * 1.18, 4) + " EUR");
            }
            if (fromcur == "EUR" && tocur == "GBP")
            {
                Console.WriteLine(amount + " EUR  = " + Math.Round(amount * 0.85, 4) + " GBP");
            }
        }
    }
}
