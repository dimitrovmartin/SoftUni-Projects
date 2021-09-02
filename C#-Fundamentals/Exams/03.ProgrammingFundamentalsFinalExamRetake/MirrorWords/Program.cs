using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<string> mirrorWords = new List<string>();

            string pattern = @"(@|#)([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            if (matches.Count != 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            foreach (Match match in matches)
            {
                string firstWord = match.Groups[2].Value;
                string secondWord = match.Groups[3].Value;
                string reversedWord = string.Empty;

                StringBuilder sb = new StringBuilder();

                for (int i = firstWord.Length - 1; i >= 0; i--)
                {
                    sb.Append(firstWord[i]);
                }

                reversedWord = sb.ToString();

                if (reversedWord == secondWord)
                {
                    mirrorWords.Add($"{firstWord} <=> {secondWord}");
                }
            }

            if (mirrorWords.Count != 0)
            {
                Console.WriteLine($"The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
            else
            {
                Console.WriteLine($"No mirror words!");
            }
        }
    }
}
