using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s)[A-Za-z0-9]+(?:[-_.]*[A-Za-z0-9]+)?\@[A-Za-z0-9]+(?:[-]*[A-Za-z]+)?\.[A-Za-z]+(?:\.[A-Za-z]+)?";

            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
