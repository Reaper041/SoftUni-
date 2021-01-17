using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();

            int maxTosses = int.Parse(Console.ReadLine());

            Queue<string> kidsQueue = new Queue<string>(kids);

            int tosses = 0;
            string lastKid = string.Empty;

            while (kidsQueue.Count > 1)
            {
                tosses++;
                lastKid = kidsQueue.Dequeue();
                if (tosses < maxTosses)
                {
                    kidsQueue.Enqueue(lastKid);
                }
                else
                {
                    Console.WriteLine($"Removed {lastKid}");
                    tosses = 0;
                }
            }

            Console.WriteLine($"Last is {kidsQueue.Dequeue()}");
        }
    }
}
