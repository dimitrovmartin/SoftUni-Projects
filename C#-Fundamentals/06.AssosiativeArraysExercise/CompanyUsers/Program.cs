using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> coursesByStudents = new Dictionary<string, SortedSet<string>>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] courseData = line
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string course = courseData[0];
                string name = courseData[1];

                if (!coursesByStudents.ContainsKey(course))
                {
                    coursesByStudents.Add(course, new SortedSet<string>());
                }

                coursesByStudents[course].Add(name);

                line = Console.ReadLine();
            }

            coursesByStudents = coursesByStudents
                .OrderByDescending(n => n.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in coursesByStudents)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (var name in kvp.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
