using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IHeroFactory heroFactory;

    private readonly ICollection<IAnimal> heroes;

    public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroFactory = heroFactory;

        heroes = new List<IAnimal>();
    }

    public void Run()
    {
        
    }
}