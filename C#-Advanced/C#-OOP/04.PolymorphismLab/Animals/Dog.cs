using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        private const string Sound = "DJAAF";

        public Dog(string name, string favoriteFood) : base(name, favoriteFood)
        {
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + $"{Sound}";
        }
    }
}
