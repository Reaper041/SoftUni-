using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            foreach (var person in People)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                }
            }

            return People.First(x => x.Age == maxAge);
        }

    }
}
