namespace WildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        int Weight { get; }
        int FoodEaten { get; }

        string ProducingSound();
        void Eat();
        string ToString();
    }
}
