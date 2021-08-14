using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"(\*|@)([A-Z][a-z]{2,})\1:\s\[([A-Za-z])]\|\[([[A-Za-z])]\|\[([[A-Za-z])]\|$";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match match = regex.Match(message);

                if (match.Success)
                {
                    string tag = match.Groups[2].Value;

                    char firstLetter = char.Parse(match.Groups[3].Value);
                    char secondLetter = char.Parse(match.Groups[4].Value);
                    char thirdLetter = char.Parse(match.Groups[5].Value);

                    int firstASCII = (int)firstLetter;
                    int secondASCII = (int)secondLetter;
                    int thirdASCII = (int)thirdLetter;

                    Console.WriteLine($"{tag}: {firstASCII} {secondASCII} {thirdASCII}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
