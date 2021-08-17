using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double DefaultWeightModifier = 0.1;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion, allowedFoods, DefaultWeightModifier)
        {
        }
        public override string ProduceSound()
        {
            return $"Squeak";
        }
    }
}
