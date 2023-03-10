using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interfaces;

public interface IAnimalFactory
{
    IAnimal Create(string[] commandArguments);
}
