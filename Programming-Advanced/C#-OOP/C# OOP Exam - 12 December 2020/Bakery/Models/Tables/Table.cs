using System;
using System.Collections.Generic;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            PricePerPerson = pricePerPerson;
            Capacity = capacity;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }


        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get
            {
                return PricePerPerson * NumberOfPeople;
            }
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal sum = 0;
            foreach (var foodOrder in foodOrders)
            {
                sum += foodOrder.Price;
            }

            foreach (var drinkOrder in drinkOrders)
            {
                sum += drinkOrder.Price;
            }

            sum += Price;

            return sum;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            IsReserved = false;
            numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {TableNumber}\r\n" +
            $"Type: {this.GetType().Name}\r\n" +
            $"Capacity: {Capacity}\r\n" +
            $"Price per Person: {PricePerPerson:f2}";
        }
    }
}