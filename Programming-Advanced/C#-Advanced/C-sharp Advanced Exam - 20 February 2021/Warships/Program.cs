using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] coordsArr = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[n, n];

            int firstPlayerShipsCount = 0;
            int secondPlayerShipsCount = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == '<')
                    {
                        firstPlayerShipsCount++;
                    }
                    else if (input[col] == '>')
                    {
                        secondPlayerShipsCount++;
                    }
                }
            }

            int pair = 0;
            bool flag = true;
            int sunk = 0;

            while (firstPlayerShipsCount > 0 && secondPlayerShipsCount > 0)
            {


                int[] pairArr = coordsArr[pair].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int row = pairArr[0];
                int col = pairArr[1];

                if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
                {
                    if (coordsArr.Length - 1 == pair)
                    {
                        break;
                    }
                    pair++;
                    continue;
                }


                if (matrix[row, col] == '>')
                {
                    secondPlayerShipsCount--;
                    sunk++;

                    matrix[row, col] = 'X';
                }
                if (matrix[row, col] == '<')
                {
                    firstPlayerShipsCount--;
                    sunk++;

                    matrix[row, col] = 'X';
                }

                if (matrix[row, col] == '#')
                {
                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] == '<')
                        {
                            firstPlayerShipsCount--;
                            sunk++;
                        }
                        else if (matrix[row - 1, col] == '>')
                        {
                            secondPlayerShipsCount--;
                            sunk++;
                        }
                        matrix[row - 1, col] = 'X';
                    }

                    if (row - 1 >= 0 && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row - 1, col + 1] == '<')
                        {
                            firstPlayerShipsCount--;
                            sunk++;
                        }
                        else if (matrix[row - 1, col + 1] == '>')
                        {
                            secondPlayerShipsCount--;
                            sunk++;
                        }
                        matrix[row - 1, col + 1] = 'X';
                    }

                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        if (matrix[row - 1, col - 1] == '<')
                        {
                            firstPlayerShipsCount--;
                            sunk++;
                        }
                        else if (matrix[row - 1, col - 1] == '>')
                        {
                            secondPlayerShipsCount--;
                            sunk++;
                        }
                        matrix[row - 1, col - 1] = 'X';
                    }

                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] == '<')
                        {
                            firstPlayerShipsCount--;
                            sunk++;
                        }
                        else if (matrix[row, col - 1] == '>')
                        {
                            secondPlayerShipsCount--;
                            sunk++;
                        }
                        matrix[row, col - 1] = 'X';
                    }

                    if (col + 1 < n)
                    {
                        if (matrix[row, col + 1] == '<')
                        {
                            firstPlayerShipsCount--;
                            sunk++;
                        }
                        else if (matrix[row, col + 1] == '>')
                        {
                            secondPlayerShipsCount--;
                            sunk++;
                        }
                        matrix[row, col + 1] = 'X';
                    }

                    if (row + 1 < n)
                    {
                        if (matrix[row + 1, col] == '<')
                        {
                            firstPlayerShipsCount--;
                            sunk++;
                        }
                        else if (matrix[row + 1, col] == '>')
                        {
                            secondPlayerShipsCount--;
                            sunk++;
                        }
                        matrix[row + 1, col] = 'X';
                    }

                    if (row + 1 < n && col - 1 >= 0)
                    {
                        if (matrix[row + 1, col - 1] == '<')
                        {
                            firstPlayerShipsCount--;
                            sunk++;
                        }
                        else if (matrix[row + 1, col - 1] == '>')
                        {
                            secondPlayerShipsCount--;
                            sunk++;
                        }
                        matrix[row + 1, col - 1] = 'X';
                    }

                    if (row + 1 < n && col + 1 < n)
                    {
                        if (matrix[row + 1, col + 1] == '<')
                        {
                            firstPlayerShipsCount--;
                            sunk++;
                        }
                        else if (matrix[row + 1, col + 1] == '>')
                        {
                            secondPlayerShipsCount--;
                            sunk++;
                        }
                        matrix[row + 1, col + 1] = 'X';
                    }
                }

                if (coordsArr.Length - 1 == pair)
                {

                    break;
                }

                pair++;
            }


            if (firstPlayerShipsCount > 0 && secondPlayerShipsCount > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShipsCount} ships left. Player Two has {secondPlayerShipsCount} ships left.");
            }
            else
            {
                if (firstPlayerShipsCount > 0)
                {
                    Console.WriteLine($"Player One has won the game! {sunk} ships have been sunk in the battle.");
                }
                else if (secondPlayerShipsCount > 0)
                {
                    Console.WriteLine($"Player Two has won the game! {sunk} ships have been sunk in the battle.");
                }

            }
        }
    }
}
