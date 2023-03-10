using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplyer => TigerWeightMultiplier;

        public override string ProducingSound() => $"ROAR!!!";
        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
