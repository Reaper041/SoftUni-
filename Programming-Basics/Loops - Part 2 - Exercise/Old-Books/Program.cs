using System;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favBook = Console.ReadLine();
            int numOfBooks = int.Parse(Console.ReadLine());

            int count = 0;

            while (numOfBooks > 0)
            {
                string book = Console.ReadLine();
                if (book == favBook)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
                count++;
                numOfBooks--;
            }

            if (numOfBooks == 0)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }

        }
    }
}
