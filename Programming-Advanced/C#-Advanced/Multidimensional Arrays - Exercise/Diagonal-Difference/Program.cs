using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = info[col];
                }
            }

            int prDiagonalSum = 0;
            int secDiagonalSum = 0;

            for (int i = 0; i < n; i++)
            {
                prDiagonalSum += matrix[i, i];
            }

            int last = n - 1;

            for (int row = 0; row < n; row++)
            {
                secDiagonalSum += matrix[row, last];
                last--;
            }

            Console.WriteLine(Math.Abs(prDiagonalSum - secDiagonalSum));

        }
    }
}
