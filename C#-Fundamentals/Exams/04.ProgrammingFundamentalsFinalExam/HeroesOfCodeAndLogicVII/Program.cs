using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> heroesByHP = new Dictionary<string, int>();
            Dictionary<string, int> heroesByMP = new Dictionary<string, int>();

            const int maxMana = 200;
            const int maxHealth = 100;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroData[0];
                int hp = int.Parse(heroData[1]);
                int mp = int.Parse(heroData[2]);

                if (!heroesByHP.ContainsKey(heroName))
                {
                    heroesByHP.Add(heroName, hp);
                    heroesByMP.Add(heroName, mp);
                }
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] commandData = line
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string heroName = commandData[1];

                if (heroesByHP.ContainsKey(heroName))
                {
                    if (command == "CastSpell")
                    {
                        int mpNeeded = int.Parse(commandData[2]);
                        string spellName = commandData[3];

                        if (heroesByMP[heroName] >= mpNeeded)
                        {
                            heroesByMP[heroName] -= mpNeeded;

                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroesByMP[heroName]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                    }
                    else if (command == "TakeDamage")
                    {
                        int damage = int.Parse(commandData[2]);
                        string attacker = commandData[3];

                        if (heroesByHP[heroName] > damage)
                        {
                            heroesByHP[heroName] -= damage;

                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroesByHP[heroName]} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");

                            heroesByHP.Remove(heroName);
                            heroesByMP.Remove(heroName);
                        }
                    }
                    else if (command == "Recharge")
                    {
                        int amount = int.Parse(commandData[2]);

                        if (heroesByMP[heroName] + amount > maxMana)
                        {
                            amount = maxMana - heroesByMP[heroName];
                        }

                        heroesByMP[heroName] += amount;

                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                    else if (command == "Heal")
                    {
                        int amount = int.Parse(commandData[2]);

                        if (heroesByHP[heroName] + amount > maxHealth)
                        {
                            amount = maxHealth - heroesByHP[heroName];
                        }

                        heroesByHP[heroName] += amount;

                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                }

                line = Console.ReadLine();
            }

            heroesByHP = heroesByHP
                .OrderByDescending(h => h.Value)
                .ThenBy(h => h.Key)
                .ToDictionary(h => h.Key, h => h.Value);

            foreach (var hero in heroesByHP)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value}");
                Console.WriteLine($"  MP: {heroesByMP[hero.Key]}");
            }
        }
    }
}
