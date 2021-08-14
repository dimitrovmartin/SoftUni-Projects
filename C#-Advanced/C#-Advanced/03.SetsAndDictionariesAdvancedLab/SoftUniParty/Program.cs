using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string line = Console.ReadLine();

            while (line != "PARTY")
            {
                guests.Add(line);

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "END")
            {
                guests.Remove(line);

                line = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            guests = guests.OrderByDescending(g => char.IsDigit(g[0]))
                .ToHashSet();

            Console.WriteLine(string.Join(Environment.NewLine,guests));
        }
    }
}
