using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> numbersByCount = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numbersByCount.ContainsKey(number))
                {
                    numbersByCount.Add(number, 0);
                }

                numbersByCount[number]++;
            }

            foreach (var kvp in numbersByCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
