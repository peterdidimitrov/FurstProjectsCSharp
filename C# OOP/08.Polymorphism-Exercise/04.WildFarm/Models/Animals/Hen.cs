using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() { typeof(Seeds), typeof(Meat), typeof(Vegetable), typeof(Fruit) }; 

        protected override double WeightMultiplyer => HenWeightMultiplier;

        public override string ProducingSound() => $"Cluck";
        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
