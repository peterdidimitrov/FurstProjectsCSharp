using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> heroes)
        {
            var barbariansList = new List<IHero>();
            var knightsList = new List<IHero>();

            foreach (var hero in heroes)
            {
                if (hero is Barbarian)
                {
                    barbariansList.Add(hero);
                }
                else if (hero is Knight)
                {
                    knightsList.Add(hero);
                }
            }

            int deathKnights = 0;
            int deathBarbarians = 0;

            while (barbariansList.Any(b => b.IsAlive) && knightsList.Any(k => k.IsAlive))
            {
                // Knights attack
                foreach (var knight in knightsList)
                {
                    if (knight.IsAlive)
                    {
                        for (int i = 0; i < barbariansList.Count; i++)
                        {
                            var barbarian = barbariansList[i];
                            var damage = knight.Weapon.DoDamage();
                            barbarian.TakeDamage(damage);

                            if (!barbarian.IsAlive)
                            {
                                barbariansList.Remove(barbarian);
                                heroes.Remove(barbarian);
                                deathBarbarians++;
                                i--;
                            }
                        }
                    }
                }

                // Barbarians attack
                foreach (var barbarian in barbariansList)
                {
                    if (barbarian.IsAlive)
                    {
                        for (int i = 0; i < knightsList.Count; i++)
                        {
                            var knight = knightsList[i];
                            var damage = barbarian.Weapon.DoDamage();
                            knight.TakeDamage(damage);

                            if (!knight.IsAlive)
                            {
                                knightsList.Remove(knight);
                                heroes.Remove(knight);
                                deathKnights++;
                                i--;
                            }
                        }
                    }
                }
            }

            if (!barbariansList.Any())
            {
                return $"The knights took {deathKnights} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {deathBarbarians} casualties but won the battle.";
            }
        }

    }
}
