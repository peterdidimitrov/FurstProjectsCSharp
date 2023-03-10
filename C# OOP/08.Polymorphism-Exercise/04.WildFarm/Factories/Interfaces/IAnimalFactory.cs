using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interfaces;

public interface IHeroFactory
{
    IAnimal Create(string name, string type);
}
