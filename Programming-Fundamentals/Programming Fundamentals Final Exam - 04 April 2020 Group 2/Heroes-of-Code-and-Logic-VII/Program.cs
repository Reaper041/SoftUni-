using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> heroes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] hero = Console.ReadLine().Split();
                string heroName = hero[0];
                int heroHP = int.Parse(hero[1]);
                int heroMP = int.Parse(hero[2]);

                if (!heroes.ContainsKey(heroName))
                {
                    heroes.Add(heroName, new Dictionary<string, int>()
                    {
                        { "heroHP", heroHP },
                        { "heroMP", heroMP }
                    });
                }
            }

            string[] input = Console.ReadLine().Split(" - ");

            while (input[0] != "End")
            {
                string command = input[0];
                string heroName = input[1];

                if (command == "CastSpell")
                {
                    int MPNeeded = int.Parse(input[2]);
                    string spellName = input[3];

                    if (heroes[heroName]["heroMP"] >= MPNeeded)
                    {
                        heroes[heroName]["heroMP"] -= MPNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName]["heroMP"]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(input[2]);
                    string attacker = input[3];
                    heroes[heroName]["heroHP"] -= damage;
                    if (heroes[heroName]["heroHP"] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName]["heroHP"]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);
                    }
                }
                else if (command == "Recharge")
                {
                    int amount = int.Parse(input[2]);
                    heroes[heroName]["heroMP"] += amount;
                    if (heroes[heroName]["heroMP"] > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {Math.Abs(heroes[heroName]["heroMP"] - 200 - amount)} MP!");
                        heroes[heroName]["heroMP"] = 200;
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                }
                else
                {
                    int amount = int.Parse(input[2]);
                    heroes[heroName]["heroHP"] += amount;
                    if (heroes[heroName]["heroHP"] > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {Math.Abs(heroes[heroName]["heroHP"] - 100 - amount)} HP!");
                        heroes[heroName]["heroHP"] = 100;
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                }
                input = Console.ReadLine().Split(" - ");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes
                .OrderByDescending(x => x.Value["heroHP"])
                .ThenBy(x => x.Key))
            {
                sb.AppendLine(hero.Key);
                sb.AppendLine($"  HP: {hero.Value["heroHP"]}");
                sb.AppendLine($"  MP: {hero.Value["heroMP"]}");
            }

            Console.WriteLine(sb);
        }
    }
}
