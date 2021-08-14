using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            ACollectionOfPokemon = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> ACollectionOfPokemon { get; set; }

        public override string ToString()
        {
            return $"{Name} {NumberOfBadges} {ACollectionOfPokemon.Count}";
        }
    }
}
