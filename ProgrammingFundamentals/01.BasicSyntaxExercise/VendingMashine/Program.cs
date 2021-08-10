using System;

namespace VendingMashine
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = 0;
            double price = 0;

            string line = Console.ReadLine();

            while (line != "Start")
            {
                double coin = double.Parse(line);

                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    money += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

                line = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts")
                {
                    price = 2;
                }
                else if (product == "Water")
                {
                    price = 0.7;
                }
                else if (product == "Crisps")
                {
                    price = 1.5;
                }
                else if (product == "Soda")
                {
                    price = 0.8;
                }
                else if (product == "Coke")
                {
                    price = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    product = Console.ReadLine();

                    continue;
                }

                if (money >= price)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");

                    money -= price;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
