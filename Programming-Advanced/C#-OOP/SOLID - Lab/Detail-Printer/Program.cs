using System;
using System.Collections.Generic;

namespace Detail_Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Petko", new List<string> { "C#", "Python", "Java"});
            Employee employee = new Employee("Stephen");

            List<INameable> people = new List<INameable> {manager, employee};

            DetailsPrinter detailsPrinter = new DetailsPrinter(people);

            detailsPrinter.PrintDetails();
        }
    }
}
