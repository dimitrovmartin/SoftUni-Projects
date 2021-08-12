using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productByPrice = new Dictionary<string, decimal>();
            Dictionary<string, int> productByQuantity = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "buy")
            {
                string[] productData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string product = productData[0];
                decimal price = decimal.Parse(productData[1]);
                int quantity = int.Parse(productData[2]);

                if (productByPrice.ContainsKey(product))
                {
                    if (productByPrice[product] != price)
                    {
                        productByPrice[product] = price;
                    }
                }
                else
                {
                    productByPrice.Add(product, price);
                    productByQuantity.Add(product, 0);
                }

                productByQuantity[product] += quantity;

                line = Console.ReadLine();
            }

            foreach (var kvp in productByPrice)
            {
                string key = kvp.Key;
                decimal price = kvp.Value;
                int quantity = productByQuantity[key];

                decimal totalPrice = price * quantity;

                Console.WriteLine($"{key} -> {totalPrice:f2}");
            }
        }
    }
}
