using System;

namespace Time_Plus_15_Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int minutesPlus15 = minutes + 15;

            if (minutesPlus15 >= 60)
            {
                hours++;
                minutesPlus15 -= 60;
            }
            if (minutesPlus15 >= 60)
            {
                hours++;
                minutesPlus15 -= 60;
            }
            if (minutesPlus15 >= 60)
            {
                hours++;
                minutesPlus15 -= 60;
            }

            if (hours > 23)
            {
                hours -= 24;
            }

            if (minutesPlus15 <= 9)
            {
                Console.WriteLine(hours + ":0" + minutesPlus15);
            }
            else
            {
                Console.WriteLine(hours + ":" + minutesPlus15);
            }
        }
    }
}
