using Raiding.Models.Interfaces;

namespace Raiding.Factories.Interfaces;

public interface IHeroFactory
{
    IHero Create(string name, string type);
}
