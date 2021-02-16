using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int myRow = 0;
            int myCol = 0;


            for (int row = 0; row < n; row++)
            {
                string arrInput = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arrInput[col];

                    if (arrInput[col] == 'B')
                    {
                        myRow = row;
                        myCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            int flowers = 0;

            while (command != "End")
            {
                matrix[myRow, myCol] = '.';

                myRow = MoveRow(myRow, command);
                myCol = MoveCol(myCol, command);

                if (!IsValidIndex(myRow, myCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[myRow, myCol] == 'f')
                {
                    flowers++;
                }
                else if (matrix[myRow, myCol] == 'O')
                {
                    matrix[myRow, myCol] = '.';

                    myRow = MoveRow(myRow, command);
                    myCol = MoveCol(myCol, command);

                    if (!IsValidIndex(myRow, myCol, n, n))
                    {
                        break;
                    }

                    if (matrix[myRow, myCol] == 'f')
                    {
                        flowers++;
                    }
                }

                matrix[myRow, myCol] = 'B';

                command = Console.ReadLine();
            }

            if (flowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }



            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsValidIndex(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            else if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            else if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
