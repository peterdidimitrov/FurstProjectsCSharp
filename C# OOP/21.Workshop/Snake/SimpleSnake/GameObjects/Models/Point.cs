namespace SimpleSnake.GameObjects.Models;

using Microsoft.Extensions.DependencyInjection;
using SimpleSnake.GameObjects.Contracts;
using SimpleSnake.IO.Contracts;
using System;
public class Point : IPoint
{
    private int leftX;
    private int topY;
    private IServiceProvider serviceProvider;
    private IWriter<char> writer;
    public Point(int leftX, int topY)
    {
        LeftX = leftX;
        TopY = topY;
        serviceProvider = ServiceConfigurator.ConfigureServices();
        writer = serviceProvider.GetService<IWriter<char>>();
    }
    public int LeftX
    {
        get { return leftX; }
        protected set { leftX = value; }
    }

    public int TopY
    {
        get { return topY; }
        protected set { topY = value; }
    }

    public void Draw(char symbol)
    {
        Console.SetCursorPosition(LeftX, TopY);
        writer.Write(symbol);

    }

    public void Draw(int leftX, int topY, char symbol)
    {
        Console.SetCursorPosition(leftX, topY);
        writer.Write(symbol);
    }
}
