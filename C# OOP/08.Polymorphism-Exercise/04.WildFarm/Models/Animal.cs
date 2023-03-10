using WildFarm.Models.Interfaces;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {

        protected Animal(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public int Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract void Eat();

        public abstract string ProducingSound();

    }
}
