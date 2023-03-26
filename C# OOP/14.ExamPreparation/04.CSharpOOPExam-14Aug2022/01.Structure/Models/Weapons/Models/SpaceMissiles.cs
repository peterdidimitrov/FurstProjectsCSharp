﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Models
{
    public class SpaceMissiles : Weapon
    {
        private const double priceOfspaceMissiles = 8.75;
        public SpaceMissiles(int destructionLevel) 
            : base(priceOfspaceMissiles, destructionLevel)
        {
        }
    }
}
