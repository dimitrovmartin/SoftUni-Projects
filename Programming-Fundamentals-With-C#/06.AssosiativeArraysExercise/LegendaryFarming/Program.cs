using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterialsByCount = new Dictionary<string, int>
            {
                {"shards", 0 },
                {"fragments", 0 },
                {"motes", 0 }
            };

            Dictionary<string, int> junksByCount = new Dictionary<string, int>();

            bool isObtained = false;

            while (!isObtained)
            {
                string[] input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < input.Length; i += 2)
                {
                    int count = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (keyMaterialsByCount.ContainsKey(material))
                    {
                        keyMaterialsByCount[material] += count;

                        if (keyMaterialsByCount[material] >= 250)
                        {
                            keyMaterialsByCount[material] -= 250;

                            string itemObtained = GetItem(material);

                            Console.WriteLine($"{itemObtained} obtained!");

                            isObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junksByCount.ContainsKey(material))
                        {
                            junksByCount[material] += count;
                        }
                        else
                        {
                            junksByCount.Add(material, count);
                        }
                    }
                }
            }

            keyMaterialsByCount = keyMaterialsByCount
                .OrderByDescending(k => k.Value)
                .ThenBy(k => k.Key)
                .ToDictionary(k => k.Key, k => k.Value);

            junksByCount = junksByCount
                .OrderBy(j => j.Key)
                .ToDictionary(j => j.Key, j => j.Value);

            foreach (var kvp in keyMaterialsByCount)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }

            foreach (var kvp in junksByCount)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }
        }

        private static string GetItem(string material)
        {
            if (material == "shards")
            {
                return "Shadowmourne";
            }
            else if (material == "fragments")
            {
                return "Valanyr";
            }
            else if (material == "motes")
            {
                return "Dragonwrath";
            }

            return null;
        }
    }
}
