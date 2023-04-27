namespace SimpleSnake;

using Microsoft.Extensions.DependencyInjection;
using SimpleSnake.Core;
using SimpleSnake.Core.Contracts;
using SimpleSnake.GameObjects.Contracts;
using SimpleSnake.GameObjects.Models;
using SimpleSnake.IO;
using SimpleSnake.IO.Contracts;
using System;


public class ServiceConfigurator
{
    public static IServiceProvider ConfigureServices()
    {
        ServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IWriter<char>, ConsoleWriter>();
        serviceCollection.AddTransient<IPoint, Point>();
        serviceCollection.AddTransient<Wall>(w => new Wall(60, 20));
        serviceCollection.AddTransient<Snake, Snake>();

        serviceCollection.AddTransient<IEngine, Engine>();
        return serviceCollection.BuildServiceProvider();
    }
}
