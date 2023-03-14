using SquareRoots.Core;
using SquareRoots.Core.Interfaces;
using SquareRoots.Factories;
using SquareRoots.Factories.Interfaces;
using SquareRoots.IO;
using SquareRoots.IO.Interfaces;

namespace SquareRoots
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ISquqreRootFactory squareFactory = new SquareRoodFactory();

            IEngine engine = new Engine(reader, writer, squareFactory);

            engine.Run();
        }
    }
}