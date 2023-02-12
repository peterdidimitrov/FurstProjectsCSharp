namespace _02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int racingNumber = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            string[,] matrix = ReadMatrix<string>(
                () => Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray(), rows, cols);

            bool isFirstTunnelFound = false;
            int firstTunnelRow = 0;
            int firstTunnelCol = 0;

            int secondTunnelRow = 0;
            int secondTunnelCol = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "T" && !isFirstTunnelFound)
                    {
                        firstTunnelRow = row;
                        firstTunnelCol = col;
                        isFirstTunnelFound = true;
                    }
                    else if (matrix[row, col] == "T")
                    {
                        secondTunnelRow = row;
                        secondTunnelCol = col;
                    }
                }
            }
            int carRow = 0;
            int carCol = 0;
            bool isFinished = false;

            int totalKm = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                if (command == "down")
                {
                    carRow++;
                }
                else if (command == "right")
                {
                    carCol++;
                }
                else if (command == "left")
                {
                    carCol--;
                }
                else if (command == "up")
                {
                    carRow--;
                }
                
                if (matrix[carRow, carCol] == ".")
                {
                    totalKm += 10;
                }
                if (matrix[carRow, carCol] == "T")
                {
                    matrix[carRow, carCol] = ".";
                    if (carRow == firstTunnelRow && carCol == firstTunnelCol)
                    {
                        carRow = secondTunnelRow;
                        carCol = secondTunnelCol;
                    }
                    else
                    {
                        carRow = firstTunnelRow;
                        carCol = firstTunnelCol;
                    }

                    matrix[carRow, carCol] = ".";
                    totalKm += 30;
                }
                if (matrix[carRow, carCol] == "F")
                {
                    totalKm += 10;
                    isFinished = true;
                    break;
                }
            }
            matrix[carRow, carCol] = "C";

            if (isFinished)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {totalKm} km.");

            PrintMatrix(matrix, e => Console.Write(e));

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
        }
    }
}