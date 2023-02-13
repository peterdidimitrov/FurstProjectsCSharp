namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix<int>(
                () => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray(), size, size);

            string[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Console.WriteLine(string.Join(" ", coordinates));

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] indexies = coordinates[i]
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();

                int row = indexies[0];
                int col = indexies[1];

                if (IsValid(row, col, matrix) &&
                    matrix[row, col] > 0)
                {
                    int bombDamage = matrix[row, col];
                    matrix = Explosion(bombDamage, row, col, matrix);
                }
            }
            List<int> activeCells = FindActiveCells(matrix);
            Console.WriteLine($"Alive cells: {activeCells.Count}");
            Console.WriteLine($"Sum: {activeCells.Sum()}");

            PrintMatrix(matrix, e => Console.Write(e + " "));
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
        private static List<int> FindActiveCells(int[,] squareMatrix)
        {
            List<int> activeCells = new List<int>();

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    if (squareMatrix[row, col] > 0)
                    {
                        activeCells.Add(squareMatrix[row, col]);
                    }
                }
            }

            return activeCells;
        }

        private static int[,] Explosion(int bombDamage, int currentRowBomb, int currentColBomb, int[,] squareMatrix)
        {
            if (IsValid(currentRowBomb - 1, currentColBomb, squareMatrix) && squareMatrix[currentRowBomb - 1, currentColBomb] > 0)
            {
                squareMatrix[currentRowBomb - 1, currentColBomb] -= bombDamage;
            }
            if (IsValid(currentRowBomb + 1, currentColBomb, squareMatrix) && squareMatrix[currentRowBomb + 1, currentColBomb] > 0)
            {
                squareMatrix[currentRowBomb + 1, currentColBomb] -= bombDamage;
            }
            if (IsValid(currentRowBomb - 1, currentColBomb - 1, squareMatrix) && squareMatrix[currentRowBomb - 1, currentColBomb - 1] > 0)
            {
                squareMatrix[currentRowBomb - 1, currentColBomb - 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb - 1, currentColBomb + 1, squareMatrix) && squareMatrix[currentRowBomb - 1, currentColBomb + 1] > 0)
            {
                squareMatrix[currentRowBomb - 1, currentColBomb + 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb + 1, currentColBomb - 1, squareMatrix) && squareMatrix[currentRowBomb + 1, currentColBomb - 1] > 0)
            {
                squareMatrix[currentRowBomb + 1, currentColBomb - 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb + 1, currentColBomb + 1, squareMatrix) && squareMatrix[currentRowBomb + 1, currentColBomb + 1] > 0)
            {
                squareMatrix[currentRowBomb + 1, currentColBomb + 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb, currentColBomb - 1, squareMatrix) && squareMatrix[currentRowBomb, currentColBomb - 1] > 0)
            {
                squareMatrix[currentRowBomb, currentColBomb - 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb, currentColBomb + 1, squareMatrix) && squareMatrix[currentRowBomb, currentColBomb + 1] > 0)
            {
                squareMatrix[currentRowBomb, currentColBomb + 1] -= bombDamage;
            }

            squareMatrix[currentRowBomb, currentColBomb] -= bombDamage;

            return squareMatrix;
        }

        private static bool IsValid(int row, int col, int[,] squareMatrix)
        {
            if (row < squareMatrix.GetLength(0) && row >= 0 && col >= 0 && col < squareMatrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}