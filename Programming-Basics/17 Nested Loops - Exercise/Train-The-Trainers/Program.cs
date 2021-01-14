using System;

namespace _08trainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberJury = int.Parse(Console.ReadLine());

            double sum = 0;
            double allSum = 0;
            double midleSum = 0;
            int counter = 0;
            string namePresentation = "";

            while (true)
            {
                namePresentation = Console.ReadLine();

                if (namePresentation == "Finish")
                {
                    break;
                }
                for (int i = 1; i <= numberJury; i++)
                {
                    double evaluation = double.Parse(Console.ReadLine());
                    sum += evaluation;
                    allSum = sum / numberJury;
                    counter++;
                }

                Console.WriteLine($"{namePresentation} - {allSum:f2}.");
                midleSum += sum;
                sum = 0;
            }
            midleSum /= counter;
            Console.WriteLine($"Student's final assessment is {midleSum:f2}.");
        }
    }
}