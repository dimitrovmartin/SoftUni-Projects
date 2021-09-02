using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int DefaultCaloriesPerGram = 2;
        private const string InvalidDoughMessage = "Invalid type of dough.";
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string backingTechnique;
        private int weight;

        public Dough(string flourType, string backingTechnique, int weight)
        {
            FlourType = flourType;
            BackingTechnique = backingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;

            private set
            {
                string valueToLower = value.ToLower();

                if (valueToLower != "white" &&
                    valueToLower != "wholegrain")
                {
                    throw new ArgumentException(InvalidDoughMessage);
                }
                else
                {
                    this.flourType = value;
                }
            }
        }

        public string BackingTechnique
        {
            get => backingTechnique;

            private set
            {
                string valueToLower = value.ToLower();

                if (valueToLower != "crispy" &&
                    valueToLower != "chewy" &&
                    valueToLower != "homemade")
                {
                    throw new ArgumentException(InvalidDoughMessage);
                }
                else
                {
                    this.backingTechnique = value;
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
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                else
                {
                    weight = value;
                }
            }
        }

        public double CalculateCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier();
            double backingTechniqueModifier = GetBackingTechniqueModifier();

            return DefaultCaloriesPerGram * Weight * flourTypeModifier * backingTechniqueModifier;
        }

        private double GetBackingTechniqueModifier()
        {
            string backingTechniqueToLower = BackingTechnique.ToLower();

            if (backingTechniqueToLower == "crispy")
            {
                return 0.9;
            }
            else if (backingTechniqueToLower == "chewy")
            {
                return 1.1;
            }
            else
            {
                return 1;
            }
        }

        private double GetFlourTypeModifier()
        {
            string flourTypeToLower = FlourType.ToLower();

            if (flourTypeToLower == "white")
            {
                return 1.5;
            }
            else
            {
                return 1;
            }
        }
    }
}
