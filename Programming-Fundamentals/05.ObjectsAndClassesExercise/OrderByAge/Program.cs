using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] peopleData = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = peopleData[0];
                string id = peopleData[1];
                int age = int.Parse(peopleData[2]);

                Person person = new Person(name, id, age);

                people.Add(person);

                line = Console.ReadLine();
            }

            people = people.OrderBy(p => p.Age).ToList();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
