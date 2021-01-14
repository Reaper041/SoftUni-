using System;
using System.Linq;

namespace Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int i = 0;
            int[] condensed = new int[intArr.Length - 1];
            while (intArr.Length > 0)
            {
                condensed[i] = intArr[i] + intArr[i + 1];
                intArr[i] = condensed[i];
                i++;
            }
        }
    }
}
