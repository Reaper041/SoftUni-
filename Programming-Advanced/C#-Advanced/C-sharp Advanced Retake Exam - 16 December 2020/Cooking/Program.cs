using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] ingredientsArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsArr);
            Stack<int> ingredients = new Stack<int>(ingredientsArr);


            Dictionary<string, int> foodCooked = new Dictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Fruit Pie", 0},
                {"Pastry", 0}
            };

            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                int liquidValue = liquids.Dequeue();
                int ingredientValue = ingredients.Pop();
                int sum = liquidValue + ingredientValue;

                switch (sum)
                {
                    case 25:
                        foodCooked["Bread"]++;
                        break;
                    case 50:
                        foodCooked["Cake"]++;
                        break;
                    case 75:
                        foodCooked["Pastry"]++;
                        break;
                    case 100:
                        foodCooked["Fruit Pie"]++;
                        break;
                    default:
                        ingredients.Push(ingredientValue + 3);
                        break;
                }
            }

            if (foodCooked.All(x => x.Value > 0))
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var food in foodCooked)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
