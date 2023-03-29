using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();

        public void Add(IFormulaOneCar model) => models.Add(model);

        public IFormulaOneCar FindByName(string name) => models.FirstOrDefault(c => c.Model == (name));

        public bool Remove(IFormulaOneCar model)
        {
            var removedCar = models.FirstOrDefault(c => c == model);
            
            if (removedCar == null)
            {
                return false;
            }
            models.Remove(removedCar);
            
            return true;
        }
    }
}
