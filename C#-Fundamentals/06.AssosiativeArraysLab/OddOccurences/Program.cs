using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsByCounts = new Dictionary<string, int>();

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLower())
                .ToArray();

            foreach (var word in words)
            {
                if (wordsByCounts.ContainsKey(word))
                {
                    wordsByCounts[word]++;
                }
                else
                {
                    wordsByCounts.Add(word, 1);
                }
            }

            foreach (var kvp in wordsByCounts)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write(kvp.Key + " ");
                }
            }
        }
    }
}
