using System;
using System.Linq;
using System.Text;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            int n = length[0];
            int m = length[1];

            string snake = Console.ReadLine();
            char[,] matrix = new char[n, m];
            int count = 0;

            for (int row = 0; row < n; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < m; col++)
                    {
                        matrix[row, col] = snake[count];
                        count++;


                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                    }
                }
                else
                {
                    for (int col = m - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[count];
                        count++;


                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                    }
                }
            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
