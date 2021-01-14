using System;

namespace Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            if (country == "England" || country == "USA")
            {
                Console.WriteLine("English");
            }
            else if (country == "Mexico" || country == "Argentina" || country == "Spain")
            {
                Console.WriteLine("Spanish");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
