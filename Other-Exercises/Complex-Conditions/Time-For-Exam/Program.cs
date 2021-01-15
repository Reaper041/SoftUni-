using System;

namespace Time_For_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arivingHour = int.Parse(Console.ReadLine());
            int arivingMin = int.Parse(Console.ReadLine());
            int examTimeinMin = examHour * 60 + examMin;
            int arivingTimeinMin = arivingHour * 60 + arivingMin;
            int differenceMin = 0;
            int differenceHours = 0;


            if (examTimeinMin - arivingTimeinMin > 30)
            {
                Console.WriteLine("Early");
                differenceMin = examTimeinMin - arivingTimeinMin;
                if (differenceMin >=60 && differenceMin < 120)
                {
                    differenceHours += 1;
                    differenceMin -= 60;
                    if (differenceMin > 9) Console.WriteLine("{0}:{1} hours before the start", differenceHours, differenceMin);
                    else Console.WriteLine("{0}:0{1} hours before the start", differenceHours, differenceMin);
                }
                else if (differenceMin >= 180)
                {
                    differenceHours += 3;
                    differenceMin -= 180;
                    if (differenceMin > 9) Console.WriteLine("{0}:{1} hours before the start", differenceHours, differenceMin);
                    else Console.WriteLine("{0}:0{1} hours before the start", differenceHours, differenceMin);
                }
                else
                {
                    Console.WriteLine("{0} minutes before the start", differenceMin);
                }
            }
            else if (arivingTimeinMin - examTimeinMin >= 1)
            {
                Console.WriteLine("Late");
                differenceMin = arivingTimeinMin - examTimeinMin;
                if (differenceMin >= 60)
                {
                    differenceHours += 1;
                    differenceMin -= 60;

                    if (differenceMin > 9) Console.WriteLine("{0}:{1} hours after the start", differenceHours, differenceMin);
                    else Console.WriteLine("{0}:0{1} hours after the start", differenceHours, differenceMin);
                }
                else
                {
                    Console.WriteLine("{0} minutes after the start", differenceMin);
                }
            }
            else
            {
                Console.WriteLine("On time");
                if (examTimeinMin - arivingTimeinMin > 0) Console.WriteLine(examTimeinMin - arivingTimeinMin + " minutes before the start");
                else Console.WriteLine(arivingTimeinMin - examTimeinMin + " minutes after the start");
            }
        }
    }
}
