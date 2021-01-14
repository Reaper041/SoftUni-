using System;

namespace Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();


            double sum = 0;
            while (input != "special" && input != "regular")
            {
                double price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    sum += price;
                }
                input = Console.ReadLine();
            }

            double taxes = 0;
            double sumWithoutTaxes = 0;
            if (sum <= 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            else
            {
                sumWithoutTaxes = sum;
                taxes = sum * 0.2;
                sum += taxes;
            }

            if (input == "special")
            {
                sum -= sum * 0.1;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sumWithoutTaxes:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {sum:f2}$");
        }
    }
}
