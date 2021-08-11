using System;
using System.Linq;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> citiesByContinentAndCountry = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cityInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = cityInfo[0];
                string country = cityInfo[1];
                string city = cityInfo[2];

                if (citiesByContinentAndCountry.ContainsKey(continent))
                {
                    if (citiesByContinentAndCountry[continent].ContainsKey(country))
                    {
                        citiesByContinentAndCountry[continent][country].Add(city);
                    }
                    else
                    {
                        citiesByContinentAndCountry[continent].Add(country, new List<string>());
                        citiesByContinentAndCountry[continent][country].Add(city);
                    }
                }
                else
                {
                    citiesByContinentAndCountry.Add(continent, new Dictionary<string, List<string>>());
                    citiesByContinentAndCountry[continent].Add(country, new List<string>());
                    citiesByContinentAndCountry[continent][country].Add(city);
                }
            }

            foreach (var kvp in citiesByContinentAndCountry)
            {
                string continent = kvp.Key;

                Console.WriteLine($"{continent}:");

                foreach (var country in kvp.Value)
                {
                    string countryName = country.Key;

                    Console.Write($"{countryName} -> {string.Join(", ", country.Value)}\n");
                }

            }
        }
    }
}
