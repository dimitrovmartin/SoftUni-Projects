using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public static class Validator
    {
        public static void IsNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }

        public static void IsNegativeNumber(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}
