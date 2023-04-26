namespace SimpleSnake.IO;

using SimpleSnake.IO.Contracts;
using System;
public class Reader : IReader
{
    public string ReadLine() => Console.ReadLine();
}
