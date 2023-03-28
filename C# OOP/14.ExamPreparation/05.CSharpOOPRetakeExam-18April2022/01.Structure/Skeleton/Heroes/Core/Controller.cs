using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons.Models;
using Heroes.Repositories.Contracts;
using Heroes.Repositories.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Map;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly WeaponRepository weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var wantedHero = heroes.Models.FirstOrDefault(h => h.Name == heroName);
            var wantedWeapon = weapons.Models.FirstOrDefault(w => w.Name == weaponName);

            if (wantedHero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (wantedWeapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (wantedHero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            wantedHero.AddWeapon(wantedWeapon);
            weapons.Remove(wantedWeapon);
            return $"Hero {heroName} can participate in battle using a {wantedWeapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type != nameof(Knight) && type != nameof(Barbarian))
            {
                throw new InvalidOperationException($"Invalid hero type.");
            }

            IHero hero;
            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Barbarian {name} to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.Models.Any(w => w.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type != nameof(Claymore) &&
                type != nameof(Mace))
            {
                throw new InvalidOperationException($"Invalid weapon type.");
            }

            IWeapon weapon;

            if (type == nameof(Claymore))
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                weapon = new Mace(name, durability);
            }

            weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon == null)
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
                else
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            var allHeroThatHasWeapons = heroes.Models.Where(h => h.Weapon != null && h.IsAlive).ToList();

            return map.Fight(allHeroThatHasWeapons);
        }
    }
}
