using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
                    => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightMultiplyer => MouseWeightMultiplier;

        public override string ProducingSound() => $"Squeak";
        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
