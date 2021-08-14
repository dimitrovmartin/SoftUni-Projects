using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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

        public int Endurance
        {
            get => endurance;

            private set
            {
                Validator.IsInRange("Endurance", value);

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;

            private set
            {
                Validator.IsInRange("Sprint", value);

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;

            private set
            {
                Validator.IsInRange("Dribble", value);

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;

            private set
            {
                Validator.IsInRange("Passing", value);

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;

            private set
            {
                Validator.IsInRange("Shooting", value);

                shooting = value;
            }
        }

        public double Overall => GetOverall();

        private double GetOverall()
        {
            return ((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);
        }
    }
}
