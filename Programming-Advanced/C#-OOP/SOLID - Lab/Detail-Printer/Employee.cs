using System;

namespace Detail_Printer
{
    public class Employee : INameable
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine(this.Name);
        }
    }
}