using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> getEvenNumbers = arr =>
            {
                List<int> evenNumbers = new List<int>();

                foreach (var number in arr)
                {
                    if (number % 2 == 0)
                    {
                        evenNumbers.Add(number);
                    }
                }

                return evenNumbers.ToArray();
            };

            Func<int[], int[]> getOddNumbers = arr =>
            {
                List<int> oddNumbers = new List<int>();

                foreach (var number in arr)
                {
                    if (number % 2 != 0)
                    {
                        oddNumbers.Add(number);
                    }
                }

                return oddNumbers.ToArray();
            };

            int[] evenNumbers = getEvenNumbers(numbers)
                .OrderBy(n => n)
                .ToArray();

            int[] oddNumbers = getOddNumbers(numbers)
                .OrderBy(n => n)
                .ToArray();

            List<int> result = evenNumbers.ToList();

            result.AddRange(oddNumbers);

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
