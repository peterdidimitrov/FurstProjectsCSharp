using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Feline : Animal, IFeline, IMammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
            Breed = breed;
        }
        public string LivingRegion { get; private set; }

        public string Breed { get; private set; }

    }
}
