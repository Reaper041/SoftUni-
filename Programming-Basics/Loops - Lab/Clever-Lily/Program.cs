using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            double total = 0;
            double moneyEarned = 10;

            for (int birthday = 1; birthday <= age; birthday++)
            {
                if (birthday % 2 == 0)
                {
                    total += moneyEarned;
                    moneyEarned += 10;
                    total--;
                }
                if (birthday % 2 != 0)
                {
                    total += toysPrice;
                }

            }


            double diff = total - washingMachinePrice;

            if (diff >= 0)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(diff):f2}");
            }
        }
    }
}
