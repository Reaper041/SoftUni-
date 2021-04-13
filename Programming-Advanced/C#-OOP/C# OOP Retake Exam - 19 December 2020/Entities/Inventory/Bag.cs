using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            items = new List<Item>();
            Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load
        {
            get
            {
                int sum = 0;
                foreach (var item in items)
                {
                    sum += item.Weight;
                }

                return sum;
            }
        }

        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (name != "FirePotion" && name != "HealthPotion")
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = null;

            if (name == "FirePotion")
            {
                if (!items.Exists(x=>x.GetType().Name == "FirePotion"))
                {
                    throw new ArgumentException($"No item with name {name} in bag!");
                }
                item = new FirePotion();
            }
            else if (name == "HealthPotion")
            {
                if (!items.Exists(x => x.GetType().Name == "HealthPotion"))
                {
                    throw new ArgumentException($"No item with name {name} in bag!");
                }
                item = new HealthPotion();
            }
            items.Remove(item);
            return item;
        }
    }
}