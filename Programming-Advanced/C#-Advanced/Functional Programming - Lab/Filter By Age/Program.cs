using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                people[i] = new Person();
                people[i].Name = input[0];
                people[i].Age = int.Parse(input[1]);
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());

            Func<Person, bool> ageCondition = GetAgeCondition(filter, filterAge);

            string formatter = Console.ReadLine();

            Func<Person, string> formatterString = GetFormatter(formatter);

            PrintPeople(people, ageCondition, formatterString);

        }

        static void PrintPeople(Person[] people, 
            Func<Person, bool> ageCondition, 
            Func<Person, string> formatterString)
        {
            foreach (var person in people)
            {
                if (ageCondition(person))
                {
                    Console.WriteLine(formatterString(person));
                }
            }
        }


        static Func<Person, string> GetFormatter(string formatter)
        {
            switch (formatter)
            {
                case "name": return x => $"{x.Name}";
                case "age": return x => $"{x.Age}";
                case "name age": return x => $"{x.Name} - {x.Age}";
                default: return null;
            }
        }

        static Func<Person, bool> GetAgeCondition(string filter, int filterAge)
        {
            switch (filter)
            {
                case "younger": return x => x.Age < filterAge;
                case "older": return x => x.Age >= filterAge;
                default: return null;
            }
        }

        static void Printer()
        {

        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
