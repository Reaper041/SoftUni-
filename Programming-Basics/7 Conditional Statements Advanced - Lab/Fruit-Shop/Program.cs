using System;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string day = Console.ReadLine().ToLower();
            double entity = double.Parse(Console.ReadLine());

            if (day == "sunday" || day == "saturday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine($"{2.70 * entity:f2}");
                        break;
                    case "apple":
                        Console.WriteLine($"{1.25 * entity:f2}");
                        break;
                    case "orange":
                        Console.WriteLine($"{0.90 * entity:f2}");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{1.60 * entity:f2}");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{3.00 * entity:f2}");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{5.60 * entity:f2}");
                        break;
                    case "grapes":
                        Console.WriteLine($"{4.20 * entity:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (day == "monday" || day == "tuesday" || day == "wednesday" || day == "thursday" || day == "friday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine($"{2.50 * entity:f2}");
                        break;
                    case "apple":
                        Console.WriteLine($"{1.20 * entity:f2}");
                        break;
                    case "orange":
                        Console.WriteLine($"{0.85 * entity:f2}");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{1.45 * entity:f2}");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{2.70 * entity:f2}");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{5.50 * entity:f2}");
                        break;
                    case "grapes":
                        Console.WriteLine($"{3.85 * entity:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
