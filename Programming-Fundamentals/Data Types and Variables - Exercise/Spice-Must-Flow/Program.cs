using System;

namespace Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int spiceSum = 0;
            int countDays = 0;
            while (startingYield >= 100)
            {
                spiceSum += startingYield;
                spiceSum -= 26; 
                countDays++;
                startingYield -= 10;
            }
            spiceSum -= 26;
            if (spiceSum < 0)
            {
                spiceSum = 0;
            }
            Console.WriteLine(countDays);
            Console.WriteLine(spiceSum);
        }
    }
}
