namespace _6.JaggedArrayManipulator
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            decimal[][] jaggedArray = new decimal[rows][];

            ReadingJaggedArray(jaggedArray);

            MultiplyOrDevideElement(jaggedArray);

            ManipulateArray(jaggedArray);

            PrintingJaggedArray(jaggedArray);
        }

        private static void ManipulateArray(decimal[][] jaggedArray)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currCommand = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                long value = long.Parse(commandArgs[3]);

                if (currCommand == "Add")
                {
                    if (IsIndexesValid(row, col, jaggedArray) == true)
                    {
                        jaggedArray[row][col] += value;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currCommand == "Subtract")
                {
                    if (IsIndexesValid(row, col, jaggedArray) == true)
                    {
                        jaggedArray[row][col] -= value;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private static bool IsIndexesValid(int row, int col, decimal[][] jaggedArray)
        {
            return row >= 0 && row < jaggedArray.Length &&
                   col >= 0 && col < jaggedArray[row].Length;
        }

        private static void MultiplyOrDevideElement(decimal[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length && row != jaggedArray.Length - 1)
                {
                    for (int i = row; i <= row + 1; i++)
                    {
                        for (int col = 0; col < jaggedArray[i].Length; col++)
                        {
                            jaggedArray[i][col] *= 2;
                        }
                    }
                }
                else
                {
                    for (int i = row; i <= row + 1; i++)
                    {
                        for (int col = 0; col < jaggedArray[i].Length; col++)
                        {
                            jaggedArray[i][col] /= 2;
                        }
                    }
                }
            }
        }

        private static void PrintingJaggedArray(decimal[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");

                }
                Console.WriteLine();
            }
        }

        private static void ReadingJaggedArray(decimal[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                decimal[] integers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();

                jaggedArray[row] = new decimal[integers.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = integers[col];

                }
            }
        }

    }
}
