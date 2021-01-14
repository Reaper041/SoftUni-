using System;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //        coffee  water   beer    sweets  peanuts
            //Sofia   0.50    0.80    1.20    1.45    1.60
            //Plovdiv 0.40    0.70    1.15    1.30    1.50
            //Varna   0.45    0.70    1.10    1.35    1.55

            string product = Console.ReadLine().ToLower();
            string city = Console.ReadLine().ToLower();
            double entity = double.Parse(Console.ReadLine());

            if (city == "sofia")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.50 * entity);
                        break;
                    case "water":
                        Console.WriteLine(0.80 * entity);
                        break;
                    case "beer":
                        Console.WriteLine(1.20 * entity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.45 * entity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.60 * entity);
                        break;
                }
            }
            else if (city == "plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.40 * entity);
                        break;
                    case "water":
                        Console.WriteLine(0.70 * entity);
                        break;
                    case "beer":
                        Console.WriteLine(1.15 * entity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.30 * entity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.50 * entity);
                        break;
                }
            }
            else
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.45 * entity);
                        break;
                    case "water":
                        Console.WriteLine(0.70 * entity);
                        break;
                    case "beer":
                        Console.WriteLine(1.10 * entity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.35 * entity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.55 * entity);
                        break;
                }
            }
        }
    }
}
