namespace _5.SnakeMoves
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dementions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int rows = dementions[0];
            int cols = dementions[1];

            string[,] matrix = new string[rows, cols];

            ReadingMatrix(matrix);
            PrintingMatrix(matrix);
        }

        private static void ReadingMatrix(string[,] matrix)
        {
            string word = Console.ReadLine();

            int currentWordIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (currentWordIndex == word.Length)
                        {
                            currentWordIndex = 0;
                        }
                        matrix[row, col] = word[currentWordIndex].ToString();

                        currentWordIndex++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (currentWordIndex == word.Length)
                        {
                            currentWordIndex = 0;
                        }

                        matrix[row, col] = word[currentWordIndex].ToString();

                        currentWordIndex++;
                    }
                }
            }
        }
        private static void PrintingMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}