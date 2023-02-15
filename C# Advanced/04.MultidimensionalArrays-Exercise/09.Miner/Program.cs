using System.Collections.Generic;

namespace _9.Miner
{
    public class Program
    {
        private static int minerRow;
        private static int minerCol;
        private static string[,] field;

        private static int countOfCoals = 0;


        private static bool isGameOver = false;
        static void Main(string[] args)
        {
            int totalCoals = 0;
            int size = int.Parse(Console.ReadLine());
            Queue<string> directions = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            int rows = size;
            int cols = size;

            field = ReadMatrix<string>(
                () => Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray(), rows, cols);

            //finde minsers position
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (field[row, col] == "s")
                    {
                        minerRow = row;
                        minerCol = col;
                        //Console.WriteLine($"field[{row}, {col}]");
                        break;
                    }
                }
            }

            //finde total count of coals
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (field[row, col] == "c")
                    {
                        totalCoals++;
                    }
                }
            }

            while (directions.Any())
            {
                if (directions.Peek() == "up")
                {
                    Move(-1, 0);
                }
                else if (directions.Peek() == "down")
                {
                    Move(1, 0);
                }
                else if (directions.Peek() == "left")
                {
                    Move(0, -1);
                }
                else if (directions.Peek() == "right")
                {
                    Move(0, 1);
                }

                if (isGameOver)
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                }

                directions.Dequeue();
            }

            if (!directions.Any() && !isGameOver && totalCoals - countOfCoals > 0)
            {
                Console.WriteLine($"{totalCoals - countOfCoals} coals left. ({minerRow}, {minerCol})");
            }
            else if (totalCoals - countOfCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }

            //PrintMatrix(field, e => Console.Write(e + " "));
            //Console.WriteLine(totalCoals);
        }
        static T[,] ReadMatrix<T>(Func<T[]> rowDataGetter, int rows, int cols)
        {
            T[,] matrix = new T[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                T[] rowData = rowDataGetter();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
        private static void Move(int row, int col)
        {
            if (IsInside(minerRow + row, minerCol + col))
            {
                if (field[minerRow + row, minerCol + col] == "e")
                {
                    field[minerRow, minerCol] = "*";
                    minerRow += row;
                    minerCol += col;
                    isGameOver = true;
                }
                else if (field[minerRow + row, minerCol + col] == "c")
                {
                    field[minerRow, minerCol] = "*";
                    minerRow += row;
                    minerCol += col;
                    field[minerRow, minerCol] = "*";
                    countOfCoals++;
                }
                else if (field[minerRow + row, minerCol + col] == "*")
                {
                    minerRow += row;
                    minerCol += col;
                }
            }

        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
        static void PrintMatrix<T>(T[,] matrix, Action<T> printer)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    printer(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}