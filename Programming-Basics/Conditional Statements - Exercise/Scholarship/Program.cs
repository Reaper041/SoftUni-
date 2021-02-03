

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double result = double.Parse(Console.ReadLine());
            double minIncome = double.Parse(Console.ReadLine());
            double scholarship = Math.Floor(minIncome * 0.35);
            double excellentScholarship = Math.Floor(result * 25);

            if (result > 4.50 && result < 5.50 && income < minIncome)
            {
                Console.WriteLine("You get a Social scholarship {scholarship} BGN.");
            }

            else if (result >= 5.50 && income >= minIncome)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN.");
            }

            else if (result >= 5.50 && income < minIncome)
            {
                if (scholarship > excellentScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {scholarship} BGN.");
                }
                else if (excellentScholarship > scholarship) Console.WriteLine($"You get a scholarship for excellent results {stipendiaZaUspeh} BGN");
                else Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }

            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
