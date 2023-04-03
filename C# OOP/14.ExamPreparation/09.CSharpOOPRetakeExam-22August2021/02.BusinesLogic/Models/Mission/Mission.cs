﻿using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Oxygen > 0)
                {
                    var item = planet.Items.First();
                    astronaut.Bag.Items.Add(item);
                    astronaut.Breath();
                    planet.Items.Remove(planet.Items.Last());
                }
            }
        }
    }
}
