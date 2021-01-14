using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                List<string> data = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string command = Console.ReadLine();

            if (command == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songs)
                {
                    if (command == song.TypeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }

        }
    }
}
