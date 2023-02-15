using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TruffleHunter
{
    internal class Program
    {
        private static int boarRow;
        private static int boarCol;
        private static string[,] forest;

        private static int countOfBlackTruffles = 0;
        private static int countOfWhiteTruffles = 0;
        private static int countOfSummerTruffles = 0;

        private static int countOfTrufflesBoar = 0;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            forest = ReadMatrix<string>(
                () => Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray(), rows, cols);

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "Stop the hunt")
            {
                string[] commArg = commands.Split(' ');

                string command = commArg[0];

                int row = int.Parse(commArg[1]);
                int col = int.Parse(commArg[2]);

                if (command == "Collect")
                {
                    Collect(row, col);
                }
                else
                {
                    string direction = commArg[3];
                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (forest[i, col] == "B")
                            {
                                countOfTrufflesBoar++;
                            }
                            else if (forest[i, col] == "S")
                            {
                                countOfTrufflesBoar++;
                            }
                            else if (forest[i, col] == "W")
                            {
                                countOfTrufflesBoar++;
                            }

                            forest[i, col] = "-";
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < size; i += 2)
                        {
                            if (forest[i, col] == "B")
                            {
                                countOfTrufflesBoar++;
                            }
                            else if (forest[i, col] == "S")
                            {
                                countOfTrufflesBoar++;
                            }
                            else if (forest[i, col] == "W")
                            {
                                countOfTrufflesBoar++;
                            }

                            forest[i, col] = "-";
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                        {
                            if (forest[row, i] == "B")
                            {
                                countOfTrufflesBoar++;
                            }
                            else if (forest[row, i] == "S")
                            {
                                countOfTrufflesBoar++;
                            }
                            else if (forest[row, i] == "W")
                            {
                                countOfTrufflesBoar++;
                            }

                            forest[row, i] = "-";
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < size; i += 2)
                        {
                            if (forest[row, i] == "B")
                            {
                                countOfTrufflesBoar++;
                            }
                            else if (forest[row, i] == "S")
                            {
                                countOfTrufflesBoar++;
                            }
                            else if (forest[row, i] == "W")
                            {
                                countOfTrufflesBoar++;
                            }

                            forest[row, i] = "-";
                        }
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {countOfBlackTruffles} " +
                $"black, {countOfSummerTruffles} summer, and {countOfWhiteTruffles}" +
                $" white truffles.");
            Console.WriteLine($"The wild boar has eaten {countOfTrufflesBoar} truffles.");

            PrintMatrix(forest, e => Console.Write(e + " "));
        }

        private static void Collect(int row, int col)
        {
            if (IsInside(row, col))
            {
                if (forest[row, col] == "B")
                {
                    countOfBlackTruffles++;
                }
                else if (forest[row, col] == "S")
                {
                    countOfSummerTruffles++;
                }
                else if (forest[row, col] == "W")
                {
                    countOfWhiteTruffles++;
                }

                forest[row, col] = "-";
            }
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
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < forest.GetLength(0) && col >= 0 && col < forest.GetLength(1);
        }
    }
}
