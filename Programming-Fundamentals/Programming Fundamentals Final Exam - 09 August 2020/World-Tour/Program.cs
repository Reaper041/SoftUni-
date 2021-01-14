using System;

namespace World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string[] input = Console.ReadLine().Split(":");

            while (input[0] != "Travel")
            {
                string command = input[0];
                if (command == "Add Stop")
                {
                    int index = int.Parse(input[1]);
                    string stop = input[2];

                    stops = stops.Insert(index, stop);
                    Console.WriteLine(stops);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    int count = endIndex - startIndex + 1;
                    if (startIndex >= 0 && endIndex < stops.Length)
                    {
                        stops = stops.Remove(startIndex, count);
                    }
                    Console.WriteLine(stops);
                }
                else
                {
                    string oldString = input[1];
                    string newString = input[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                    Console.WriteLine(stops);
                }
                input = Console.ReadLine().Split(":");
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
