using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double DefaultWeightModifier = 0.35;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize, allowedFoods, DefaultWeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return $"Cluck";
        }
    }
}
