using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] teamData = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string creator = teamData[0];
                string teamName = teamData[1];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(t => t.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team team = new Team(teamName, creator);
                    teams.Add(team);

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string line = Console.ReadLine();

            while (line != "end of assignment")
            {
                string[] memberData = line.Split("->", StringSplitOptions.RemoveEmptyEntries);

                string memberName = memberData[0];
                string teamName = memberData[1];

                if (!teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(t => t.Members.Any(m => m == teamName)) || teams.Any(t=> t.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }
                else
                {
                    Team team = teams.Where(t => t.Name == teamName).FirstOrDefault();

                    team.Members.Add(memberName);
                }

                line = Console.ReadLine();
            }

            var filteredTeams = teams.OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).Where(t => t.Members.Count > 0).ToList();

            for (int i = 0; i < filteredTeams.Count; i++)
            {
                filteredTeams[i].Members.Sort();

                if (filteredTeams[i].Members.Count > 0)
                {
                    Console.WriteLine(filteredTeams[i].Name);
                    Console.WriteLine($"- {filteredTeams[i].Creator}");

                    foreach (var member in filteredTeams[i].Members)
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }

            var teamsToDisband = teams.Where(t => t.Members.Count == 0).OrderBy(t => t.Name).ToList();

            Console.WriteLine($"Teams to disband:");

            foreach (var team in teamsToDisband)
            {
                    Console.WriteLine(team.Name);
            }
        }
    }
}
