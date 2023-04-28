namespace SimpleSnake.Core;

using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects.Models;
using System;
using System.Threading;

public class Engine : IEngine
{
    private Wall wall;
    private Snake snake;
    private Direction direction;
    private decimal sleepTime;
    private readonly Point[] pointsOfDirection;
    public Engine(Wall wall, Snake snake)
    {
        this.wall = wall;
        this.snake = snake;

        sleepTime = 200;
        pointsOfDirection = new Point[4];
        Spead = 1;
    }
    public int Spead { get; set; }
    public void Run()
    {
        CreateDirections();
        while (true)
        {
            ShowScore();
            ShowSpead();
            if (Console.KeyAvailable)
            {
                GetNextDirection();
            }

            bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);

            if (!isMoving)
            {
                AskUserForRestart();
            }

            sleepTime -= 0.05m;
            if (sleepTime % 10 == 0)
            {
                Spead++;
            }
            Thread.Sleep((int)sleepTime);

        }
    }
    private void CreateDirections()
    {
        pointsOfDirection[0] = new Point(1, 0);
        pointsOfDirection[1] = new Point(-1, 0);
        pointsOfDirection[2] = new Point(0, 1);
        pointsOfDirection[3] = new Point(0, -1);
    }
    private void GetNextDirection()
    {
        ConsoleKeyInfo userInput = Console.ReadKey();

        if (userInput.Key == ConsoleKey.LeftArrow)
        {
            if (direction != Direction.Right)
            {
                direction = Direction.Left;
            }
        }
        else if (userInput.Key == ConsoleKey.RightArrow)
        {
            if (direction != Direction.Left)
            {
                direction = Direction.Right;
            }
        }
        else if (userInput.Key == ConsoleKey.DownArrow)
        {
            if (direction != Direction.Up)
            {
                direction = Direction.Down;
            }
        }
        else if (userInput.Key == ConsoleKey.UpArrow)
        {
            if (direction != Direction.Down)
            {
                direction = Direction.Up;
            }
        }
        Console.CursorVisible = false;
    }

    private void AskUserForRestart()
    {
        int leftX = wall.LeftX + 1;
        int topY = 3;

        Console.SetCursorPosition(leftX, topY);
        Console.Write("Would you like to contineu? y/n");

        string input = Console.ReadLine();
        if (input == "y")
        {
            Console.Clear();
            StartUp.Main();
        }
        else
        {
            StopGame();
        }
    }

    private void StopGame()
    {
        Console.SetCursorPosition(20, 10);
        Console.Write("Game over!");
        Environment.Exit(0);
    }
    private void ShowScore()
    {
        Console.SetCursorPosition(wall.LeftX + 1, 0);
        Console.Write($"Score: {snake.FoodEaten}");
        Console.CursorVisible = false;
    }
    private void ShowSpead()
    {
        Console.SetCursorPosition(wall.LeftX + 1, 1);
        Console.Write($"Spead: {Spead}");
        Console.CursorVisible = false;
    }
}
