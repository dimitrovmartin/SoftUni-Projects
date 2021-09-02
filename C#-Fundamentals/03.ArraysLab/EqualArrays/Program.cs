using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool areEqual = true;

            for (int i = 0; i < firstArr.Length; i++)
            {
                int n = firstArr[i];
                int m = secondArr[i];

                if (n != m)
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    areEqual = false;
                    break;
                }
            }

            if (areEqual)
            {
                int sum = firstArr.Sum();

                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
