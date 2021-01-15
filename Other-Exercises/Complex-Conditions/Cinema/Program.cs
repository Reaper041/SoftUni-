using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            if (projectionType == "premiere")
            {
                double earning = 12.00 * rows * column;
                Console.WriteLine("{0:f2}", earning);
            }
            else if (projectionType == "normal")
            {
                double earning = 7.50 * rows * column;
                Console.WriteLine("{0:f2}", earning);
            }
            else if (projectionType == "discount")
            {
                double earning = 5.00 * rows * column;
                Console.WriteLine("{0:f2}", earning);
            }
        }
    }
}
   

