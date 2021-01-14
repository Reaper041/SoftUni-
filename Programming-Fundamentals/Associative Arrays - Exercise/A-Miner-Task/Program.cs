using System;
using System.Collections.Generic;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resourse = Console.ReadLine();
            Dictionary<string, int> resourses = new Dictionary<string, int>();

            while (resourse != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (resourses.ContainsKey(resourse))
                {
                    resourses[resourse] += quantity;
                }
                else
                {
                    resourses.Add(resourse, quantity);
                }

                resourse = Console.ReadLine();
            }

            foreach (var res in resourses)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }
        }
    }
}
