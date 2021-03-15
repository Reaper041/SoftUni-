using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
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

        public double Cost
        {
            get => cost;
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    System.Environment.Exit(0);
                }

                cost = value;
            }
        }

    }
}