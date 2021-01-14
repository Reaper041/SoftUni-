using System;

namespace Concatenate_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string city = Console.ReadLine();

            Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}.", name, surname, age, city);
        }
    }
}
