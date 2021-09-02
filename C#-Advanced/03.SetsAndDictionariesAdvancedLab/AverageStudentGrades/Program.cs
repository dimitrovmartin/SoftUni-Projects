using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> gradesByStudents = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentData[0];
                decimal studentGrade = decimal.Parse(studentData[1]);

                if (!gradesByStudents.ContainsKey(studentName))
                {
                    gradesByStudents.Add(studentName, new List<decimal>());
                }

                gradesByStudents[studentName].Add(studentGrade);
            }

            foreach (var kvp in gradesByStudents)
            {
                Console.Write($"{kvp.Key} -> ");

                foreach (var grade in kvp.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {kvp.Value.Average():F2})");
            }
        }
    }
}
