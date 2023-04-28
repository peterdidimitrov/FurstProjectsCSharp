namespace SimpleSnake.GameObjects.Models;

using System;
using System.Collections.Generic;
using System.Linq;
public abstract class Food : Point
{
    private Wall wall;
    private char foodSymbol;
    private Random random;
    protected Food(Wall wall, char foodSymbol, int points)
        : base(wall.LeftX, wall.TopY)
    {
        this.wall = wall;
        this.foodSymbol = foodSymbol;
        FoodPoints = points;
        random = new Random();
    }

    public int FoodPoints { get; set; }

    public void DrawFoodOnRandomPosition(Queue<Point> snakeElements)
    {
        LeftX = random.Next(2, wall.LeftX - 2);
        TopY = random.Next(2, wall.TopY - 2);

        bool isPointOfSnake = snakeElements
            .Any(se => se.LeftX == LeftX && se.TopY == TopY);

        while (isPointOfSnake)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            isPointOfSnake = snakeElements
                .Any(se => se.LeftX == LeftX && se.TopY == TopY);
        }

        if (foodSymbol == '*')
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
        else if (foodSymbol == '$')
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
    public bool IsFoodPoint(Point snakeHead)
    {
        return snakeHead.TopY == TopY && snakeHead.LeftX == LeftX;
    }
}
