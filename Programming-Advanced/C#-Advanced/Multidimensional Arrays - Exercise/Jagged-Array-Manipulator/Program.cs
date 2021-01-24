using System;
using System.Linq;
using System.Security.Cryptography;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                matrix[row] = new double[elements.Length];
                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row][col] = elements[col];
                }
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                string command = input[0];
                int row = int.Parse(input[1]);
                int column = int.Parse(input[2]);
                int value = int.Parse(input[3]);
                bool isIndexesValid = row >= 0 &&
                                      row < n &&
                                      column >= 0 &&
                                      column < matrix[row].Length;

                if (isIndexesValid)
                {
                    if (command == "Add")
                    {
                        matrix[row][column] += value;
                    }
                    else if (command == "Subtract")
                    {
                        matrix[row][column] -= value;
                    }
                }

                input = Console.ReadLine().Split();
            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
