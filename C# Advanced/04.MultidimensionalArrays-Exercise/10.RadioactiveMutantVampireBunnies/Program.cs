namespace _10.RadioactiveMutantVampireBunnies
{
    public class Program
    {
        private static int playerRow;
        private static int playerCol;
        private static char[,] matrix;

        private static int countOfCoals = 0;


        private static bool isAlive = true;
        private static bool isPlayerWin = false;
        private static List<int> coordinatesOfBunnies = new List<int>();
        static void Main(string[] args)
        {
            string[] dementions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(dementions[0]);
            int cols = int.Parse(dementions[1]);

            matrix = new char[rows, cols];

            //read the matrix and finde the player
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            //read directions

            string inputCommands = Console.ReadLine();

            for (int i = 0; i < inputCommands.Length; i++)
            {
                //move the player
                char command = inputCommands[i];

                if (command == 'U')
                {
                    MovePlayer(-1, 0);
                }
                else if (command == 'D')
                {
                    MovePlayer(1, 0);
                }
                else if (command == 'L')
                {
                    MovePlayer(0, -1);
                }
                else if (command == 'R')
                {
                    MovePlayer(0, 1);
                }

                if (!isAlive)
                {
                    FindeAllBunnies();
                    SpreadTheBunnies();
                    break;
                }
                if (isPlayerWin)
                {
                    FindeAllBunnies();
                    SpreadTheBunnies();
                    break;
                }

                //spread the bunnies
                ///1. finde all bunnies
                FindeAllBunnies();

                ///2. multiply the bunnies in every direction if in the matrix
                SpreadTheBunnies();

                if (!isAlive)
                {
                    FindeAllBunnies();
                    SpreadTheBunnies();
                    break;
                }
            }

            PrintMatrix(matrix, e => Console.Write(e));

            if (isAlive)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static void FindeAllBunnies()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        coordinatesOfBunnies.Add(row);
                        coordinatesOfBunnies.Add(col);
                    }
                }
            }
        }

        private static void SpreadTheBunnies()
        {
            for (int i = 0; i < coordinatesOfBunnies.Count; i += 2)
            {
                int currentBunnysRow = coordinatesOfBunnies[i];
                int currentBunnysCol = coordinatesOfBunnies[i + 1];

                //spread up
                if (IsInside(currentBunnysRow - 1, currentBunnysCol) && matrix[currentBunnysRow - 1, currentBunnysCol] != 'B')
                {
                    if (matrix[currentBunnysRow - 1, currentBunnysCol] == 'P')
                    {
                        isAlive = false;
                    }
                    matrix[currentBunnysRow - 1, currentBunnysCol] = 'B';
                }
                //spread down
                if (IsInside(currentBunnysRow + 1, currentBunnysCol) && matrix[currentBunnysRow + 1, currentBunnysCol] != 'B')
                {
                    if (matrix[currentBunnysRow + 1, currentBunnysCol] == 'P')
                    {
                        isAlive = false;
                    }
                    matrix[currentBunnysRow + 1, currentBunnysCol] = 'B';
                }
                //spread left
                if (IsInside(currentBunnysRow, currentBunnysCol - 1) && matrix[currentBunnysRow, currentBunnysCol - 1] != 'B')
                {
                    if (matrix[currentBunnysRow, currentBunnysCol - 1] == 'P')
                    {
                        isAlive = false;
                    }
                    matrix[currentBunnysRow, currentBunnysCol - 1] = 'B';
                }
                //spread right
                if (IsInside(currentBunnysRow, currentBunnysCol + 1) && matrix[currentBunnysRow, currentBunnysCol + 1] != 'B')
                {
                    if (matrix[currentBunnysRow, currentBunnysCol + 1] == 'P')
                    {
                        isAlive = false;
                    }
                    matrix[currentBunnysRow, currentBunnysCol + 1] = 'B';
                }
            }
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
        private static void MovePlayer(int row, int col)
        {
            if (IsInside(playerRow + row, playerCol + col))
            {
                if (matrix[playerRow + row, playerCol + col] == 'B')
                {
                    matrix[playerRow, playerCol] = '.';
                    playerRow += row;
                    playerCol += col;
                    isAlive = false;
                }
                else if (matrix[playerRow + row, playerCol + col] == '.')
                {
                    matrix[playerRow, playerCol] = '.';
                    playerRow += row;
                    playerCol += col;
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            else
            {
                isPlayerWin = true;
                matrix[playerRow, playerCol] = '.';
            }
        }
        private static bool IsInside(int row, int col)
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