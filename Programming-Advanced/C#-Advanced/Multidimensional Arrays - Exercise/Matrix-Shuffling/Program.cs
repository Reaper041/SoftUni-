using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];


            for (int row = 0; row < rows; row++)
            {
                string[] info = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = info[col];
                }
            }

            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                if (input.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine().Split();
                    continue;
                }

                int row1 = int.Parse(input[1]);
                int col1 = int.Parse(input[2]);
                int row2 = int.Parse(input[3]);
                int col2 = int.Parse(input[4]);

                bool isIndexInRange = row1 >= 0 && 
                                      row1 < matrix.GetLength(0) && 
                                      row2 >= 0 &&
                                      row2 < matrix.GetLength(0) && 
                                      col1 >= 0 && 
                                      col1 < matrix.GetLength(1) &&
                                      col2 >= 0 && 
                                      col2 < matrix.GetLength(1);

                if (isIndexInRange)
                {
                    Swap(row1, col1, row2, col2, matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine().Split();
            }
        }

        static void Swap(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            string copy = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = copy;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
