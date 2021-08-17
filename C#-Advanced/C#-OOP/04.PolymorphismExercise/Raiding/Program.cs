using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    BaseHero hero = CreateHero();

                    heroes.Add(hero);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    i -= 1;
                }
            }

            int bossHealth = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                bossHealth -= hero.Power;
                hero.CastAbility();
            }

            if (bossHealth <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine($"Defeat...");
            }
        }

        private static BaseHero CreateHero()
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();

            if (type == nameof(Druid))
            {
                return new Druid(name);
            }
            else if (type == nameof(Paladin))
            {
                return new Paladin(name);
            }
            else if (type == nameof(Rogue))
            {
                return new Rogue(name);
            }
            else if (type == nameof(Warrior))
            {
                return new Warrior(name);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero!");
            }
        }
    }
}
