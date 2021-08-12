using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<string> coolEmojis = new List<string>();

            long coolThreshold = 1;

            string emojiPattern = @"(\*\*|::)([A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";

            Regex emojiRegex = new Regex(emojiPattern);
            Regex digitsRegex = new Regex(digitsPattern);

            MatchCollection emojiMatches = emojiRegex.Matches(text);
            MatchCollection digitsMatches = digitsRegex.Matches(text);

            foreach (Match match in digitsMatches)
            {
                coolThreshold *= long.Parse(match.Value);
            }

            foreach (Match match in emojiMatches)
            {
                long emojiCoolness = 0;

                string emoji = match.Groups[2].Value;

                foreach (var character in emoji)
                {
                    emojiCoolness += character;
                }

                if (emojiCoolness > coolThreshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");

            if (coolEmojis.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, coolEmojis));
            }
        }
    }
}
