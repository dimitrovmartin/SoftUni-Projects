using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int DefaultPower = 80;

        public Rogue(string name) : base(name, DefaultPower)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{nameof(Rogue)} - {Name} hit for {Power} damage");
        }
    }
}
