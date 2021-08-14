using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;

            players = new List<Player>();
        }

        public string Name
        {
            get => name;

            private set
            {
                Validator.IsNullOrWhiteSpace(value);

                name = value;
            }
        }

        public double Rating => Math.Round(players.Average(p => p.Overall));

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.Any(p => p.Name == playerName))
            {
                Player player = players.First(p => p.Name == playerName);

                players.Remove(player);
            }
            else
            {
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");
            }
        }

        public override string ToString()
        {
            if (players.Count != 0)
            {
                return $"{Name} - {Rating}";
            }
            else
            {
                return $"{Name} - 0";
            }
        }
    }
}
