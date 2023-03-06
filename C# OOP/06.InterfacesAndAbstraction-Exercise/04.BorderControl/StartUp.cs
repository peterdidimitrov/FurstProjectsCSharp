using BorderControl.Core;
using BorderControl.Core.Interfaces;
using BorderControl.IO;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new EngineWithEndsWith(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}