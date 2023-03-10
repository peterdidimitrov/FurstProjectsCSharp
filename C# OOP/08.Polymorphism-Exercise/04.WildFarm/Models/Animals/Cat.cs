using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
        => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplyer => CatWeightMultiplier;

        public override string ProducingSound() => $"Meow";
        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
