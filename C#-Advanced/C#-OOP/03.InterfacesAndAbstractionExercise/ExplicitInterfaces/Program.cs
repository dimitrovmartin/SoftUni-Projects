using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] citizenInfo = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);

                Citizen citizen = new Citizen(name, country, age);

                citizens.Add(citizen);

                line = Console.ReadLine();
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(citizen.GetName());
            }
        }
    }
}
