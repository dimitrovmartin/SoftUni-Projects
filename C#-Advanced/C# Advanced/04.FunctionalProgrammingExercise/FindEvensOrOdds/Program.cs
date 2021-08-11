using System;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            string filter = Console.ReadLine();

            Predicate<int> predicate = GetPredicate(filter);

            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static Predicate<int> GetPredicate(string filter)
        {
            if (filter == "even")
            {
                return n => n % 2 == 0;
            }
            else
            {
                return n => n % 2 != 0;
            }
        }
    }
}
