using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> add = n => n += 1; 
            Func<int, int> multiply = n => n *= 2; 
            Func<int, int> subtract = n => n -= 1;
            Action<int[]> print = arr => Console.WriteLine(string.Join(" ", arr));

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string line = Console.ReadLine();

            while (line != "end")
            {
                if (line == "add")
                {
                    numbers = numbers.Select(add).ToArray();
                }
                else if (line == "multiply")
                {
                    numbers = numbers.Select(multiply).ToArray();
                }
                else if (line == "subtract")
                {
                    numbers = numbers.Select(subtract).ToArray();
                }
                else if (line == "print")
                {
                    print(numbers);
                }

                line = Console.ReadLine();
            }
        }
    }
}
