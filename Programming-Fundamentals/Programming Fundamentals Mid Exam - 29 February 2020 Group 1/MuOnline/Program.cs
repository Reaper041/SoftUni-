using System;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeons = Console.ReadLine().Split('|');
            int health = 100;
            int bitcoins = 0;

            string[] dungeonInf = new string[1];

            for (int i = 0; i < dungeons.Length; i++)
            {
                dungeonInf = dungeons[i].Split(' ');

                string command = dungeonInf[0];
                int amount = int.Parse(dungeonInf[1]);

                if (command == "potion")
                {
                    int lastHealth = health;
                    health += amount;
                    if (health > 100)
                    {
                        health = 100;
                        Console.WriteLine($"You healed for {100 - lastHealth} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {amount} hp.");
                    }

                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command == "chest")
                {
                    bitcoins += amount;
                    Console.WriteLine($"You found {amount} bitcoins.");
                }
                else
                {
                    health -= amount;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
