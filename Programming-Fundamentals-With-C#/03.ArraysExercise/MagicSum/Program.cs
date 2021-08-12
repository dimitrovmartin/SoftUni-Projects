using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int magicSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                    int firstNumber = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int secondNumber = numbers[j];

                    if (firstNumber + secondNumber == magicSum)
                    {
                        Console.WriteLine($"{firstNumber} {secondNumber}");
                    }
                }
            }
        }
    }
}
