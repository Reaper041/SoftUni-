using System;
using System.Collections.Generic;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> users = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string username = input[1];

                if (command == "register")
                {
                    string licenseNumber = input[2];

                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {users[username]}");
                    }
                    else
                    {
                        users.Add(username, licenseNumber);
                        Console.WriteLine($"{username} registered {licenseNumber} successfully");
                    }
                }
                else
                {
                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
