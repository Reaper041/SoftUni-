using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;
            while (steps < 10000)
            {
                string stepsWalked = Console.ReadLine();
                if (stepsWalked == "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    steps += stepsToHome;
                    break;
                }
                steps += int.Parse(stepsWalked);
            }

            if (steps < 10000)
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
            }
        }
    }
}
