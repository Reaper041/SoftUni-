using System;
using System.Linq;

namespace The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleInQueue = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < lift.Length; i++)
            {
                if (peopleInQueue < 4 - lift[i])
                {
                    lift[i] += peopleInQueue;
                    peopleInQueue = 0;
                    Console.WriteLine("The lift has empty spots!");
                    Console.WriteLine(string.Join(' ', lift));
                    break;
                }

                peopleInQueue -= 4 - lift[i];
                lift[i] += 4 - lift[i];
            }

            if (peopleInQueue > 0 && lift.All(x=>x == 4))
            {
                Console.WriteLine($"There isn't enough space! {peopleInQueue} people in a queue!");
                Console.WriteLine(string.Join(' ', lift));
            }
            else if (peopleInQueue == 0 && lift.All(x => x == 4))
            {
                Console.WriteLine(string.Join(' ', lift));
            }
        }
    }
}
