using BirthdayCelebrations.Core;
using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}