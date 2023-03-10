using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }
        protected abstract double WeightMultiplyer { get; }
        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        public void Eat(IFood food)
        {
            if (!PreferredFoods.Any(pf => food.GetType().Name == pf.Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightMultiplyer;

            FoodEaten += food.Quantity;
        }

        public abstract string ProducingSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";
        }

    }
}
