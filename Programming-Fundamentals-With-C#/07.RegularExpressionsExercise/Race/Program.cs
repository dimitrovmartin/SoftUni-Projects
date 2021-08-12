using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var name in names)
            {
                dictionary.Add(name, 0);
            }

            string namePattern = @"[\d\W]";
            string distancePattern = @"[A-z\W]";

            string line = Console.ReadLine();

            while (line != "end of race")
            {
                string name = Regex.Replace(line, namePattern, string.Empty);
                string distance = Regex.Replace(line, distancePattern, string.Empty);

                int sum = 0;

                foreach (var digit in distance)
                {
                    sum += int.Parse(digit.ToString());
                }

                if (dictionary.ContainsKey(name))
                {
                    dictionary[name] += sum;
                }

                line = Console.ReadLine();
            }

            dictionary = dictionary
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(x => x.Key, x => x.Value);

            int counter = 1;

            foreach (var person in dictionary)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {person.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {person.Key}");
                }
                else
                {
                    Console.WriteLine($"3rd place: {person.Key}");
                }

                counter++;
            }
        }
    }
}
