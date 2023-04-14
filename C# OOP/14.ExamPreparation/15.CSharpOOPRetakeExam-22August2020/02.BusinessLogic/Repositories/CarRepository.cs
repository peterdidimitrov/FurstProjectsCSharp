using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;
        public CarRepository()
        {
            models = new List<ICar>();
        }
        public void Add(ICar model) => models.Add(model);

        public IReadOnlyCollection<ICar> GetAll() => models.AsReadOnly();

        public ICar GetByName(string name) => models.FirstOrDefault(m => m.Model == name);

        public bool Remove(ICar model) => models.Remove(model);
    }
}
