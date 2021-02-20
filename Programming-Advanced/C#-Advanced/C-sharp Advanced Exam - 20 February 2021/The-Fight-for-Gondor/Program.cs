using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberofWaves = int.Parse(Console.ReadLine());

            int[] platesArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> plates = new Queue<int>(platesArr);

            bool platesLost = false;
            List<int> orcs = new List<int>();

            for (int i = 1; i <= numberofWaves; i++)
            {
                int[] warriorsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                Stack<int> warriors = new Stack<int>(warriorsArr);

                if (i % 3 == 0)
                {
                    int n = int.Parse(Console.ReadLine());
                    plates.Enqueue(n);
                }


                while (true)
                {

                    if (warriors.Count <= 0 || plates.Count <= 0)
                    {
                        break;
                    }
                    else
                    {
                        int currentWarrior = warriors.Peek();
                        int currPlate = plates.Peek();

                        if (currPlate == currentWarrior)
                        {
                            warriors.Pop();
                            plates.Dequeue();

                        }
                        else if (currPlate > currentWarrior)
                        {
                            warriors.Pop();
                            currPlate -= currentWarrior;
                            plates.Dequeue();
                            List<int> swap = new List<int>(plates);

                            swap.Insert(0, currPlate);

                            plates = new Queue<int>(swap);

                        }
                        else if (currentWarrior > currPlate)
                        {
                            plates.Dequeue();
                            currentWarrior -= currPlate;
                            warriors.Pop();
                            warriors.Push(currentWarrior);

                        }
                    }
                }
                if (plates.Count <= 0)
                {
                    platesLost = true;
                    orcs.AddRange(warriors);

                }

                if (platesLost)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");

                    return;
                }
            }

            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
        }
    }
}