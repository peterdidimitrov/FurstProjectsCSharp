﻿namespace _2.SumMatrixColumns
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ")
                .Select(int.Parse).ToArray();

            var matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}