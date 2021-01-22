using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            int[,] matrix = new int[n, n];
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                    sum += elements[col];
                }
            }

            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row >= 0 && row < n && col >= 0 && col < n)
                {
                    if (command == "Add")
                    {
                        matrix[row, col] += value;
                    }
                    else if (command == "Subtract")
                    {
                        matrix[row, col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                input = Console.ReadLine().Split();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
