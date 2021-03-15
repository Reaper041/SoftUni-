using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> peopleList = new List<Person>();

            foreach (var personStr in people)
            {
                string[] input = personStr.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                double money = double.Parse(input[1]);
                Person person = new Person(name, money);

                peopleList.Add(person);
            }

            List<Product> productsList = new List<Product>();

            foreach (var productStr in products)
            {
                string[] input = productStr.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                double cost = double.Parse(input[1]);
                Product product = new Product(name, cost);

                productsList.Add(product);
            }

            string[] inputCmnd = Console.ReadLine().Split();

            while (inputCmnd[0] != "END")
            {
                string name = inputCmnd[0];
                string productName = inputCmnd[1];

                Person currPerson = peopleList.Find(n => n.Name == name);
                Product currProduct = productsList.Find(n => n.Name == productName);

                currPerson.BuyProduct(currProduct);

                inputCmnd = Console.ReadLine().Split();
            }

            foreach (var person in peopleList)
            {
                Console.Write($"{person.Name} - ");
                if (person.BagOfProducts.Any())
                {
                    for (int i = 0; i < person.BagOfProducts.Count; i++)
                    {
                        if (i == person.BagOfProducts.Count - 1)
                        {
                            Console.WriteLine(person.BagOfProducts[i].Name);
                        }
                        else
                        {

                            Console.Write(person.BagOfProducts[i].Name + ", ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nothing bought");
                }
            }
        }
    }
}
