namespace _02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int battlefieldSize = int.Parse(Console.ReadLine());

            string[,] battleField = new string[battlefieldSize, battlefieldSize];

            int submRow = -1;
            int submCol = -1;

            int cruisersHit = 0;
            int minesHit = 0;

            for (int i = 0; i < battlefieldSize; i++)
            {
                string rowInput = Console.ReadLine();
                for (int j = 0; j < battlefieldSize; j++)
                {
                    battleField[i, j] = rowInput[j].ToString();
                    if (rowInput[j] == 'S')
                    {
                        battleField[i, j] = "-";
                        submRow = i;
                        submCol = j;
                    }
                }
            }

            while (true)
            {
                if (minesHit == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submRow}, {submCol}]!");
                    PrintMatrix(battleField, e => Console.Write(e));
                    return;
                }
                if (cruisersHit == 3)
                {
                    Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                    PrintMatrix(battleField, e => Console.Write(e)); 
                    return;
                }
                string command = Console.ReadLine().ToLower();
                if (command == "right")
                {
                    Move(battleField, ref submRow, ref submCol, 0, 1, ref cruisersHit, ref minesHit);
                }
                else if (command == "left")
                {
                    Move(battleField, ref submRow, ref submCol, 0, -1, ref cruisersHit, ref minesHit);
                }
                else if (command == "up")
                {
                    Move(battleField, ref submRow, ref submCol, - 1, 0, ref cruisersHit, ref minesHit);
                }
                else if (command == "down")
                {
                    Move(battleField, ref submRow, ref submCol, 1, 0, ref cruisersHit, ref minesHit);
                }
            }
        }

        private static void Move(string[,] battleField, ref int submRow, ref int submCol, int row, int col, ref int cruisersHit, ref int minesHit)
        {
            if (battleField[submRow + row, submCol + col] == "-")
            {
                battleField[submRow, submCol] = "-";
                submRow += row;
                submCol += col;
                battleField[submRow, submCol] = "S";
            }
            else if (battleField[submRow + row, submCol + col] == "*")
            {
                battleField[submRow, submCol] = "-";
                submRow += row;
                submCol += col;
                minesHit++;
                battleField[submRow, submCol] = "S";
            }
            else if (battleField[submRow + row, submCol + col] == "C")
            {
                battleField[submRow, submCol] = "-";
                submRow += row;
                submCol += col;
                battleField[submRow, submCol] = "S";
                cruisersHit++;
            }
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