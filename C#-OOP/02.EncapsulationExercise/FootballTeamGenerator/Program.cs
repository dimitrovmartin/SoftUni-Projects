using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teamsByName = new Dictionary<string, Team>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] commandData = line
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string teamName = commandData[1];

                try
                {
                    if (command == "Team")
                    {
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Team team = new Team(teamName);

                            teamsByName.Add(teamName, team);
                        }
                    }
                    else if (command == "Add")
                    {
                        string playerName = commandData[2];

                        int endurance = int.Parse(commandData[3]);
                        int sprint = int.Parse(commandData[4]);
                        int dribble = int.Parse(commandData[5]);
                        int passing = int.Parse(commandData[6]);
                        int shooting = int.Parse(commandData[7]);

                        if (teamsByName.ContainsKey(teamName))
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                            teamsByName[teamName].AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (command == "Remove")
                    {
                        string playerName = commandData[2];

                        if (teamsByName.ContainsKey(teamName))
                        {
                            teamsByName[teamName].RemovePlayer(playerName);
                        }
                    }
                    else if (command == "Rating")
                    {
                        if (teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine(teamsByName[teamName]);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception ex)
                when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }
        }
    }
}
