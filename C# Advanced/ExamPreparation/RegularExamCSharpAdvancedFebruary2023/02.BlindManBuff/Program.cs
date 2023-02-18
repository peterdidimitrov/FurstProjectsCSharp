namespace SecondProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            //read the input size of matrix
            int[] dementions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = dementions[0];
            int cols = dementions[1];

            //initialize variables for current row and col
            int playerRow = -1;
            int playerCol = -1;

            //intialize variables for counters or flags
            int countOfMoves = 0;
            int countOfTouchedPlayers = 0;


            //read the matrix
            char[,] matrix = ReadMatrix<char>(
                () => Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray(), rows, cols);

            //find player's position
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            //hire is the main logic
            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "finish")
            {
                //move into the matrix
                if (command == "down" && IsInside(playerRow + 1, playerCol, matrix) && matrix[playerRow + 1, playerCol] != 'O')
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow++;
                }
                else if (command == "right" && IsInside(playerRow, playerCol + 1, matrix) && matrix[playerRow, playerCol + 1] != 'O')
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol++;
                }
                else if (command == "left" && IsInside(playerRow, playerCol - 1, matrix) && matrix[playerRow, playerCol - 1] != 'O')
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol--;
                }
                else if (command == "up" && IsInside(playerRow - 1, playerCol, matrix) && matrix[playerRow - 1, playerCol] != 'O')
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow--;
                }

                if (matrix[playerRow, playerCol] == '-')
                {
                    countOfMoves++;
                    matrix[playerRow, playerCol] = 'B';
                }
                if (matrix[playerRow, playerCol] == 'P')
                {
                    countOfMoves++;
                    countOfTouchedPlayers++;
                    matrix[playerRow, playerCol] = 'B';
                    if (countOfTouchedPlayers == 3)
                    {
                        Console.WriteLine($"Game over!");
                        Console.WriteLine($"Touched opponents: {countOfTouchedPlayers} Moves made: {countOfMoves}");
                        return;
                    }
                }
            }

            //conditional statement for final output
            Console.WriteLine($"Game over!");
            Console.WriteLine($"Touched opponents: {countOfTouchedPlayers} Moves made: {countOfMoves}");

            //print the matrix
            //PrintMatrix(matrix, e => Console.Write(e + " "));
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
        private static bool IsInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
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