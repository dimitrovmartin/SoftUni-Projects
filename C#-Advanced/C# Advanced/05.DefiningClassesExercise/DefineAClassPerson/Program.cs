using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            people = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}
