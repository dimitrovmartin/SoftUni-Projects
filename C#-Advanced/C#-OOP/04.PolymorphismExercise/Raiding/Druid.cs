using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int DefaultPower = 80; 

        public Druid(string name) : base(name, DefaultPower)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{nameof(Druid)} - {Name} healed for {Power}");
        }
    }
}
