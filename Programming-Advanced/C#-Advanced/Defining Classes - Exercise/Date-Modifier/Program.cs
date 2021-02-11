using System;

namespace Date_Modifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(Math.Abs(DateModifier.DaysDifference(firstDate, secondDate)));
        }
    }
}
