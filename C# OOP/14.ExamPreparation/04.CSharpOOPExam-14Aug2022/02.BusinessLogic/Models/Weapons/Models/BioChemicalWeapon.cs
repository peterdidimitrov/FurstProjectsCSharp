﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Models
{
    public class BioChemicalWeapon : Weapon
    {
        private const double priceOfbioChemicalWeapon = 3.2;
        public BioChemicalWeapon(int destructionLevel) 
            : base(priceOfbioChemicalWeapon, destructionLevel)
        {
        }
    }
}
