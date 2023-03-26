using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Models
{
    public class StormTroopers : MilitaryUnit
    {
        private const double costOfStormTroopers = 2.5;
        public StormTroopers() : base(costOfStormTroopers)
        {
        }
    }
}
