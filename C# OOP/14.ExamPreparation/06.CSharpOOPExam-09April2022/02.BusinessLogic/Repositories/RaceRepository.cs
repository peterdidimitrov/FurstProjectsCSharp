using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();

        public void Add(IRace model) => models.Add(model);

        public IRace FindByName(string name) => models.FirstOrDefault(c => c.RaceName == (name));

        public bool Remove(IRace model)
        {
            var removedRace = models.FirstOrDefault(c => c == model);

            if (removedRace == null)
            {
                return false;
            }
            models.Remove(removedRace);

            return true;
        }
    }
}
