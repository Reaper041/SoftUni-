using System;
using System.Collections.Generic;
using System.Linq;

namespace Angry_Pet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRatings = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            string typeOfPriceRatings = Console.ReadLine();

            int leftSum = 0;
            int rightSum = 0;

            for (int i = entryPoint - 1; i >= 0; i--)
            {
                if (typeOfItems == "cheap")
                {
                    if (typeOfPriceRatings == "positive")
                    {
                        if (priceRatings[i] < priceRatings[entryPoint] && priceRatings[i] > 0)
                        {
                            leftSum += priceRatings[i];
                        }
                    }
                    else if (typeOfPriceRatings == "negative")
                    {
                        if (priceRatings[i] < priceRatings[entryPoint] && priceRatings[i] < 0)
                        {
                            leftSum += priceRatings[i];
                        }
                    }
                    else if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        leftSum += priceRatings[i];
                    }
                }
                else if (typeOfItems == "expensive")
                {
                    if (typeOfPriceRatings == "positive")
                    {
                        if (priceRatings[i] >= priceRatings[entryPoint] && priceRatings[i] > 0)
                        {
                            leftSum += priceRatings[i];
                        }
                    }
                    else if (typeOfPriceRatings == "negative")
                    {
                        if (priceRatings[i] >= priceRatings[entryPoint] && priceRatings[i] < 0)
                        {
                            leftSum += priceRatings[i];
                        }
                    }
                    else if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        leftSum += priceRatings[i];
                    }
                }
            }
            for (int i = entryPoint + 1; i < priceRatings.Count; i++)
            {
                if (typeOfItems == "cheap")
                {
                    if (typeOfPriceRatings == "positive")
                    {
                        if (priceRatings[i] < priceRatings[entryPoint] && priceRatings[i] > 0)
                        {
                            rightSum += priceRatings[i];
                        }
                    }
                    else if (typeOfPriceRatings == "negative")
                    {
                        if (priceRatings[i] < priceRatings[entryPoint] && priceRatings[i] < 0)
                        {
                            rightSum += priceRatings[i];
                        }
                    }
                    else if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        rightSum += priceRatings[i];
                    }
                }
                else if (typeOfItems == "expensive")
                {
                    if (typeOfPriceRatings == "positive")
                    {
                        if (priceRatings[i] >= priceRatings[entryPoint] && priceRatings[i] > 0)
                        {
                            rightSum += priceRatings[i];
                        }
                    }
                    else if (typeOfPriceRatings == "negative")
                    {
                        if (priceRatings[i] >= priceRatings[entryPoint] && priceRatings[i] < 0)
                        {
                            rightSum += priceRatings[i];
                        }
                    }
                    else if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        rightSum += priceRatings[i];
                    }
                }
            }

            if (leftSum > rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else if (rightSum > leftSum)
            {
                Console.WriteLine($"Right - {rightSum}");
            }
            else
            {
                Console.WriteLine($"Left - {leftSum}");
            }
        }
    }
}
