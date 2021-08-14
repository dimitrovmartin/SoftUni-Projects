using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;

            products = new List<Product>();
        }

        public string Name
        {
            get => name;

            private set
            {
                Validator.IsNullOrWhiteSpace(value);

                name = value;
            }
        }

        public decimal Money
        {
            get => money;

            private set
            {
                Validator.IsNegativeNumber(value);

                money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > money)
            {
                throw new InvalidOperationException($"{Name} can't afford {product.Name}");
            }
            else
            {
                Money -= product.Cost;

                Console.WriteLine($"{Name} bought {product.Name}");

                products.Add(product);
            }
        }

        public override string ToString()
        {
            if (products.Count > 0)
            {
                return $"{Name} - {string.Join(", ", products)}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }
    }
}
