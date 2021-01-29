using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\some-text.txt"))
            {
                string line = reader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        List<char> splitters = new List<char>() { '-', ',', '.', '!', '?' };

                        foreach (var splitter in splitters)
                        {
                            if (line.Contains(splitter))
                            {
                                line = line.Replace(splitter, '@');
                            }
                        }


                        string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);


                        Console.WriteLine(string.Join(' ', words.Reverse()));
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
