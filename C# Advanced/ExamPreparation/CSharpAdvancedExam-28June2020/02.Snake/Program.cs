using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Snake
{
    public class Program
    {
        private static int snakeRow;
        private static int snakeCol;
        private static char[,] matrix;
        private static int food = 0;

        private static int firstBurrowRow;
        private static int firstBurrowCol;
        private static int secondBurrowRow;
        private static int secondBurrowCol;

        private static bool isFirstBurrowFound = false;
        private static bool isOutside = false;

        private static int eatenFood = 0;

        static void Main(string[] args)
        {
            //create the matrix
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
            
            // finde food and burrow
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == '*')
                    {
                        food++;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        firstBurrowRow = row;
                        firstBurrowCol = col;
                        isFirstBurrowFound = true;
                    }
                    if (isFirstBurrowFound)
                    {
                        secondBurrowRow = row;
                        secondBurrowCol = col;
                    }
                }
            }

            //start receiving directions
            string command = string.Empty;

            while (eatenFood < 10 || eatenFood == food)
            {
                command = Console.ReadLine();

                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }

                if (isOutside)
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {eatenFood}");
                    PrintMatrix(n);
                    return;
                }
            }
            matrix[snakeRow, snakeCol] = 'S';
            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {eatenFood}");
            PrintMatrix(n);
        }

        private static void Move(int row, int col)
        {
            if (IsInside(snakeRow + row, snakeCol + col))
            {
                if (matrix[snakeRow + row, snakeCol + col] == '*')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    snakeRow += row;
                    snakeCol += col;
                    eatenFood++;
                    matrix[snakeRow, snakeCol] = '.';
                }
                else if (matrix[snakeRow + row, snakeCol + col] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    snakeRow += row;
                    snakeCol += col;
                    matrix[snakeRow, snakeCol] = '.';
                    if (firstBurrowRow == snakeRow && firstBurrowCol == snakeCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                    matrix[snakeRow, snakeCol] = '.';
                }
                else if (matrix[snakeRow + row, snakeCol + col] == '-')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    snakeRow += row;
                    snakeCol += col;
                    matrix[snakeRow, snakeCol] = 'S';
                }
            }
            else
            {
                matrix[snakeRow, snakeCol] = '.';
                isOutside = true;
            }
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void PrintMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
