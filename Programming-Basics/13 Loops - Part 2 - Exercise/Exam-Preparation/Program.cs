using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int allowedBadMarks = int.Parse(Console.ReadLine());

            int badMarks = 0;
            int sum = 0;
            int countExercises = 0;
            string lastExercise = "";

            while (allowedBadMarks != badMarks)
            {
                string exerciseTitle = Console.ReadLine();
                if (exerciseTitle == "Enough")
                {
                    Console.WriteLine($"Average score: {sum * 1.0 / countExercises:f2}");
                    Console.WriteLine($"Number of problems: {countExercises}");
                    Console.WriteLine($"Last problem: {lastExercise}");
                    break;
                }

                lastExercise = exerciseTitle;
                int mark = int.Parse(Console.ReadLine());
                if (mark <= 4)
                {
                    badMarks++;
                }
                sum += mark;
                countExercises++;
            }

            if (badMarks == allowedBadMarks)
            {
                Console.WriteLine($"You need a break, {allowedBadMarks} poor grades.");
            }
        }
    }
}
