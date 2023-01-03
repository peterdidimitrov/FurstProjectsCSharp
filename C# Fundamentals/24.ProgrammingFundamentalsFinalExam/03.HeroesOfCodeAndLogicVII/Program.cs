using System;
using System.Collections.Generic;

namespace _03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var heroHealth = new Dictionary<string, int>();
            var heroMana = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroInfo[0];
                int health = int.Parse(heroInfo[1]);
                int mana = int.Parse(heroInfo[2]);

                heroHealth[heroName] = health;
                heroMana[heroName] = mana;
            }
            string commandInfo;
            while ((commandInfo = Console.ReadLine()) != "End")
            {
                string[] commArg = commandInfo.
                    Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = commArg[0];
                string name = commArg[1];

                if (command == "CastSpell")
                {
                    int neededMP = int.Parse(commArg[2]);
                    string spellName = commArg[3];
                    if (heroMana[name] >= neededMP)
                    {
                        heroMana[name] -= neededMP;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroMana[name]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(commArg[2]);
                    string attacker = commArg[3];
                    heroHealth[name] -= damage;
                    if (heroHealth[name] > 0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroHealth[name]} HP left!");
                    }
                    else
                    {
                        heroHealth.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }
                }
                else if (command == "Recharge")
                {
                    int amountOfRecharge = int.Parse(commArg[2]);
                    int totalRecharge = amountOfRecharge + heroMana[name];
                    int amountBeforRecharge = heroMana[name];
                    if (totalRecharge > 200)
                    {
                        amountOfRecharge = 200 - heroMana[name];
                    }
                    heroMana[name] += amountOfRecharge;
                    Console.WriteLine($"{name} recharged for {amountOfRecharge} MP!");
                }
                else if (command == "Heal")
                {
                    int amountOfHeal = int.Parse(commArg[2]);
                    int totalHeal = amountOfHeal + heroHealth[name];
                    int amountBeforRecharge = heroHealth[name];
                    if (totalHeal > 100)
                    {
                        amountOfHeal = 100 - heroHealth[name];
                    }
                    heroHealth[name] += amountOfHeal;
                    Console.WriteLine($"{name} healed for {amountOfHeal} HP!");
                }
            }
            foreach (var hero in heroHealth)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value}");
                Console.WriteLine($"  MP: {heroMana[hero.Key]}");
            }
        }
    }
}