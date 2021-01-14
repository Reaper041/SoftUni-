using System;

namespace Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            int countOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());


            int bestStudAttendances = 0;
            double maxBonus = int.MinValue;

            for (int i = 0; i < countOfStudents; i++)
            {
                int attendances = int.Parse(Console.ReadLine());

                double totalBonus = attendances * 1.0 / countOfLectures * (5 + additionalBonus);

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    bestStudAttendances = attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Round(maxBonus, MidpointRounding.AwayFromZero)}.");
            Console.WriteLine($"The student has attended {bestStudAttendances} lectures.");

        }
    }
}
