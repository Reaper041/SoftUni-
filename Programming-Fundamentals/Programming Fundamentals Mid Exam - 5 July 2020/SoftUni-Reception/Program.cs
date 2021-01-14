using System;

namespace SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEff = int.Parse(Console.ReadLine());
            int secondEmployeeEff = int.Parse(Console.ReadLine());
            int thirdEmployeeEff = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int sumEff = firstEmployeeEff + secondEmployeeEff + thirdEmployeeEff;

            int hoursCount = 0;

            while (studentsCount > 0)
            {
                hoursCount++;
                if (hoursCount % 4 == 0)
                {
                    continue;
                }
                studentsCount -= sumEff;
            }

            Console.WriteLine($"Time needed: {hoursCount}h.");
        }
    }
}
