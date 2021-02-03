using System;

namespace Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int count = 0;
            double sum = 0;
            int countFails = 0;

            while (count < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    countFails++;
                    if (countFails == 2)
                    {
                        count++;
                        Console.WriteLine($"{name} has been excluded at {count} grade");
                        break;
                    }
                    continue;
                }
                sum += grade;
                count++;
            }
            if (count == 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sum / count:f2}");
            }
        }
    }
}
