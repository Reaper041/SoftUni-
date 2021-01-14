using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string enteredPass = Console.ReadLine();

            while (enteredPass != password)
            {
                enteredPass = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}
