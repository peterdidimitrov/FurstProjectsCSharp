using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Models
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double costOfAnonymousImpactUnit = 30;
        public AnonymousImpactUnit() : base(costOfAnonymousImpactUnit)
        {
        }
    }
}
