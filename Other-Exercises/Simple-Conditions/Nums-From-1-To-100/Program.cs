using System;

namespace Nums_From_1_To_100
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int firstDigit = num / 10;
            int secondDigit = num % 10;

            if (num == 1)
            {
                Console.WriteLine("one");
            }
            else if (num == 2)
            {
                Console.WriteLine("two");
            }
            else if (num == 3)
            {
                Console.WriteLine("three");
            }
            else if (num == 4)
            {
                Console.WriteLine("four");
            }
            else if (num == 5)
            {
                Console.WriteLine("five");
            }
            else if (num == 6)
            {
                Console.WriteLine("six");
            }
            else if (num == 7)
            {
                Console.WriteLine("seven");
            }
            else if (num == 8)
            {
                Console.WriteLine("eight");
            }
            else if (num == 9)
            {
                Console.WriteLine("nine");
            }

            if (firstDigit == 1 && secondDigit == 0)
            {
                Console.WriteLine("ten");
            }
            else if (firstDigit == 1 && secondDigit == 1)
            {
                Console.WriteLine("eleven");
            }
            else if (firstDigit == 1 && secondDigit == 2)
            {
                Console.WriteLine("twelve");
            }
            else if (firstDigit == 1 && secondDigit == 3)
            {
                Console.WriteLine("thirteen");
            }
            else if (firstDigit == 2 && secondDigit == 0)
            {
                Console.WriteLine("twenty");
            }
            else if (firstDigit == 3 && secondDigit == 0)
            {
                Console.WriteLine("thirty");
            }
            else if (firstDigit == 4 && secondDigit == 0)
            {
                Console.WriteLine("fourty");
            }
            else if (firstDigit == 5 && secondDigit == 0)
            {
                Console.WriteLine("fifty");
            }
            else if (firstDigit == 6 && secondDigit == 0)
            {
                Console.WriteLine("sixty");
            }
            else if (firstDigit == 7 && secondDigit == 0)
            {
                Console.WriteLine("seventy");
            }
            else if (firstDigit == 8 && secondDigit == 0)
            {
                Console.WriteLine("eighty");
            }
            else if (firstDigit == 9 && secondDigit == 0)
            {
                Console.WriteLine("ninety");
            }


            if (firstDigit == 2 && secondDigit != 0)
            {
                firstDigit = "twenty";
            }
            else if (firstDigit == 3 && secondDigit != 0)
            {
                firstDigit = "thirty";
            }
            else if (firstDigit == 4 && secondDigit != 0)
            {
                firstDigit = "fourty";
            }
            else if (firstDigit == 5 && secondDigit != 0)
            {
                firstDigit = "fifty";
            }
            else if (firstDigit == 6 && secondDigit != 0)
            {
                firstDigit = "sixty";
            }
            else if (firstDigit == 7 && secondDigit != 0)
            {
                firstDigit = "seventy";
            }
            else if (firstDigit == 8 && secondDigit != 0)
            {
                firstDigit = "eighty";
            }
            else if (firstDigit == 9 && secondDigit != 0)
            {
                firstDigit = "ninety";
            }

            if (secondDigit == 1)
            {
                secondDigit = "one";
            }
            else if (secondDigit == 2)
            {
                secondDigit = "two";
            }
            else if (secondDigit == 3)
            {
                secondDigit = "three";
            }
            else if (secondDigit == 4)
            {
                secondDigit = "four";
            }
            else if (secondDigit == 5)
            {
                secondDigit = "five";
            }
            else if (secondDigit == 6)
            {
                secondDigit = "six";
            }
            else if (secondDigit == 7)
            {
                secondDigit = "seven";
            }
            else if (secondDigit == 8)
            {
                secondDigit = "eight";
            }
            else if (secondDigit == 9)
            {
                secondDigit = "nine";
            }


            if (num == 100)
            {
                Console.WriteLine("one hundred");
            }

            if (num > 20 && num < 100 && secondDigit != 0)
            {
                Console.WriteLine(firstDigit + " " + secondDigit);
            }

        }
    }
}
