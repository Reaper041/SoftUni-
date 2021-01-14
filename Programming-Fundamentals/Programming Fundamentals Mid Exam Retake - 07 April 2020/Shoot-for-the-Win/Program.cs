using System;
using System.Linq;

namespace Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            int shotsCount = 0;
            while (input != "End")
            {
                int index = int.Parse(input);
                bool isIndexValid = index >= 0 && index < targets.Length && targets[index] != -1;

                if (isIndexValid)
                {
                    int shotValue = targets[index];
                    targets[index] = -1;
                    shotsCount++;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] != -1 && targets[i] > shotValue)
                        {
                            targets[i] -= shotValue;
                        }
                        else if (targets[i] != -1 && targets[i] <= shotValue)
                        {
                            targets[i] += shotValue;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotsCount} -> {string.Join(' ', targets)}");
        }
    }
}
