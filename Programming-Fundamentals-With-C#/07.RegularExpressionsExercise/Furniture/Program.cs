using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-z]+)<<(\d+\.?\d*)!(\d+)";

            Regex regex = new Regex(pattern);

            decimal sum = 0;

            string line = Console.ReadLine();

            Console.WriteLine("Bought furniture:");

            while (line != "Purchase")
            {
                Match match = regex.Match(line);

                if (match.Success)
                {
                    string furniture = match.Groups[1].ToString();
                    decimal price = decimal.Parse(match.Groups[2].ToString());
                    decimal count = decimal.Parse(match.Groups[3].ToString());

                    sum += price * count;

                    Console.WriteLine(furniture);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
