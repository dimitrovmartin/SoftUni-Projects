using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativeNumbers
{
    class Program
    {

        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Where(n => n >= 0)
                .Reverse()
                .ToList();

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
