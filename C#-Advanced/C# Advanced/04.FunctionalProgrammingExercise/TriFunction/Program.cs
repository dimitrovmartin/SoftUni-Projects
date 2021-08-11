using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Func<string, int, bool> filter = (s, n) =>
            {
                int asciiSum = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    asciiSum += s[i];
                }

                return asciiSum >= n;
            };

            string name = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .First(x => filter(x, n));

            Console.WriteLine(name);
        }
    }
}
