using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_And_Vegies
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricevegies = double.Parse(Console.ReadLine());
            double pricefruit = double.Parse(Console.ReadLine());
            double kgvegies = double.Parse(Console.ReadLine());
            double kgfruit = double.Parse(Console.ReadLine());

            double totallv = (pricevegies * kgvegies) + (pricefruit * kgfruit);
            double totaleuro = totallv / 1.94;

            Console.WriteLine(totaleuro);

        }
    }
}
