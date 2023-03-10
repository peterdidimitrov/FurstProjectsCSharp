using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.Factories;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IAnimalFactory heroFactory = new AnimalFactory();

            IEngine engine = new Engine(reader, writer, heroFactory);

            engine.Run();
        }
    }
}