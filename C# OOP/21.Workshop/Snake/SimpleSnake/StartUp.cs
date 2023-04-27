namespace SimpleSnake;

using Microsoft.Extensions.DependencyInjection;
using SimpleSnake.Core;
using SimpleSnake.Core.Contracts;
using SimpleSnake.GameObjects.Models;
using System;
using Utilities;

public class StartUp
{
    public static void Main()
    {
        ConsoleWindow.CustomizeConsole();
        IServiceProvider serviceProvider = ServiceConfigurator.ConfigureServices();
        var wall = serviceProvider.GetService<Wall>();

        Snake snake = new Snake(wall);

        IEngine engine = new Engine(wall, snake);

        engine.Run();
    }
}
