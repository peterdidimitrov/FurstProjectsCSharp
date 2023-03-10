using WildFarm.Factories.Interfaces;
using WildFarm.Models;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories;

public class AnimalFactory : IAnimalFactory
{
    public IAnimal Create(string[] commandArguments)
    {
        string type = commandArguments[0];
        string name = commandArguments[1];
        double weight = double.Parse(commandArguments[2]);
        
        switch (type)
        {
            case "Owl":
                double wingSize = double.Parse(commandArguments[3]);
                return new Owl(name, weight, wingSize);
            case "Hen":
                wingSize = double.Parse(commandArguments[3]);
                return new Hen(name, weight, wingSize);
            case "Mouse":
                string livingRegion = commandArguments[3];
                return new Mouse(name, weight, livingRegion);
            case "Dog":
                livingRegion = commandArguments[3];
                return new Dog(name, weight, livingRegion);
            case "Cat":
                livingRegion = commandArguments[3];
                string breed = commandArguments[4];
                return new Cat(name, weight, livingRegion, breed);
            case "Tiger":
                livingRegion = commandArguments[3];
                breed = commandArguments[4];
                return new Tiger(name, weight, livingRegion, breed);
            default:
                throw new ArgumentException("Invalid animal!");
        }
    }
}
