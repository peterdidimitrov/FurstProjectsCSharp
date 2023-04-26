namespace SimpleSnake.IO;

using SimpleSnake.IO.Contracts;
using System;
public class ConsoleWriter : IWriter<char>
{
    public void Write(char symbol) => Console.Write(symbol);

    public void WriteLine(char symbol) => Console.WriteLine(symbol);
}
