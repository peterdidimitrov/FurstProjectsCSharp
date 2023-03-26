using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Models
{
    public class NuclearWeapon : Weapon
    {
        private const double priceOfnuclearWeapon = 15;
        public NuclearWeapon(int destructionLevel)
            : base(priceOfnuclearWeapon, destructionLevel)
        {
        }
    }
}
