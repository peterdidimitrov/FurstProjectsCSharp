using WildFarm.Models.Interfaces;

namespace WildFarm.Models
{
    public abstract class Feline : Animal, IFeline, IMammal
    {
        protected Feline(string name, int weight, string livingRegion, string breed)
            : base(name, weight)
        {
            Breed = breed;
        }
        public string LivingRegion { get; private set; }

        public string Breed { get; private set; }

    }
}
