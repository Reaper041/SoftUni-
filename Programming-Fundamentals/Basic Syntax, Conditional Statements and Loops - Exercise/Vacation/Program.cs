using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double total = 0;
            double price = 0;
            switch (day)
            {
                case "Friday":
                    if (typeOfGroup == "Students")
                    {
                        price = 8.45;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        price = 10.90;
                    }
                    else
                    {
                        price = 15;
                    }
                    break;
                case "Saturday":
                    if (typeOfGroup == "Students")
                    {
                        price = 9.80;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        price = 15.60;
                    }
                    else
                    {
                        price = 20;
                    }
                    break;
                case "Sunday":
                    if (typeOfGroup == "Students")
                    {
                        price = 10.46;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        price = 16;
                    }
                    else
                    {
                        price = 22.50;
                    }
                    break;
            }
            total = price * number;
            if (typeOfGroup == "Students" && number >= 30)
            {
                total -= total * 0.15;
            }
            else if (typeOfGroup == "Business" && number >= 100)
            {
                total -= price * 10;
            }
            else if (typeOfGroup == "Regular" && number >= 10 && number <= 20)
            {
                total -= total * 0.05;
            }
            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
