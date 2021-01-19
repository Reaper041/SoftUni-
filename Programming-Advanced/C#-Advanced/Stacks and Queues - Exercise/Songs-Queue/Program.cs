using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Queue<string> songs = new Queue<string>(input);

            while (songs.Any())
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                if (action == "Play")
                {
                    songs.Dequeue();
                }
                else if (action == "Add")
                {
                    string song = string.Empty;
                    for (int i = 1; i < command.Length; i++)
                    {
                        song += command[i] + " ";
                    }

                    song = song.Trim();

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
