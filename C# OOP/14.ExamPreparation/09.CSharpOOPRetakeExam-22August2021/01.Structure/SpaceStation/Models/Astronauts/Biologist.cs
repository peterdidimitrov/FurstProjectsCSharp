using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitialBiologistOxygen = 70;
        public Biologist(string name) 
            : base(name, InitialBiologistOxygen)
        {
        }
        public override void Breath()
        {
            Oxygen -= 5;
            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}
