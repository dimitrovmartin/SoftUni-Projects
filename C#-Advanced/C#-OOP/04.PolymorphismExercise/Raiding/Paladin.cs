using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int DefaultPower = 100;

        public Paladin(string name) : base(name, DefaultPower)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{nameof(Paladin)} - {Name} healed for {Power}");
        }
    }
}
