using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int count = 0;
            double sum = 0;


            while (count < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    continue;
                }
                sum += grade;
                count++;
            }
            Console.WriteLine($"{name} graduated. Average grade: {sum / count:f2}");
        }
    }
}
