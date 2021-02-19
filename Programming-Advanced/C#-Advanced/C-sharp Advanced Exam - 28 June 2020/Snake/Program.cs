using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int myRow = 0;
            int myCol = 0;
            int firstBarrelRow = 0;
            int firstBarrelCol = 0;
            int secondBarrelRow = 0;
            int secondBarrelCol = 0;

            int count = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }

                    if (input[col] == 'B' && count == 0)
                    {
                        firstBarrelRow = row;
                        firstBarrelCol = col;
                        count++;
                    }

                    if (input[col] == 'B' && count == 1)
                    {
                        secondBarrelRow = row;
                        secondBarrelCol = col;
                    }
                }
            }

            int foodEaten = 0;
            bool flag = true;

            while (foodEaten < 10)
            {
                string command = Console.ReadLine();

                matrix[myRow, myCol] = '.';

                if (command == "up")
                {
                    myRow--;
                }
                else if (command == "down")
                {
                    myRow++;
                }
                else if (command == "left")
                {
                    myCol--;
                }
                else
                {
                    myCol++;
                }

                if (!IsValidIndex(myRow, myCol, n, n))
                {
                    Console.WriteLine("Game over!");
                    flag = false;
                    break;
                }


                if (matrix[myRow, myCol] == 'B')
                {
                    matrix[myRow, myCol] = '.';
                    if (myRow == firstBarrelRow && myCol == firstBarrelCol)
                    {
                        myRow = secondBarrelRow;
                        myCol = secondBarrelCol;
                    }
                    else
                    {
                        myRow = firstBarrelRow;
                        myCol = firstBarrelCol;
                    }
                }
                else if (matrix[myRow, myCol] == '*')
                {
                    foodEaten++;
                }

                matrix[myRow, myCol] = 'S';
            }

            if (flag)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsValidIndex(int myRow, int myCol, int rows, int cols)
        {
            if (myRow < 0 || myRow >= rows || myCol < 0 || myCol >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
