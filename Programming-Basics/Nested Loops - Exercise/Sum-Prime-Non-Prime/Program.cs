using System;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            int primeSum = 0;
            int nonPrimeSum = 0;

            while (n != "stop")
            {
                int count = 0;
                for (int i = 1; i <= int.Parse(n); i++)
                {
                    if (int.Parse(n) % i == 0)
                    {
                        count++;
                    }
                }

                if (int.Parse(n) < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (count > 2)
                {
                    nonPrimeSum += int.Parse(n);
                }
                else
                {
                    primeSum += int.Parse(n);
                }
                n = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
