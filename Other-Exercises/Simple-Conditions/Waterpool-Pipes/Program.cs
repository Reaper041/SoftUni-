using System;

namespace Waterpool_Pipes
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            int firstPipe = int.Parse(Console.ReadLine());
            int secondPipe = int.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());
            double waterFromfirstpipe = time * firstPipe;
            double waterFromsecondpipe = time * secondPipe;
            double waterInpool = (firstPipe + secondPipe) * time;

            if (waterInpool <= v)
            {
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                    Math.Truncate(waterInpool / v * 100),
                    Math.Truncate(waterFromfirstpipe / waterInpool * 100),
                    Math.Truncate(waterFromsecondpipe / waterInpool * 100));
            }
            else
            {
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.",
                    time, waterInpool - v);
            }
            
        }
    }
}
