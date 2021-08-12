using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> attackedPlanets = new SortedSet<string>();
            SortedSet<string> destroyedPlanets = new SortedSet<string>();

            int count = 0;
            string checker = "starSTAR";
            string pattern = @"[^\@\-!:>]*?\@([A-z]+)[^\@\-!:>]*:\d+!([AD])![^\@\-!:>]*->\d+[^\@\-!:>]*?";

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                count = GetCountOfStars(count, checker, text);
                text = EncryptText(count, text);

                Regex regex = new Regex(pattern);

                Match matches = regex.Match(text);

                if (matches.Success)
                {
                    string name = matches.Groups[1].Value;
                    string condition = matches.Groups[2].Value;

                    if (condition == "A")
                    {
                        attackedPlanets.Add(name);
                    }
                    else
                    {
                        destroyedPlanets.Add(name);
                    }
                }

                count = 0;
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            if (attackedPlanets.Count != 0)
            {
                foreach (var planet in attackedPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            if (destroyedPlanets.Count != 0)
            {
                foreach (var planet in destroyedPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }

        private static string EncryptText(int count, string text)
        {
            StringBuilder sb = new StringBuilder();

            for (int j = 0; j < text.Length; j++)
            {
                char decriptedChar = (char)(text[j] - count);

                sb.Append(decriptedChar.ToString());
            }

            text = sb.ToString();
            return text;
        }

        private static int GetCountOfStars(int count, string checker, string text)
        {
            foreach (var character in text)
            {
                if (checker.Contains(character))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
