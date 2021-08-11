using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> gradesByStudents = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                decimal grade = decimal.Parse(Console.ReadLine());

                if (!gradesByStudents.ContainsKey(name))
                {
                    gradesByStudents.Add(name, new List<decimal>());
                }

                gradesByStudents[name].Add(grade);
            }

            gradesByStudents = gradesByStudents
                .Where(s => s.Value.Average() >= 4.5m)
                .OrderByDescending(s => s.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in gradesByStudents)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
