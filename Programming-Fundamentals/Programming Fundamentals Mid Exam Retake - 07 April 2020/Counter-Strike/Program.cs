using System;

namespace Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int countOfWins = 0;
            bool isWin = true;
            while (input != "End of battle")
            {
                int distance = int.Parse(input);
                if (distance <= initialEnergy)
                {
                    initialEnergy -= distance;
                    countOfWins++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {countOfWins} won battles and {initialEnergy} energy");
                    isWin = false;
                    break;
                }

                if (countOfWins % 3 == 0)
                {
                    initialEnergy += countOfWins;
                }
                input = Console.ReadLine();
            }

            if (isWin)
            {
                Console.WriteLine($"Won battles: {countOfWins}. Energy left: {initialEnergy}");
            }
        }
    }
}
