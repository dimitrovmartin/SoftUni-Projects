using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;

            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    name = value;
                }
            }
        }

        public IReadOnlyList<Person> FirstTeam => firstTeam;

        public IReadOnlyList<Person> ReserveTeam => reserveTeam;

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                firstTeam.Add(player);
            }
            else
            {
                reserveTeam.Add(player);
            }
        }
    }
}
