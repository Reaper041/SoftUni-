using System;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] firstArray = new string[n];
            string[] secondArray = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] intArrays = Console.ReadLine().Split();
                if (i % 2 == 0)
                {
                    firstArray[i] = intArrays[0]; 
                    secondArray[i] = intArrays[1];
                }
                else
                {
                    firstArray[i] = intArrays[1];
                    secondArray[i] = intArrays[0];
                }
            }
            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));

        }
    }
}
