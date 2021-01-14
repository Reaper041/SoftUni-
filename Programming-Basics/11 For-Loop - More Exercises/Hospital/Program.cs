using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int treated = 0;
            int untreated = 0;
            int doctors = 7;

            for (int day = 1; day <= days; day++)
            {
                int patient = int.Parse(Console.ReadLine());
                if (day % 3 == 0)
                {
                    if (treated < untreated)
                    {
                        doctors++;
                    }
                }
                if (patient <= doctors)
                {
                    treated += patient;
                    untreated += 0;
                }
                else
                {
                    untreated += patient - doctors;
                    treated += doctors;
                }
            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
