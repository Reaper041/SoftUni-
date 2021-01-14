using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            GradeInWords(grade);
        }

        static void GradeInWords(double number)
        {
            if (number <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (number <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (number <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (number <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
