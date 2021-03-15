using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                    System.Environment.Exit(0);
                }

                name = value;
            }
        }

        public double Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    System.Environment.Exit(0);
                }

                money = value;
            }
        }

        public List<Product> BagOfProducts { get; set; }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                Money -= product.Cost;
                BagOfProducts.Add(product);
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
}
