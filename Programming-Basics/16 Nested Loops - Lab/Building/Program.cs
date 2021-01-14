using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int stages = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int numStage = stages; numStage >= 1; numStage--)
            {
                for (int numApp = 0; numApp < rooms; numApp++)
                {
                    if (numStage == stages)
                    {
                        Console.Write($"L{numStage}{numApp} ");
                    }
                    else if (numStage % 2 == 1)
                    {
                        Console.Write($"A{numStage}{numApp} ");
                    }
                    else
                    {
                        Console.Write($"O{numStage}{numApp} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
