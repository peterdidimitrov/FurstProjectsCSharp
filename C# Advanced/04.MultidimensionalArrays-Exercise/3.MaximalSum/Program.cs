using System;
using System.Linq;

namespace _3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dementions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int row = dementions[0];
            int col = dementions[1];

            int[,] matrix = new int[row, col];

            ReadingMatrix(matrix);
            
            int rowIndex = 0;
            int colIndex = 0;

            Console.WriteLine($"Sum = {FindeMaxSum(matrix, ref rowIndex, ref colIndex)}");

            PrintingMatrix(matrix, rowIndex, colIndex);
        }

        private static double FindeMaxSum(int[,] matrix, ref int rowIndex, ref int colIndex)
        {
            double maxSum = double.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    double currSum = 0;
                    currSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                               matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                               matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            return maxSum;
        }

        private static void ReadingMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }
        private static void PrintingMatrix(int[,] matrix, int rowIndex, int colIndex)
        {
            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
