using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int equalPeopleCount = 0;
            int differentPeopleCount = 0;

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] personData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                Person person = new Person(name, age, town);

                people.Add(person);

                line = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < people.Count; i++)
            {
                if (i == n - 1)
                {
                    continue;
                }
                else
                {
                    try
                    {
                        if (people[n - 1].CompareTo(people[i]) == 0)
                        {
                            equalPeopleCount++;
                        }
                        else
                        {
                            differentPeopleCount++;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            if (equalPeopleCount == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeopleCount + 1} {differentPeopleCount} {people.Count}");
            }
        }
    }
}
