using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            ReadingMatrix(size, matrix);

            Console.WriteLine(Math.Abs(SumPrmaryDiagonal(size, matrix) - SumSecondaryDiagonal(size, matrix)));
        }

        private static double SumSecondaryDiagonal(int size, int[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, size - 1 - i];
            }
            return sum;
        }

        private static double SumPrmaryDiagonal(int size, int[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }

        private static void ReadingMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }

        public static void PrintingMatrix(int[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
