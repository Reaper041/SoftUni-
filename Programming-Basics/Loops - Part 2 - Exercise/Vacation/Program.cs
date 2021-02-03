using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());
            int countSpendDays = 0;
            int countDays = 0;
            string lastAction = string.Empty;
            while (ownedMoney < neededMoney)
            {
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                countDays++;
                if (action == "save")
                {
                    ownedMoney += money;
                    countSpendDays = 0;
                }
                else if (action == "spend")
                {
                    ownedMoney -= money;
                    countSpendDays++;
                    if (countSpendDays == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{countDays}");
                        break;
                    }
                }
                if (ownedMoney < 0)
                {
                    ownedMoney = 0;
                }
            }

            if (ownedMoney >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {countDays} days.");
            }
        }
    }
}
