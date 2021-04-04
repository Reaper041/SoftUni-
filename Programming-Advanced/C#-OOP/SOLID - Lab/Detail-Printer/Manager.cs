using System;
using System.Collections.Generic;

namespace Detail_Printer
{
    public class Manager : INameable
    {
        public Manager(string name, ICollection<string> documents)
        {
            Name = name;
            this.Documents = new List<string>(documents);
        }

        public string Name { get; set; }

        public IReadOnlyCollection<string> Documents { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine(string.Join(Environment.NewLine, this.Documents));
        }

    }
}