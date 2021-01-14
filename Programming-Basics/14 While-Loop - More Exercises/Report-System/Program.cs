using System;

namespace Report_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededMoney = int.Parse(Console.ReadLine());
            int sum = 0;
            int sumCS = 0;
            int sumCC = 0;
            int count = 0;
            int countCS = 0;
            int countCC = 0;

            while (sum < neededMoney)
            {
                string price = Console.ReadLine();
                count++;
                if (price == "End")
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    break;
                }
                if (count % 2 == 1)
                {
                    if (int.Parse(price) > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        sumCS += int.Parse(price);
                        sum += int.Parse(price);
                        countCS++;
                    }
                }
                else
                {
                    if (int.Parse(price) < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        sumCC += int.Parse(price);
                        sum += int.Parse(price);
                        countCC++;
                    }
                }
            }
            if (neededMoney <= sum)
            {
                Console.WriteLine($"Average CS: {sumCS * 1.0 / countCS:f2}");
                Console.WriteLine($"Average CC: {sumCC * 1.0 / countCC:f2}");
            }
        }
    }
}
