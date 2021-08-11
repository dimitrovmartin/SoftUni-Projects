using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordByContest = new Dictionary<string, string>();

            SortedDictionary<string, Dictionary<string, int>> gradesByStudentsByCourse = new SortedDictionary<string, Dictionary<string, int>>();

            string line = Console.ReadLine();

            while (line != "end of contests")
            {
                string[] contestData = line
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = contestData[0];
                string password = contestData[1];

                if (!passwordByContest.ContainsKey(contest))
                {
                    passwordByContest.Add(contest, password);
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "end of submissions")
            {
                string[] studentData = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = studentData[0];
                string password = studentData[1];
                string studentName = studentData[2];
                int points = int.Parse(studentData[3]);
                
                if (passwordByContest.ContainsKey(contest) && passwordByContest[contest] == password)
                {
                    if (!gradesByStudentsByCourse.ContainsKey(studentName))
                    {
                        gradesByStudentsByCourse.Add(studentName, new Dictionary<string, int>());

                        gradesByStudentsByCourse[studentName].Add(contest, points);
                    }
                    else
                    {
                        if (!gradesByStudentsByCourse[studentName].ContainsKey(contest))
                        {
                            gradesByStudentsByCourse[studentName].Add(contest, points);
                        }
                        else if (gradesByStudentsByCourse[studentName][contest] <points)
                        {
                            gradesByStudentsByCourse[studentName][contest] = points;
                        }
                    }
                }

                line = Console.ReadLine();
            }

            KeyValuePair<string, Dictionary<string, int>> bestCandidate = gradesByStudentsByCourse
                .OrderByDescending(s => s.Value.Values.Sum()).First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");

            Console.WriteLine($"Ranking:");

            foreach (var student in gradesByStudentsByCourse)
            {
                Console.WriteLine($"{student.Key}");

                foreach (var contest in student.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
