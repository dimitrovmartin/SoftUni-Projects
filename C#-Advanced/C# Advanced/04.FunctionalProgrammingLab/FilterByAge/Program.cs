using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionFilter = GetConditionFilter(condition, ageFilter);
            Action<Person> printFormat = GetPrintingFormat(format);

            people
                .Where(conditionFilter)
                .ToList()
                .ForEach(printFormat);
        }

        private static Action<Person> GetPrintingFormat(string format)
        {
            if (format == "name")
            {
                return p => Console.WriteLine($"{p.Name}");
            }
            else if (format == "age")
            {
                return p => Console.WriteLine($"{p.Age}");
            }
            else
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }

        private static Func<Person, bool> GetConditionFilter(string condition, int ageFilter)
        {
            if (condition == "older")
            {
                return p => p.Age >= ageFilter;
            }
            else
            {
                return p => p.Age < ageFilter;
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
