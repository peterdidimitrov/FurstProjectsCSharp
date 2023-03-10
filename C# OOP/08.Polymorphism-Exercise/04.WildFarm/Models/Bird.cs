using WildFarm.Models;
using WildFarm.Models.Interfaces;

namespace Raiding.Models
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, int weight) 
            : base(name, weight)
        {
        }

        public double WingSize { get ; private set; }
    }
}
