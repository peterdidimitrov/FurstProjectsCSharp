using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => models.AsReadOnly();

        public void Add(IPilot model) => models.Add(model);

        public IPilot FindByName(string name) => models.FirstOrDefault(c => c.FullName == (name));

        public bool Remove(IPilot model)
        {
            var removedPilot = models.FirstOrDefault(c => c == model);

            if (removedPilot == null)
            {
                return false;
            }
            models.Remove(removedPilot);

            return true;
        }
    }
}
