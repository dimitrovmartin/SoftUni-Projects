using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> townsByPopulation = new Dictionary<string, int>();
            Dictionary<string, int> townsByGold = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "Sail")
            {
                string[] cityData = line
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string town = cityData[0];
                int people = int.Parse(cityData[1]);
                int gold = int.Parse(cityData[2]);

                if (townsByPopulation.ContainsKey(town))
                {
                    townsByPopulation[town] += people;
                    townsByGold[town] += gold;
                }
                else
                {
                    townsByPopulation.Add(town, people);
                    townsByGold.Add(town, gold);
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "End")
            {
                string[] commandData = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string town = commandData[1];

                if (townsByPopulation.ContainsKey(town))
                {
                    if (command == "Plunder")
                    {
                        int people = int.Parse(commandData[2]);
                        int gold = int.Parse(commandData[3]);

                        townsByPopulation[town] -= people;
                        townsByGold[town] -= gold;

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (townsByPopulation[town] == 0 || townsByGold[town] == 0)
                        {
                            townsByPopulation.Remove(town);
                            townsByGold.Remove(town);

                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                    }
                    else if (command == "Prosper")
                    {
                        int gold = int.Parse(commandData[2]);

                        if (gold <= 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            townsByGold[town] += gold;

                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {townsByGold[town]} gold.");
                        }
                    }
                }

                line = Console.ReadLine();
            }

            townsByGold = townsByGold
                .OrderByDescending(t => t.Value)
                .ThenBy(t => t.Key)
                .ToDictionary(t => t.Key, t => t.Value);

            if (townsByPopulation.Any())
            {
                Console.WriteLine($"Ahoy, Captain! There are {townsByPopulation.Count} wealthy settlements to go to:");

                foreach (var kvp in townsByGold)
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {townsByPopulation[kvp.Key]} citizens, Gold: {kvp.Value} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
