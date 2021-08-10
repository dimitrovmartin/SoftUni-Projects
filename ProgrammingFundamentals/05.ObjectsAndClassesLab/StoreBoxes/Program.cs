using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    public class Item
    {
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }
    }
    public class Box
    {
        public Box(string serialNumber, Item item, int itemQuantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
        }

        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public double PriceForBox => ItemQuantity * Item.Price;

        public override string ToString()
        {
            //-- { boxItemName} – ${ boxItemPrice}: { boxItemQuantity}
            //-- ${ boxPrice}

            return $"{SerialNumber}\n-- {Item.Name} - ${Item.Price:f2}: {ItemQuantity}\n-- ${PriceForBox:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] boxData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string serialNumber = boxData[0];
                string itemName = boxData[1];
                int quantity = int.Parse(boxData[2]);
                double price = double.Parse(boxData[3]);

                Item item = new Item(itemName, price);
                Box box = new Box(serialNumber, item, quantity);
                boxes.Add(box);

                line = Console.ReadLine();
            }

            boxes = boxes.OrderByDescending(b => b.PriceForBox).ToList();

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
