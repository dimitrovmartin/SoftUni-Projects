using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Plant
    {
        private List<double> ratings;

        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;

            ratings = new List<double>();
        }

        public string Name { get; set; }

        public int Rarity { get; set; }

        public double AverageRating
        {
            get
            {
                if (ratings.Count != 0)
                {
                    return ratings.Average();
                }
                else
                {
                    return 0;
                }
            }
        }

        public void Rate(double rating)
        {
            ratings.Add(rating);
        }

        public void Update(int newRarity)
        {
            Rarity = newRarity;
        }

        public void Reset()
        {
            ratings.Clear();
        }

        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {AverageRating:f2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plantsByNames = new Dictionary<string, Plant>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] plantData = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plantName = plantData[0];
                int rarity = int.Parse(plantData[1]);

                if (!plantsByNames.ContainsKey(plantName))
                {
                    Plant plant = new Plant(plantName, rarity);

                    plantsByNames.Add(plantName, plant);
                }
                else
                {
                    plantsByNames[plantName].Update(rarity);
                }
            }

            string line = Console.ReadLine();

            while (line != "Exhibition")
            {
                string[] commandData = line
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string[] plantData = commandData[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string plantName = plantData[0];

                if (plantsByNames.ContainsKey(plantName))
                {
                    if (command == "Rate")
                    {
                        double rating = double.Parse(plantData[1]);

                        plantsByNames[plantName].Rate(rating);
                    }
                    else if (command == "Update")
                    {
                        int newRarity = int.Parse(plantData[1]);

                        plantsByNames[plantName].Update(newRarity);
                    }
                    else if (command == "Reset")
                    {
                        plantsByNames[plantName].Reset();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }

                line = Console.ReadLine();
            }

            plantsByNames = plantsByNames
                .OrderByDescending(p => p.Value.Rarity)
                .ThenByDescending(p => p.Value.AverageRating)
                .ToDictionary(p => p.Key, p => p.Value);

            Console.WriteLine($"Plants for the exhibition:");
            Console.WriteLine(string.Join(Environment.NewLine, plantsByNames.Values));
        }
    }
}
