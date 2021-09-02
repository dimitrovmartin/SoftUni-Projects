using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] ibirthableData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = ibirthableData[0];

                if (type == nameof(Citizen))
                {
                    string name = ibirthableData[1];
                    int age = int.Parse(ibirthableData[2]);
                    string id = ibirthableData[3];
                    string birthdate = ibirthableData[4];

                    IBirthable birthable = new Citizen(name, age, id, birthdate);

                    birthables.Add(birthable);
                }
                else if (type == nameof(Pet))
                {
                    string name = ibirthableData[1];
                    string birthdate = ibirthableData[2];

                    IBirthable birthable = new Pet(name, birthdate);

                    birthables.Add(birthable);
                }

                line = Console.ReadLine();
            }

            string filterYear = Console.ReadLine();

            foreach (var birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(filterYear))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
