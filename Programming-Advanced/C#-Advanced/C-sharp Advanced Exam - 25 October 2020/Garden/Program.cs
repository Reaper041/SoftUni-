using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = dimentions[0];
            int m = dimentions[1];

            int[,] garden = CreateMatrix(n, m);

            string[] input = Console.ReadLine().Split();

            while (input[0] != "Bloom")
            {
                int myRow = int.Parse(input[0]);
                int myCol = int.Parse(input[1]);

                if (myRow < 0 || myRow >= n || myCol < 0 || myCol >= m) 
                {
                    Console.WriteLine("Invalid coordinates.");
                    input = Console.ReadLine().Split();
                    continue;
                }

                for (int i = 0; i < n; i++)
                {
                    garden[myRow, i]++;
                }

                for (int i = 0; i < m; i++)
                {
                    garden[i, myCol]++;
                }

                garden[myRow, myCol]--;

                input = Console.ReadLine().Split();
            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(garden[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static int[,] CreateMatrix(int rows, int cols)
        {

            int[,] garden = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    garden[row, col] = 0;
                }
            }

            return garden;
        }
    }
}
