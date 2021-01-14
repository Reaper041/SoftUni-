using System;
using System.Linq;

namespace Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bool isSpecial = false;
            for (int i = 0; i < array.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (i == 0)
                    {
                        sumLeft = 0;
                    }
                    else if (i != 0 && i > j)
                    {
                        sumLeft += array[j];
                    }
                    if (i == array.Length - 1)
                    {
                        sumRight = 0;
                    }
                    else if (i < array.Length - 1 && i < j)
                    {
                        sumRight += array[j];
                    }
                }
                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    isSpecial = true;
                    break;
                }
            }
            if (isSpecial == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
