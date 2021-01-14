using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();

            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            SortedDictionary<string, int> otherMaterials = new SortedDictionary<string, int>();
            bool flag = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                int[] quantity = new int[input.Length / 2];
                string[] materials = new string[input.Length / 2];

                int indexQ = 0;
                int indexM = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        quantity[indexQ] = int.Parse(input[i]);
                        indexQ++;
                    }
                    else
                    {
                        materials[indexM] = input[i].ToLower();
                        indexM++;
                    }
                }

                for (int i = 0; i < quantity.Length; i++)
                {
                    if (materials[i] == "shards")
                    {
                        keyMaterials["shards"] += quantity[i];
                    }

                    if (materials[i] == "motes")
                    {
                        keyMaterials["motes"] += quantity[i];
                    }

                    if (materials[i] == "fragments")
                    {
                        keyMaterials["fragments"] += quantity[i];
                    }

                    if (keyMaterials["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        keyMaterials["shards"] -= 250;
                        flag = true;
                        break;
                    }
                    else if (keyMaterials["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        keyMaterials["fragments"] -= 250;
                        flag = true;
                        break;
                    }
                    else if (keyMaterials["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        keyMaterials["motes"] -= 250;
                        flag = true;
                        break;
                    }

                    if (materials[i] != "shards" && materials[i] != "motes" && materials[i] != "fragments")
                    {
                        if (otherMaterials.ContainsKey(materials[i]))
                        {
                            otherMaterials[materials[i]] += quantity[i];
                        }
                        else
                        {
                            otherMaterials.Add(materials[i], quantity[i]);
                        }
                    }
                }

                if (flag) break;
            }

            Dictionary<string, int> filtered = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var element in filtered)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }

            foreach (var element in otherMaterials)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }
        }
    }
}
