using System;
using System.Linq;

namespace CondenseArraytoNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            while (numbers.Length != 1)
            {
                int[] condenced = new int[numbers.Length - 1];

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    int sum = numbers[i] + numbers[i + 1];

                    condenced[i] = sum;
                }

                numbers = condenced;
            }

            int total = numbers.Sum();

            Console.WriteLine(total);
        }
    }
}
