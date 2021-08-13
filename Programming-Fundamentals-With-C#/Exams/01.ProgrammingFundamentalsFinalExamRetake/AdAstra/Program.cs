using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Product
    {
        public Product(string name, string expirationDate, int calories)
        {
            Name = name;
            ExpirationDate = expirationDate;
            Calories = calories;
        }

        public string Name { get; set; }

        public string ExpirationDate { get; set; }

        public int Calories { get; set; }

        public override string ToString()
        {
            return $"Item: {Name}, Best before: {ExpirationDate}, Nutrition: {Calories}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int MinimalCalories = 2000;

            string text = Console.ReadLine();

            List<Product> products = new List<Product>();

            string pattern = @"(\||#)([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d+)\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                string productName = match.Groups[2].Value;
                string productExpirationDate = match.Groups[3].Value;
                int productCalories = int.Parse(match.Groups[4].Value);

                Product product = new Product(productName, productExpirationDate, productCalories);

                products.Add(product);
            }

            int totalCalories = products.Sum(p => p.Calories);

            int totalDaysInSpace = totalCalories / MinimalCalories;

            Console.WriteLine($"You have food to last you for: {totalDaysInSpace} days!");
            Console.WriteLine(string.Join(Environment.NewLine, products));
        }
    }
}
