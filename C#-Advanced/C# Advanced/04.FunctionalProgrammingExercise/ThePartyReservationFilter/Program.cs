using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> filters = new List<string>();

            string line = Console.ReadLine();

            while (line != "Print")
            {
                string[] commandData = line
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string filter = string.Join(";", commandData.Skip(1));

                if (command == "Add filter")
                {
                    filters.Add(filter);
                }
                else
                {
                    filters.Remove(filter);
                }

                line = Console.ReadLine();
            }

            foreach (var filterData in filters)
            {
                string[] filterParts = filterData
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string condition = filterParts[0];
                string filter = filterParts[1];

                if (condition == "Starts with")
                {
                    names = names
                        .Where(n => !n.StartsWith(filter))
                        .ToArray();
                }
                else if (condition == "Ends with")
                {
                    names = names
                        .Where(n => !n.EndsWith(filter))
                        .ToArray();
                }
                else if (condition == "Contains")
                {
                    names = names
                         .Where(n => !n.Contains(filter))
                         .ToArray();
                }
                else if (condition == "Length")
                {
                    int filterToInt = int.Parse(filter);

                    names = names
                       .Where(n => n.Length != filterToInt)
                       .ToArray();
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
