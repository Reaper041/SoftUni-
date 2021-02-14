using System;
using System.Data;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] bakery = new char[n, n];
            int myRow = 0;
            int myCol = 0;
            int firstORow = 0;
            int firstOCol = 0;
            int secondORow = 0;
            int secondOCol = 0;
            int sum = 0;

            int count = 0;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    bakery[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }

                    if (input[col] == 'O' && count == 0)
                    {
                        firstORow = row;
                        firstOCol = col;
                        count++;
                    }

                    if (input[col] == 'O' && count == 1)
                    {
                        secondORow = row;
                        secondOCol = col;
                    }
                }
            }


            while (sum < 50)
            {
                string command = Console.ReadLine();

                bakery[myRow, myCol] = '-';

                if (command == "up")
                {
                    myRow -= 1;
                }
                else if (command == "down")
                {
                    myRow += 1;
                }
                else if (command == "left")
                {
                    myCol -= 1;
                }
                else
                {
                    myCol += 1;
                }

                if (!IsIndexValid(myRow, myCol, n, n))
                {
                    Console.WriteLine($"Bad news, you are out of the bakery.");
                    break;
                }


                if (bakery[myRow, myCol] == 'O')
                {
                    if (myRow == firstORow && myCol == firstOCol)
                    {
                        myRow = secondORow;
                        myCol = secondOCol;
                    }
                    else
                    {
                        myRow = secondORow;
                        myCol = secondOCol;
                    }

                    bakery[firstORow, firstOCol] = '-';
                    bakery[secondORow, secondOCol] = '-';
                }

                if (char.IsNumber(bakery[myRow, myCol]))
                {
                    sum += int.Parse(bakery[myRow, myCol].ToString());
                }

                bakery[myRow, myCol] = 'S';
            }

            if (sum >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsIndexValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols) 
            {
                return false;
            }

            return true;
        }
    }
}
