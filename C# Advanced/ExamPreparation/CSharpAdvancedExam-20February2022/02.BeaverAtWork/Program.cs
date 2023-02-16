using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BeaverAtWork
{
    internal class Program
    {
        private static int beaverRow;
        private static int beaverCol;
        private static char[,] matrix;

        private static int numberOfBranches = 0;
        private static int allBranches = 0;

        private static string lastDirection;

        private static List<char> branches;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            matrix = ReadMatrix<char>(
                () => Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray(), rows, cols);

            //find Beaver's position
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "B")
                    {
                        beaverRow = row;
                        beaverCol = col;
                        break;
                    }
                }
            }
            //Console.WriteLine((int)char.Parse(matrix[0, 2]));
            //find allwood branches
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (((int)matrix[row, col] >= 97) && ((int)matrix[row, col] <= 122))
                    {
                        allBranches++;
                    }
                }
            }

            string direction = string.Empty;
            while ((direction = Console.ReadLine()) != "end")
            {
                lastDirection = direction;
                if (direction == "up")
                {
                    Move(-1, 0);
                }
                else if (direction == "down")
                {
                    Move(1, 0);
                }
                else if (direction == "left")
                {
                    Move(0, -1);
                }
                else if (direction == "right")
                {
                    Move(0, 1);
                }
                if (allBranches == numberOfBranches)
                {
                    Console.WriteLine($"The Beaver successfully collect {numberOfBranches} wood branches: {string.Join(", ", branches)}");
                    return;
                }
            }

            Console.WriteLine($"The Beaver failed to collect every wood branch. There are {allBranches - numberOfBranches} branches left.");

            PrintMatrix(matrix, e => Console.Write(e + " "));
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
        private static void Move(int row, int col)
        {
            if (!IsInside(beaverRow + row, beaverCol + col))
            {
                if (branches.Any())
                {
                    branches.Remove(branches[branches.Count - 1]);
                }
                return;
            }
            matrix[beaverRow, beaverCol] = '-';
            beaverRow += row;
            beaverCol += col;

            if (char.IsLower(matrix[beaverRow, beaverCol]))
            {
                branches.Add(matrix[beaverRow, beaverCol]);
                matrix[beaverRow, beaverCol] = 'B';
                totalBranches--;
            }
            else if (matrix[beaverRow, beaverCol] == 'F')
            {
                matrix[beaverRow, beaverCol] = '-';

                if (lastDirection == "up")
                {
                    if (beaverRow == 0)
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                        {
                            branches.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = matrix.GetLength(0) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branches.Add(matrix[0, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "down")
                {
                    if (beaverRow == matrix.GetLength(0) - 1)
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branches.Add(matrix[0, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                        {
                            branches.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = matrix.GetLength(0) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "right")
                {
                    if (beaverCol == matrix.GetLength(1) - 1)
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branches.Add(matrix[beaverRow, 0]);
                            totalBranches--;
                        }
                        beaverCol = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                        {
                            branches.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            totalBranches--;
                        }
                        beaverCol = matrix.GetLength(1) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "left")
                {
                    if (beaverCol == 0)
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                        {
                            branches.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            totalBranches--;
                        }
                        beaverCol = matrix.GetLength(1) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branches.Add(matrix[beaverRow, 0]);
                            totalBranches--;
                        }
                        beaverCol = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
            }
            else
            {
                matrix[beaverRow, beaverCol] = 'B';
            }
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}