using WildFarm.Models.Interfaces;

namespace WildFarm.Models
{
    public abstract class Feline : Animal, IMammal
    {
        protected Feline(string name, int weight, string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
