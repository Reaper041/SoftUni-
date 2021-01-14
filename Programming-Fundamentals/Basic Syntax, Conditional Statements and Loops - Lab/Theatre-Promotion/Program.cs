using System;

namespace Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            decimal price = 0;
            bool flag = true;
            if (age >= 0 && age <= 18)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price = 12;
                        break;
                    case "Weekend":
                        price = 15;
                        break;
                    case "Holiday":
                        price = 5;
                        break;
                    default:
                        break;
                }
            }
            else if (age >= 18 && age <= 64)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price = 18;
                        break;
                    case "Weekend":
                        price = 20;
                        break;
                    case "Holiday":
                        price = 12;
                        break;
                    default:
                        break;
                }
            }
            else if (age >= 64 && age <= 122)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price = 12;
                        break;
                    case "Weekend":
                        price = 15;
                        break;
                    case "Holiday":
                        price = 10;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error!");
                flag = false;
            }
            if (flag)
            {
                Console.WriteLine(price + "$");
            }
        }
    }
}
