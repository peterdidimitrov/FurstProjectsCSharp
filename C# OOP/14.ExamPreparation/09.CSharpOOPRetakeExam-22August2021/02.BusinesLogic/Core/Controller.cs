using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            }

            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IMission mission = new Mission();

            var planet = planets.FindByName(planetName);
            int deadAstrounauts = 0;
            var IsThereOneAstronautSuitableForTheMission = astronauts.Models.Any(a => a.Oxygen > 60);
            if (!IsThereOneAstronautSuitableForTheMission)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }

            List<IAstronaut> astronautsForTheMission = new List<IAstronaut>();

            foreach (var astronaut in astronauts.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    astronautsForTheMission.Add(astronaut);
                }
            }

            mission.Explore(planet, astronautsForTheMission);

            foreach (var astronaut in astronauts.Models)
            {
                if (astronaut.Oxygen == 0)
                {
                    deadAstrounauts++;
                }
            }

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstrounauts);
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
