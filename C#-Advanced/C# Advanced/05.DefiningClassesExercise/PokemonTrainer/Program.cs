using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string line = Console.ReadLine();

            while (line != "Tournament")
            {
                string[] trainerData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = trainerData[0];
                string pokemonName = trainerData[1];
                string pokemonElement = trainerData[2];
                int pokemonHealth = int.Parse(trainerData[3]);

                if (trainers.Any(t => t.Name == name))
                {
                    Trainer trainer = trainers.First(t => t.Name == name);

                    trainer.ACollectionOfPokemon.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
                else
                {
                    Trainer trainer = new Trainer(name);

                    trainers.Add(trainer);

                    trainer.ACollectionOfPokemon.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.ACollectionOfPokemon.Any(p => p.Element == line))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.ACollectionOfPokemon)
                        {
                            pokemon.Health -= 10;
                        }

                        if (trainer.ACollectionOfPokemon.Any(p => (p.Health <= 0)))
                        {
                            Pokemon deadPokemon = trainer.ACollectionOfPokemon.First(p => p.Health <= 0);

                            trainer.ACollectionOfPokemon.Remove(deadPokemon);
                        }
                    }
                }

                line = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(t => t.NumberOfBadges).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
