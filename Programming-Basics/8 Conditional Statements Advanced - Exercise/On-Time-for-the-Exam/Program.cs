using System;
using System.Security.Cryptography;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int chasNaIzpita = int.Parse(Console.ReadLine());
            int minutiNaIzpita = int.Parse(Console.ReadLine());
            int chasNaPristigane = int.Parse(Console.ReadLine());
            int minutiNaPristigane = int.Parse(Console.ReadLine());

            int izpitVMinuti = chasNaIzpita * 60 + minutiNaIzpita;
            int pristiganeVMinuti = chasNaPristigane * 60 + minutiNaPristigane;
            int diff = pristiganeVMinuti - izpitVMinuti;

            if (diff > 0)
            {
                Console.WriteLine("Late");
                if (diff < 60)
                {
                    Console.WriteLine($"{diff} minutes after the start");
                }
                else
                {
                        Console.WriteLine($"{diff / 60}:{diff % 60:d2} hours after the start");
                }
            }
            else if (Math.Abs(diff) > 30)
            {
                Console.WriteLine("Early");
                if (Math.Abs(diff) < 60)
                {
                    Console.WriteLine($"{Math.Abs(diff)} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(diff) / 60}:{Math.Abs(diff) % 60:d2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{Math.Abs(diff)} minutes before the start");
            }
        }
    }
}
