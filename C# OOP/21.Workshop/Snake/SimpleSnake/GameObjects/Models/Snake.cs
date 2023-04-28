namespace SimpleSnake.GameObjects.Models;

using System;
using System.Collections.Generic;
using System.Linq;

public class Snake
{
    private const char SnakeSymbol = '\u25CF';
    private const char EmptySpace = ' ';

    private readonly Wall wall;
    private readonly Queue<Point> snakeElements;
    private readonly List<Food> foods;

    private int foodIndex;
    private int nextLeftX;
    private int nextTopY;

    public Snake(Wall wall) 
    {
        this.wall = wall;
        snakeElements = new Queue<Point>();
        foods = new List<Food>();
        foodIndex = RandomFoodNumner;

        GetFoods();
        CreateFood();
        CreateSnake();
    }
    public int FoodEaten { get; set; }

    private int RandomFoodNumner => new Random().Next(0, foods.Count);
    private void CreateSnake()
    {
        for (int topY = 1; topY <= 6; topY++)
        {
            snakeElements.Enqueue(new Point(2, topY));
        }
    }
    private void GetFoods()
    {
        foods.Add(new FoodAsterisk(wall));
        foods.Add(new FoodDollar(wall));
        foods.Add(new FoodHash(wall));
    }
    private void GetNextPoint(Point direction, Point snakeHead)
    {
        nextLeftX = snakeHead.LeftX + direction.LeftX;
        nextTopY = snakeHead.TopY + direction.TopY;
    }
    public bool IsMoving(Point direction)
    {
        Point currentSnakeHead = snakeElements.Last();
        GetNextPoint(direction, currentSnakeHead);

        bool isPointOfSnake = snakeElements
            .Any(se => se.LeftX == nextLeftX && se.TopY == nextTopY);

        if (isPointOfSnake)
        {
            return false;
        }
        Point newSnakeNewHead = new Point(nextLeftX, nextTopY);

        if (wall.IsPointOfWall(newSnakeNewHead))
        {
            return false;
        }

        snakeElements.Enqueue(newSnakeNewHead);
        newSnakeNewHead.Draw(SnakeSymbol);

        if (foods[foodIndex].IsFoodPoint(newSnakeNewHead))
        {
            Eat(direction, currentSnakeHead);
        }

        Point snakeTail = snakeElements.Dequeue();
        snakeTail.Draw(EmptySpace);

        return true;
    }
    private void Eat(Point direction, Point currentSnakeHead)
    {
        int length = foods[foodIndex].FoodPoints;

        for (int i = 0; i < length; i++)
        {
            snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
            GetNextPoint(direction, currentSnakeHead);
        }

        FoodEaten += length;
        
        GetNextPoint(direction, currentSnakeHead);
        CreateFood();
    }
    private bool IsPointOfSnake 
        => snakeElements
        .Any(se => se.LeftX == nextLeftX && se.TopY == nextTopY);
    private void CreateFood()
    {
        foodIndex = RandomFoodNumner;
        foods[foodIndex].DrawFoodOnRandomPosition(snakeElements);
    }
}