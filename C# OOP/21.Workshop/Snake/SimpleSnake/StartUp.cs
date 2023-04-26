namespace SimpleSnake;

using Microsoft.Extensions.DependencyInjection;
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

        //var snake = serviceProvider.GetService<ISnake>();

        var engine = serviceProvider.GetService<IEngine>();
        engine.Run();
    }
}
