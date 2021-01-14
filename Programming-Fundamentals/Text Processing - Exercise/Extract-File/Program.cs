using System;

namespace Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string[] fileName = file[file.Length - 1].Split('.');

            string name = fileName[0];
            string extension = fileName[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
