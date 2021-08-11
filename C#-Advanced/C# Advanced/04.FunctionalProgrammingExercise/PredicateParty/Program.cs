using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string line = Console.ReadLine();

            while (line != "Party!")
            {
                string[] commandData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string condition = commandData[1];
                string filter = commandData[2];

                if (command == "Remove")
                {
                    if (condition == "StartsWith")
                    {
                        names = names
                            .Where(n => !n.StartsWith(filter))
                            .ToArray();
                    }
                    else if (condition == "EndsWith")
                    {
                        names = names
                            .Where(n => !n.EndsWith(filter))
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
                if (command == "Double")
                {
                    if (condition == "StartsWith")
                    {
                        string[] filteredNames = names
                            .Where(n => n.StartsWith(filter))
                            .ToArray();

                        names = FilterGuests(names, filteredNames);
                    }
                    else if (condition == "EndsWith")
                    {
                        string[] filteredNames = names
                            .Where(n => n.EndsWith(filter))
                            .ToArray();

                        names = FilterGuests(names, filteredNames);
                    }
                    else if (condition == "Length")
                    {
                        int filterToInt = int.Parse(filter);

                        string[] filteredNames = names
                            .Where(n => n.Length == filterToInt)
                            .ToArray();

                        names = FilterGuests(names, filteredNames);
                    }
                }

                line = Console.ReadLine();
            }

            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }


        private static string[] FilterGuests(string[] names, string[] filteredNames)
        {
            string currentName = string.Empty;

            foreach (var name in filteredNames)
            {
                if (currentName == name)
                {
                    continue;
                }

                int count = 0;

                currentName = name;

                for (int i = 0; i < names.Length; i++)
                {
                    if (name == names[i])
                    {
                        count++;
                    }
                }

                List<string> namesToList = names.ToList();

                int indexOfName = namesToList.IndexOf(name);

                for (int i = 0; i < count; i++)
                {
                    namesToList.Insert(indexOfName, name);
                }

                names = namesToList.ToArray();
            }

            return names;
        }
    }
}
