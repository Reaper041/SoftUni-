using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            double freeSpaceWidth = double.Parse(Console.ReadLine());
            double freeSpaceLength = double.Parse(Console.ReadLine());
            double freeSpaceHeight = double.Parse(Console.ReadLine());

            double freeSpaceVolume = freeSpaceWidth * freeSpaceLength * freeSpaceHeight;

            string boxes = Console.ReadLine();

            while (boxes != "Done")
            {
                freeSpaceVolume -= int.Parse(boxes);
                if (freeSpaceVolume <= 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpaceVolume)} Cubic meters more.");
                    break;
                }
                boxes = Console.ReadLine();
            }
            if (freeSpaceVolume > 0)
            {
                Console.WriteLine($"{freeSpaceVolume} Cubic meters left.");
            }
        }
    }
}
