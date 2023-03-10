using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplyer => OwlWeightMultiplier;

        public override string ProducingSound() => $"Hoot Hoot";
        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
