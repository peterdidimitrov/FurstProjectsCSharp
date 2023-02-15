namespace _4.MatrixShuffling
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

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currentComm = commandArg[0];

                if (currentComm == "swap" && commandArg.Length == 5 &&
                    int.Parse(commandArg[1]) >= 0 && int.Parse(commandArg[1]) < rows &&
                    int.Parse(commandArg[2]) >= 0 && int.Parse(commandArg[2]) < cols &&
                    int.Parse(commandArg[3]) >= 0 && int.Parse(commandArg[3]) < rows &&
                    int.Parse(commandArg[4]) >= 0 && int.Parse(commandArg[4]) < cols)
                {
                    string tempElement = matrix[int.Parse(commandArg[1]), int.Parse(commandArg[2])];
                    matrix[int.Parse(commandArg[1]), int.Parse(commandArg[2])] = matrix[int.Parse(commandArg[3]), int.Parse(commandArg[4])];
                    matrix[int.Parse(commandArg[3]), int.Parse(commandArg[4])] = tempElement;

                    PrintingMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void ReadingMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] colElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }
        private static void PrintingMatrix(string[,] matrix)
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