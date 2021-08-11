using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] clothesData = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = clothesData[0];
                string[] clothes = clothesData[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothesByColor.ContainsKey(color))
                {
                    clothesByColor.Add(color, new Dictionary<string, int>());
                }

                foreach (var dress in clothes)
                {
                    if (!clothesByColor[color].ContainsKey(dress))
                    {
                        clothesByColor[color].Add(dress, 0);
                    }

                    clothesByColor[color][dress]++;
                }
            }

            string[] searchedDressData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string searchedColor = searchedDressData[0];
            string searchedDress = searchedDressData[1];

            foreach (var kvp in clothesByColor)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var dress in kvp.Value)
                {
                    Console.Write($"* {dress.Key} - {dress.Value}");

                    if (kvp.Key == searchedColor && dress.Key == searchedDress)
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
