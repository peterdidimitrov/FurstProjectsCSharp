using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.4;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplyer => DogWeightMultiplier;

        public override string ProducingSound() => $"Woof!";
        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
