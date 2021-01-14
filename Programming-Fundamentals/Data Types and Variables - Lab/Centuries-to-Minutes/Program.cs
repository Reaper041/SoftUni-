using System;

namespace Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            short centuries = short.Parse(Console.ReadLine());

            int years = centuries * 100;
            double days = years * 365.2422;
            long hours = (long)Math.Round(days) * 24;
            long minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years " +
                $"= {Math.Round(days)} days = {hours} hours = {minutes} minutes");
        }
    }
}
