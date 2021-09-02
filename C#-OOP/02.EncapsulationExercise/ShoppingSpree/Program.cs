using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> personsByName = new Dictionary<string, Person>();
            Dictionary<string, Product> productsByName = new Dictionary<string, Product>();

            string[] personsData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var personData in personsData)
                {
                    string[] data = personData
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = data[0];
                    decimal money = decimal.Parse(data[1]);

                    Person person = new Person(name, money);

                    if (!personsByName.ContainsKey(name))
                    {
                        personsByName.Add(name, person);
                    }
                }

                foreach (var productData in productsData)
                {
                    string[] data = productData
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = data[0];
                    decimal cost = decimal.Parse(data[1]);

                    Product product = new Product(name, cost);

                    if (!productsByName.ContainsKey(name))
                    {
                        productsByName.Add(name, product);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                return;
            }

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] purchaseData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = purchaseData[0];
                string productName = purchaseData[1];

                if (personsByName.ContainsKey(personName) &&
                    productsByName.ContainsKey(productName))
                {
                    try
                    {
                        personsByName[personName].BuyProduct(productsByName[productName]);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, personsByName.Values));
        }
    }
}
