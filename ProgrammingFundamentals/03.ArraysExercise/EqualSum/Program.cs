using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int leftSum = 0;
            int rightSum = numbers.Sum();

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];

                leftSum += number;

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                else
                {
                    rightSum -= number;
                }
            }

            Console.WriteLine($"no");
        }
    }
}
