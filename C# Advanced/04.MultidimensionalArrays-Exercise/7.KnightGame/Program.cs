namespace _7.KnightGame
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());

            char[,] matrix = new char[side, side];

            ReadingMatrix(matrix);

            PrintingMatrix(matrix);
        }
        private static void ReadingMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colElements = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }
        private static void PrintingMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
