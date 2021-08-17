using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;

        public Warrior(string name) : base(name, DefaultPower)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{nameof(Warrior)} - {Name} hit for {Power} damage");
        }
    }
}
