using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories.Models
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public IReadOnlyCollection<IPlanet> Models => planets;

        public void AddItem(IPlanet model) => planets.Add(model);

        public IPlanet FindByName(string name) => planets.FirstOrDefault(p => p.GetType().Name == name);

        public bool RemoveItem(string name) => planets.Remove(planets.FirstOrDefault(p => p.GetType().Name == name));
    }
}
