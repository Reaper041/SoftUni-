using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];


            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] info = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = info[col];
                }
            }

            int count = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    bool flag = matrix[row, col] == matrix[row, col + 1] &&
                                matrix[row, col] == matrix[row + 1, col] &&
                                matrix[row, col] == matrix[row + 1, col + 1];
                    if (flag)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
