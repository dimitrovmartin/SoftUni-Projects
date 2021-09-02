using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsByCount = new Dictionary<string, int>();

            using (StreamReader streamReader = new StreamReader("../../../words.txt"))
            {
                string[] words = streamReader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    wordsByCount.Add(word, 0);
                }
            }

            using (StreamReader streamReader = new StreamReader("../../../text.txt"))
            {
                string line = streamReader.ReadLine();

                while (line != null)
                {
                    string[] words = line
                    .Split(new char[] { '-', ',', '!', '.', '?', ' ' },StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        string wordToLower = word.ToLower();

                        if (wordsByCount.ContainsKey(wordToLower))
                        {
                            wordsByCount[wordToLower]++;
                        }
                    }

                    line = streamReader.ReadLine();
                }
            }

            wordsByCount = wordsByCount.OrderByDescending(k => k.Value)
                .ToDictionary(k => k.Key, k => k.Value);

            using (StreamWriter streamWriter = new StreamWriter("../../../Output.txt"))
            {
                foreach (var kvp in wordsByCount)
                {
                    streamWriter.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
