using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] objects = Console.ReadLine().Split();

                if (objects.Length == 3)
                {
                    Rebel rebel = new Rebel(objects[0], int.Parse(objects[1]), objects[2]);
                    buyers.Add(rebel);
                }
                else
                {
                    Citizen citizen = new Citizen(objects[0], int.Parse(objects[1]), objects[2], objects[3]);
                    buyers.Add(citizen);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (buyers.Exists(x => x.Name == input))
                {
                    buyers.FirstOrDefault(x => x.Name == input).BuyFood();
                }

                input = Console.ReadLine();
            }

            int foodTotal = 0;

            foreach (var buyer in buyers)
            {
                foodTotal += buyer.Food;
            }

            Console.WriteLine(foodTotal);
        }
    }
}
