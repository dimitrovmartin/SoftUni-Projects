using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> numbersByCount = new SortedDictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var number in numbers)
            {
                if (numbersByCount.ContainsKey(number))
                {
                    numbersByCount[number]++;
                }
                else
                {
                    numbersByCount.Add(number, 1);
                }
            }

            foreach (var kvp in numbersByCount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
