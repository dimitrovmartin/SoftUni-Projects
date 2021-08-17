using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double DefaultWeightModifier = 0.4;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion, allowedFoods, DefaultWeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return $"Woof!";
        }
    }
}
