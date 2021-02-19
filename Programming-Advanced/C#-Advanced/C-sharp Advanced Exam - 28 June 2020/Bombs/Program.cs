using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectsArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] bombCasingsArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> bombEffects = new Queue<int>(bombEffectsArr);
            Stack<int> bombCasings = new Stack<int>(bombCasingsArr);

            Dictionary<string, int> bombs = new Dictionary<string, int>
            {
                {"Cherry Bombs", 0},
                {"Datura Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };

            bool isFilled = false;

            while (bombEffects.Count != 0 && bombCasings.Count != 0)
            {
                int bombEffValue = bombEffects.Peek();
                int bombCasingValue = bombCasings.Pop();
                int sum = bombEffValue + bombCasingValue;

                if (sum == 40)
                {
                    bombs["Datura Bombs"]++;
                }
                else if (sum == 60)
                {
                    bombs["Cherry Bombs"]++;
                }
                else if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                }
                else
                {
                    bombCasings.Push(bombCasingValue - 5);
                    continue;
                }

                bombEffects.Dequeue();

                if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
                {
                    isFilled = true;
                    break;
                }
            }


            if (isFilled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
