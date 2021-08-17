using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight, HashSet<string> allowedFoods, double weightModifier)
        {
            Name = name;
            Weight = weight;
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }

        private HashSet<string> AllowedFoods { get; set; }

        public double WeightModifier { get; private set; }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public virtual void Eat(Food food)
        {
            if (AllowedFoods.Contains(food.GetType().Name))
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * WeightModifier;
            }
            else
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
