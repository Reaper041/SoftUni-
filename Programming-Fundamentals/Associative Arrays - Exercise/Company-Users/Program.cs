using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ");
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string companyName = input[0];
                string employeeID = input[1];
                if (users.ContainsKey(companyName))
                {
                    if (!users[companyName].Contains(employeeID))
                    {
                        users[companyName].Add(employeeID);
                    }
                }
                else
                {
                    users.Add(companyName, new List<string>());
                    users[companyName].Add(employeeID);
                }
                input = Console.ReadLine().Split(" -> ");
            }

            users = users
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in users)
            {
                Console.WriteLine(user.Key);
                foreach (var employee in user.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
