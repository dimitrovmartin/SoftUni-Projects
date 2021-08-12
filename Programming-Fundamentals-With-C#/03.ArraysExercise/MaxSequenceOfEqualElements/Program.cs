using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxCount = 0;
            int maxNum = 0;
            int counter = 1;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int firstNumber = numbers[i];
                int secondNumber = numbers[i + 1];

                if (firstNumber == secondNumber)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > maxCount)
                {
                    maxCount = counter;
                    maxNum = firstNumber;
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write($"{maxNum} ");
            }
        }
    }
}
