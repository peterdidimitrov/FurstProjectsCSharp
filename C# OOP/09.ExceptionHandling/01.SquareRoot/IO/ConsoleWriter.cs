using SquareRoots.IO.Interfaces;

namespace SquareRoots.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}
