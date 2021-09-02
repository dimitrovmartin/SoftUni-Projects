using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<string> destinations = new List<string>();

            int travelPoints = 0;

            string pattern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                string destination = match.Groups[2].Value;

                destinations.Add(destination);

                travelPoints += destination.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
