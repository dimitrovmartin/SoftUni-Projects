using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] counters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = counters[0];
            int m = counters[1];

            int counter = n + m;

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < counter; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }
            }

            int[] commonElements = firstSet.Intersect(secondSet).ToArray();

            Console.WriteLine(string.Join(" ", commonElements));
        }
    }
}
