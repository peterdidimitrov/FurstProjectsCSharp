using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories.Models
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;
        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => this.units;

        public void AddItem(IMilitaryUnit model) => this.units.Add(model);

        public IMilitaryUnit FindByName(string name) => units.FirstOrDefault(u => u.GetType().Name == name);

        public bool RemoveItem(string name) => units.Remove(units.FirstOrDefault(u => u.GetType().Name == name));
    }
}
