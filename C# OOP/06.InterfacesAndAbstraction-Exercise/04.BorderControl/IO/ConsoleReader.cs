﻿using BorderControl.IO.Interfaces;

namespace BorderControl.IO;
public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}