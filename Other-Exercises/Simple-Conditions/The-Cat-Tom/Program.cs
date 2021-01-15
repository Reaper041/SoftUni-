using System;

namespace The_Cat_Tom
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeDays = int.Parse(Console.ReadLine());

            int workDays = 365 - freeDays;
            double realTimeforplay = freeDays * 127 + workDays * 63;

            if (realTimeforplay > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", 
                    Math.Truncate((realTimeforplay - 30000) / 60), 
                    (realTimeforplay - 30000) % 60);
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play",
                    Math.Truncate((30000 - realTimeforplay) / 60),
                    (30000 - realTimeforplay) % 60);
                    
            }

        }
    }
}
