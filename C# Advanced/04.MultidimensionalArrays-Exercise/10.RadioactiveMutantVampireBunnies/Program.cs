namespace _10.RadioactiveMutantVampireBunnies
{
    public class Program
    {
        private static int minerRow;
        private static int minerCol;
        private static char[,] field;

        private static int countOfCoals = 0;


        private static bool isGameOver = false;
        static void Main(string[] args)
        {
            string[] dementions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(dementions[0]);
            int cols = int.Parse(dementions[1]);

            field = new char[rows, cols];

            //reading lair - matrix
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];
                }
            }

            PrintMatrix(field, e => Console.Write(e));
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
        private static void Move(int row, int col)
        {
            if (IsInside(minerRow + row, minerCol + col))
            {
                if (field[minerRow + row, minerCol + col] == 'e')
                {
                    field[minerRow, minerCol] = '*';
                    minerRow += row;
                    minerCol += col;
                    isGameOver = true;
                }
                else if (field[minerRow + row, minerCol + col] == '*')
                {
                    field[minerRow, minerCol] = 'p';
                    minerRow += row;
                    minerCol += col;
                    field[minerRow, minerCol] = 'p';
                    countOfCoals++;
                }
                else if (field[minerRow + row, minerCol + col] == 'p')
                {
                    minerRow += row;
                    minerCol += col;
                }
            }

        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
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
    }
}