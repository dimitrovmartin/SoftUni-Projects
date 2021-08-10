using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Demon
    {
        public Demon(string name, int health, double dmg)
        {
            Name = name;
            Health = health;
            Dmg = dmg;
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public double Dmg { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Dmg:F2} damage";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();

            string healthPattern = @"[0-9\+\-\*/\.]";
            string dmgPattern = @"[+-]?\d+\.?\d*";
            string operationsPattern = @"[*\/]";

            string[] names = Console.ReadLine()
                .Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            Regex healthRegex = new Regex(healthPattern);
            Regex dmgRegex = new Regex(dmgPattern);
            Regex operationsRegex = new Regex(operationsPattern);

            foreach (var name in names)
            {
                    int health = 0;
                    double dmg = 0;

                    string healthChars = Regex.Replace(name, healthPattern, string.Empty);
                    MatchCollection dmgMatches = dmgRegex.Matches(name);
                    MatchCollection operationsMatches = operationsRegex.Matches(name);

                    foreach (var character in healthChars)
                    {
                        health += character;
                    }

                    foreach (Match match in dmgMatches)
                    {
                        dmg += double.Parse(match.Value);
                    }

                    foreach (Match match in operationsMatches)
                    {
                        string sign = match.Value;

                        if (sign == "*")
                        {
                            dmg *= 2;
                        }
                        else
                        {
                            dmg /= 2;
                        }
                    }

                    Demon demon = new Demon(name, health, dmg);

                    demons.Add(demon);
            }

            demons = demons.OrderBy(d => d.Name).ToList();

            foreach (var demon in demons)
            {
                Console.WriteLine(demon);
            }
        }
    }
}
