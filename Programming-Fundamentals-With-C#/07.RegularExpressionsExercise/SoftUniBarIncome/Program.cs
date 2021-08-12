using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d*)\$";

            Regex regex = new Regex(pattern);

            double totalSum = 0;

            string line = Console.ReadLine();

            while (line != "end of shift")
            {
                Match match = regex.Match(line);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    double sum = price * quantity;

                    totalSum += sum;

                    Console.WriteLine($"{name}: {product} - {sum:F2}");
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
