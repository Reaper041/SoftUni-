using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string password = string.Empty;
            for (int i = user.Length - 1; i >= 0; i--)
            {
                password += user[i];
            }
            int count = 0;
            while (true)
            {
                string tryPass = Console.ReadLine();
                if (password != tryPass)
                {
                    count++;
                    if (count == 4)
                    {
                        Console.WriteLine($"User {user} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {user} logged in.");
                    break;
                }
            }
        }
    }
}
