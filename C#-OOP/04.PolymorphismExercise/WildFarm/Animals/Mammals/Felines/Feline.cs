using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
         protected Feline(string name, double weight, string livingRegion, HashSet<string> allowedFoods, double weightModifier, string breed) : base(name, weight, livingRegion, allowedFoods, weightModifier)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
