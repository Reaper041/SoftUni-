using System;

namespace Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = n; i <= l; i++)
            {
                string current = i.ToString();
                int sumEven = 0;
                int sumOdd = 0;

                for (int r = 0; r < current.Length; r++)
                {
                    int currentDigit = int.Parse(current[r].ToString());

                    if (r % 2 == 0)
                    {
                        sumEven += currentDigit;
                    }
                    else
                    {
                        sumOdd += currentDigit;
                    }
                }
                if (sumEven == sumOdd)
                {
                    Console.Write(current + " ");
                }
            }
        }
    }
}
