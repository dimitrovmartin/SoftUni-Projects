using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int DefaultCaloriesPerGram = 2;
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => type;

            private set
            {
                string valueToLower = value.ToLower();

                if (valueToLower != "meat" && valueToLower != "veggies" &&
                    valueToLower != "cheese" && valueToLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                else
                {
                    this.type = value;
                }
            }
        }

        public int Weight
        {
            get => weight;

            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                else
                {
                    weight = value;
                }
            }
        }

        public double CalculateCalories()
        {
            double typeModifier = GetTypeModifier();

            return DefaultCaloriesPerGram * Weight * typeModifier;
        }

        private double GetTypeModifier()
        {
            string typeToLower = Type.ToLower();

            if (typeToLower == "meat")
            {
                return 1.2;
            }
            else if (typeToLower == "veggies")
            {
                return 0.8;
            }
            else if (typeToLower == "cheese")
            {
                return 1.1;
            }
            else
            {
                return 0.9;
            }
        }
    }
}
