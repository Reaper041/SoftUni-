using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPeople = int.Parse(Console.ReadLine());
            int maxPerCourse = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling(totalPeople / (double)maxPerCourse);

            Console.WriteLine(courses);
        }
    }
}
