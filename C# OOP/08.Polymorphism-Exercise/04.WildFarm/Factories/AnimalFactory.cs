using WildFarm.Factories.Interfaces;
using WildFarm.Models;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories;

public class AnimalFactory : IHeroFactory
{
    public IAnimal Create(string name, string type)
    {
        switch (type)
        {
            case "Druid":
                return new Mammal(name);
            case "Paladin":
                return new Paladin(name);
            case "Rogue":
                return new Rogue(name);
            case "Warrior":
                return new Warrior(name);
            default:
                throw new ArgumentException("Invalid hero!");
        }
    }
}
