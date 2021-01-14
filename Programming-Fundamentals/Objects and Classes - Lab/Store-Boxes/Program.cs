using System;
using System.Collections.Generic;
using System.Linq;

namespace Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            List<Box> boxes = new List<Box>();

            while (input[0] != "end")
            {
                int serialNum = int.Parse(input[0]);
                double itemQuantity = double.Parse(input[2]);

                Box box = new Box();

                box.Item.ItemName = input[1];
                box.Item.ItemPrice = double.Parse(input[3]);
                box.ItemQuantity = itemQuantity;
                box.SerialNum = serialNum;
                box.BoxPrice = box.ItemQuantity * box.Item.ItemPrice;

                boxes.Add(box);

                input = Console.ReadLine().Split();
            }

            boxes = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (Box box in boxes)
            {
                Console.WriteLine($"{box.SerialNum} \n" +
                                  $"-- {box.Item.ItemName} - ${box.Item.ItemPrice:f2}: {box.ItemQuantity} \n" +
                                  $"-- ${box.BoxPrice:f2}");
            }

        }
    }

    class Item
    {
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }

    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public int SerialNum { get; set; }
        public Item Item { get; set; }
        public double ItemQuantity { get; set; }
        public double BoxPrice { get; set; }
    }
}
