using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charsByCount = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var character in text)
            {
                if (!charsByCount.ContainsKey(character))
                {
                    charsByCount.Add(character, 0);
                }

                charsByCount[character]++;
            }

            foreach (var kvp in charsByCount)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
