using SquareRoots.IO.Interfaces;

namespace SquareRoots.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
