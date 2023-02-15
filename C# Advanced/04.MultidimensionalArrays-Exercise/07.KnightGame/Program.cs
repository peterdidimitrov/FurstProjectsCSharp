namespace _7.KnightGame
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());

            char[,] matrix = new char[side, side];

            ReadingMatrix(matrix);

            Console.WriteLine(FindHorses(matrix));

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
        private static int FindHorses(char[,] matrix)
        {
            int removedHorses = 0;

            while (true)
            {
                int maxAttackedHorses = 0;
                int rowCoordinates = -1;
                int colCoordinates = -1;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char field = matrix[row, col];
                        int currentAttackedHorses = 0;

                        if (field == 'K')
                        {
                            //up and left
                            if (row - 2 >= 0 && row - 2 < matrix.GetLength(0) &&
                                col - 1 >= 0 && col - 1 < matrix.GetLength(1) &&
                                matrix[row - 2, col - 1] == 'K')
                            {
                                CountAttackedHorses(ref currentAttackedHorses, ref maxAttackedHorses, ref rowCoordinates, ref colCoordinates, row, col);
                            }
                            //up and right
                            if (row - 2 >= 0 && row - 2 < matrix.GetLength(0) &&
                                col + 1 >= 0 && col + 1 < matrix.GetLength(1) &&
                                matrix[row - 2, col + 1] == 'K')
                            {
                                CountAttackedHorses(ref currentAttackedHorses, ref maxAttackedHorses, ref rowCoordinates, ref colCoordinates, row, col);
                            }
                            //right and up
                            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) &&
                                col + 2 >= 0 && col + 2 < matrix.GetLength(1) &&
                                matrix[row - 1, col + 2] == 'K')
                            {
                                CountAttackedHorses(ref currentAttackedHorses, ref maxAttackedHorses, ref rowCoordinates, ref colCoordinates, row, col);
                            }
                            //right and down
                            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) &&
                                col + 2 >= 0 && col + 2 < matrix.GetLength(1) &&
                                matrix[row + 1, col + 2] == 'K')
                            {
                                CountAttackedHorses(ref currentAttackedHorses, ref maxAttackedHorses, ref rowCoordinates, ref colCoordinates, row, col);
                            }
                            //down and right
                            if (row + 2 >= 0 && row + 2 < matrix.GetLength(0) &&
                                col + 1 >= 0 && col + 1 < matrix.GetLength(1) &&
                                matrix[row + 2, col + 1] == 'K')
                            {
                                CountAttackedHorses(ref currentAttackedHorses, ref maxAttackedHorses, ref rowCoordinates, ref colCoordinates, row, col);
                            }
                            //down and left
                            if (row + 2 >= 0 && row + 2 < matrix.GetLength(0) &&
                                col - 1 >= 0 && col - 1 < matrix.GetLength(1) &&
                                matrix[row + 2, col - 1] == 'K')
                            {
                                CountAttackedHorses(ref currentAttackedHorses, ref maxAttackedHorses, ref rowCoordinates, ref colCoordinates, row, col);
                            }
                            //left and down
                            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) &&
                                col - 2 >= 0 && col - 2 < matrix.GetLength(1) &&
                                matrix[row + 1, col - 2] == 'K')
                            {
                                CountAttackedHorses(ref currentAttackedHorses, ref maxAttackedHorses, ref rowCoordinates, ref colCoordinates, row, col);
                            }
                            //left and up
                            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) &&
                                col - 2 >= 0 && col - 2 < matrix.GetLength(1) &&
                                matrix[row - 1, col - 2] == 'K')
                            {
                                CountAttackedHorses(ref currentAttackedHorses, ref maxAttackedHorses, ref rowCoordinates, ref colCoordinates, row, col);
                            }
                        }
                    }
                }

                if (maxAttackedHorses == 0)
                {
                    break;
                }

                matrix[rowCoordinates, colCoordinates] = '0';
                removedHorses++;
            }
            return removedHorses;
        }
        private static void CountAttackedHorses(ref int currentAttackedHorses, ref int maxAttackedHorses, ref int rowCoordinates, ref int colCoordinates, int row, int col)
        {
            currentAttackedHorses++;
            if (maxAttackedHorses < currentAttackedHorses)
            {
                maxAttackedHorses = currentAttackedHorses;
                rowCoordinates = row;
                colCoordinates = col;
            }
        }
    }
}