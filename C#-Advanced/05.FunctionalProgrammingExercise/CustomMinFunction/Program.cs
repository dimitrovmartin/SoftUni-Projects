using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> GetMin = arr =>
            {
                int minNumber = int.MaxValue;

                foreach (var number in arr)
                {
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }

                return minNumber;
            };

            int minNumber = GetMin(numbers);

            Console.WriteLine(minNumber);
        }
    }
}
