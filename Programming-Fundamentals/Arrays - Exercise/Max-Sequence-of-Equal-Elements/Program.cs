using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int maxValue = int.MinValue;
            int bigger = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int count = 1;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count > maxValue)
                {
                    maxValue = count;
                    bigger = array[i];
                }
            }
            for (int i = 0; i < maxValue; i++)
            {
                Console.Write($"{bigger} ");
            }
        }
    }
}
