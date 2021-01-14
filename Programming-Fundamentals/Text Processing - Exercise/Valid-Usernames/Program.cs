using System;
using System.Collections.Generic;
using System.Linq;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine().Split(", ")
                .ToList();
            List<string> validUsernames = new List<string>();

            foreach (string username in usernames)
            {
                bool isValid = true;
                if (username.Length > 3 && username.Length < 16)
                {
                    foreach (var letter in username)
                    {
                        if (!(char.IsLetter(letter) || char.IsNumber(letter) || letter == '-' || letter == '_'))
                        {
                            isValid = false;
                        }
                    }

                    if (isValid)
                    {
                        validUsernames.Add(username);
                    }
                }
            }

            foreach (var username in validUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
