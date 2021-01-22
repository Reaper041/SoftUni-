using System;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string matrixElements = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = matrixElements[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool flag = true;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        flag = false;
                        break;
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}
