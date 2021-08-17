using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double DefaultWeightModifier = 1;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, allowedFoods, DefaultWeightModifier, breed)
        {
        }

        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}
