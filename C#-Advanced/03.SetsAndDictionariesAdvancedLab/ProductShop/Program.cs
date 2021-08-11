using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productsByShops = new SortedDictionary<string, Dictionary<string, double>>();

            string line = Console.ReadLine();

            while (line != "Revision")
            {
                string[] productData = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = productData[0];
                string productName = productData[1];
                double productPrice = double.Parse(productData[2]);

                if (!productsByShops.ContainsKey(shopName))
                {
                    productsByShops.Add(shopName, new Dictionary<string, double>());
                }

                if (!productsByShops[shopName].ContainsKey(productName))
                {
                    productsByShops[shopName].Add(productName, productPrice);
                }

                line = Console.ReadLine();
            }

            foreach (var kvp in productsByShops)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var product in kvp.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
