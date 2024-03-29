﻿using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.Factories;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory heroFactory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, heroFactory);

            engine.Run();
        }
    }
}