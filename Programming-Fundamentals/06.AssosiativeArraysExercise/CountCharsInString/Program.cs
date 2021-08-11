using System;
using System.Collections.Generic;

namespace CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charsByCount = new Dictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var character in text)
            {
                if (!char.IsWhiteSpace(character))
                {
                    if (charsByCount.ContainsKey(character))
                    {
                        charsByCount[character]++;
                    }
                    else
                    {
                        charsByCount.Add(character, 1);
                    }
                }
            }

            foreach (var kvp in charsByCount)
            {
                char character = kvp.Key;
                int count = kvp.Value;

                Console.WriteLine($"{character} -> {count}");
            }
        }
    }
}
