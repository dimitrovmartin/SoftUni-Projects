using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            int[] filtersArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[]> generateArr = n =>
            {
                List<int> numbers = new List<int>();

                for (int i = 1; i <= n; i++)
                {
                    numbers.Add(i);
                }

                return numbers.ToArray();
            };
            int[] arr = generateArr(end);

            for (int i = 0; i < filtersArr.Length; i++)
            {
                int currentFilter = filtersArr[i];

                Func<int, bool> filterFunc = n => n % currentFilter == 0;

                arr = arr
                    .Where(filterFunc)
                    .ToArray();
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
