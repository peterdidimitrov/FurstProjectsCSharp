namespace _4.SymbolInMatrix
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colElements = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = true;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                    else
                    {
                        isFound = false;
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}