using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<IdentityCard> IDCards = new List<IdentityCard>();
            while (input.Length != 1)
            {
                string name = input[0];
                string ID = input[1];
                int age = int.Parse(input[2]);

                IdentityCard IDCard = new IdentityCard();

                IDCard.Name = name;
                IDCard.Age = age;
                IDCard.ID = ID;

                IDCards.Add(IDCard);

                input = Console.ReadLine().Split();
            }

            IDCards = IDCards.OrderBy(x => x.Age).ToList();

            foreach (var IDCard in IDCards)
            {
                Console.WriteLine(IDCard);
            }
        }
    }

    class IdentityCard
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
