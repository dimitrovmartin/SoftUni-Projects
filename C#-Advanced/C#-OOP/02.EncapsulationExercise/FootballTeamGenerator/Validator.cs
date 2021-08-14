using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
   public static class Validator
    {
        public static void IsNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }

        public static void IsInRange(string statName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }
    }
}
