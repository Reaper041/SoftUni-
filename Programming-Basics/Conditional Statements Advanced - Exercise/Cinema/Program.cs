using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colls = int.Parse(Console.ReadLine());

            int seats = rows * colls;
            double income = 0;

            switch (projection)
            {
                case "Premiere":
                    income = seats * 12;
                    break;
                case "Normal":
                    income = seats * 7.5;
                    break;
                case "Discount":
                    income = seats * 5;
                    break;
            }
            Console.WriteLine("{0:f2} leva", income);
        }
    }
}
