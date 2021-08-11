using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            int[] intNumbers = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0 || numbers[i] == -0)
                {
                    numbers[i] = 0;
                }

                double number = Math.Round(numbers[i], MidpointRounding.AwayFromZero);

                intNumbers[i] = (int)number;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} => {intNumbers[i]}");
            }
        }
    }
}
