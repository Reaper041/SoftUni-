using System;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int availableDays = int.Parse(Console.ReadLine());
            double workers = double.Parse(Console.ReadLine());

            double workingDays = availableDays - 0.1 * availableDays;
            double workingHours = Math.Floor(workingDays * 8 + 2 * workers * workingDays);

            if (neededHours < workingHours)
            {
                Console.WriteLine("Yes!{0} hours left.", workingHours - neededHours);
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.", neededHours - workingHours);
            }

        }
    }
}
