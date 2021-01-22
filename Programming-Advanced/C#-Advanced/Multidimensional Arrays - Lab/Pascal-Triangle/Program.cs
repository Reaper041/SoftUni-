using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = new long[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    if (row - 1 >= 0 && col < matrix[row].Length - 1)
                    {
                        matrix[row][col] += matrix[row - 1][col];
                    }

                    if (col - 1 >= 0 && row - 1 >= 0)
                    {
                        matrix[row][col] += matrix[row - 1][col - 1];
                    }

                    if (row == 0)
                    {
                        matrix[0][0] = 1;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(' ', matrix[i]));
            }
        }
    }
}
