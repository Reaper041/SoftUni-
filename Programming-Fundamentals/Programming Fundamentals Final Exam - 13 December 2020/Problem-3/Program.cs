using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("->");

            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            while (input[0] != "Statistics")
            {
                string command = input[0];
                string username = input[1];

                if (command == "Add")
                {
                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else
                    {
                        users.Add(username, new List<string>());
                    }
                }
                else if (command == "Send")
                {
                    string email = input[2];
                    users[username].Add(email);
                }
                else
                {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
                input = Console.ReadLine().Split("->");
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(x=> x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var VARIABLE in user.Value)
                {
                    Console.WriteLine($" - {VARIABLE}");
                }
            }
        }
    }
}
