using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinLength = 1;
        private const int MaxLength = 15;
        private const int MaxToppingsCount = 10;

        private List<Topping> toppings;
        private string name;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;

            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (value.Length < MinLength || value.Length > MaxLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinLength} and {MaxLength} symbols.");
                }
                else
                {
                    name = value;
                }
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == MaxToppingsCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            }
            else
            {
                toppings.Add(topping);
            }
        }

        public override string ToString()
        {
            return $"{Name} - {CalculateCalories():F2} Calories.";
        }

        public double CalculateCalories()
        {
            return this.dough.CalculateCalories() + this.toppings.Sum(t => t.CalculateCalories());
        }
    }
}
