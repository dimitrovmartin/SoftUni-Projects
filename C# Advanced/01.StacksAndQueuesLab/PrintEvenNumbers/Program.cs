using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            while (queue.Any())
            {
                int currentNumber = queue.Dequeue();

                if (currentNumber % 2 == 0)
                {
                    if (queue.Any())
                    {
                        Console.Write(currentNumber + ", ");
                    }
                    else
                    {
                        Console.Write(currentNumber);
                    }
                }
            }
        }
    }
}
