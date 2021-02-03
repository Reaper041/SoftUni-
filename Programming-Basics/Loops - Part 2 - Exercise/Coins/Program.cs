using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double changeInLeva = double.Parse(Console.ReadLine());
            double change = Math.Round(changeInLeva * 100, 2);

            int countCoin = 0;
            while (change > 0)
            {
                if (change >= 200)
                {
                    change -= 200;
                    countCoin++;
                }
                else if (change >= 100)
                {
                    change -= 100;
                    countCoin++;
                }
                else if (change >= 50)
                {
                    change -= 50;
                    countCoin++;
                }
                else if (change >= 20)
                {
                    change -= 20;
                    countCoin++;
                }
                else if (change >= 10)
                {
                    change -= 10;
                    countCoin++;
                }
                else if (change >= 5)
                {
                    change -= 5;
                    countCoin++;
                }
                else if (change >= 2)
                {
                    change -= 2;
                    countCoin++;
                }
                else if (change >= 1)
                {
                    change -= 1;
                    countCoin++;
                }
            }
            Console.WriteLine(countCoin);
        }
    }
}
