using System;

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

            bool flag = false;
            while (sum < 50)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        if (myRow - 1 < 0)
                        {
                            flag = true;
                            bakery[myRow, myCol] = '-';
                            break;
                        }
                        else if (char.IsNumber(bakery[myRow - 1, myCol]))
                        {
                            sum += int.Parse(bakery[myRow - 1, myCol].ToString());
                            bakery[myRow - 1, myCol] = 'S';
                            bakery[myRow, myCol] = '-';
                            myRow -= 1;
                        }
                        else if (bakery[myRow - 1, myCol] == 'O')
                        {
                            bakery[myRow - 1, myCol] = '-';
                            if (myRow - 1 != firstORow && myCol != firstOCol)
                            {
                                myRow = firstORow;
                                myCol = firstOCol;
                            }
                            else
                            {
                                myRow = secondORow;
                                myCol = secondOCol;
                            }

                            bakery[myRow, myCol] = 'S';
                        }
                        else
                        {
                            bakery[myRow - 1, myCol] = 'S';
                            myRow -= 1;
                        }
                        break;
                    case "down":
                        if (myRow + 1 > n)
                        {
                            flag = true;
                            break;
                        }
                        else if (char.IsNumber(bakery[myRow + 1, myCol]))
                        {
                            sum += int.Parse(bakery[myRow + 1, myCol].ToString());
                            bakery[myRow + 1, myCol] = 'S';
                            bakery[myRow, myCol] = '-';
                            myRow += 1;
                        }
                        else if (bakery[myRow + 1, myCol] == 'O')
                        {
                            bakery[myRow + 1, myCol] = '-';
                            if (myRow + 1 != firstORow && myCol != firstOCol)
                            {
                                myRow = firstORow;
                                myCol = firstOCol;
                            }
                            else
                            {
                                myRow = secondORow;
                                myCol = secondOCol;
                            }

                            bakery[myRow, myCol] = 'S';
                        }
                        else
                        {
                            bakery[myRow + 1, myCol] = 'S';
                            myRow += 1;
                        }
                        break;
                    case "left":
                        if (myCol - 1 < 0)
                        {
                            flag = true;
                            break;
                        }
                        else if (char.IsNumber(bakery[myRow, myCol - 1]))
                        {
                            sum += int.Parse(bakery[myRow, myCol - 1].ToString());
                            bakery[myRow, myCol - 1] = 'S';
                            bakery[myRow, myCol] = '-';
                            myCol -= 1;
                        }
                        else if (bakery[myRow, myCol - 1] == 'O')
                        {
                            bakery[myRow, myCol - 1] = '-';
                            if (myRow != firstORow && myCol - 1 != firstOCol)
                            {
                                myRow = firstORow;
                                myCol = firstOCol;
                            }
                            else
                            {
                                myRow = secondORow;
                                myCol = secondOCol;
                            }

                            bakery[myRow, myCol] = 'S';
                        }
                        else
                        {
                            bakery[myRow, myCol - 1] = 'S';
                            myCol -= 1;
                        }
                        break;
                    case "right":
                        if (myCol + 1 > n)
                        {
                            flag = true;
                            break;
                        }
                        else if (char.IsNumber(bakery[myRow, myCol + 1]))
                        {
                            sum += int.Parse(bakery[myRow, myCol + 1].ToString());
                            bakery[myRow, myCol + 1] = 'S';
                            bakery[myRow, myCol] = '-';
                            myCol += 1;
                        }
                        else if (bakery[myRow, myCol + 1] == 'O')
                        {
                            bakery[myRow, myCol + 1] = '-';
                            if (myRow != firstORow && myCol + 1 != firstOCol)
                            {
                                myRow = firstORow;
                                myCol = firstOCol;
                            }
                            else
                            {
                                myRow = secondORow;
                                myCol = secondOCol;
                            }

                            bakery[myRow, myCol] = 'S';
                        }
                        else
                        {
                            bakery[myRow, myCol + 1] = 'S';
                            myCol += 1;
                        }
                        break;
                }
            }





            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
