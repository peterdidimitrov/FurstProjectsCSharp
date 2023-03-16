namespace PlayCatch
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int exeptionsCount = 0;

            while (exeptionsCount != 3)
            {
                string[] commandArgument = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    ManipulateArray(input, commandArgument);
                }
                catch (ArgumentOutOfRangeException)
                {
                    exeptionsCount++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    exeptionsCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(string.Join(", ", input));
        }
        private static void ManipulateArray(List<int> input, string[] commandArgument)
        {
            string currentCommand = commandArgument[0];

            if (currentCommand == "Replace")
            {

                int index = 0;

                if (ValidateFormat(commandArgument[1], index))
                {
                    index = int.Parse(commandArgument[1]);
                }
                else
                {
                    throw new FormatException();
                }

                int element = 0;

                if (ValidateFormat(commandArgument[2], element))
                {
                    element = int.Parse(commandArgument[2]);
                }
                else
                {
                    throw new FormatException();
                }

                if (ValidateIndex(input, index))
                {
                    input.RemoveAt(index);
                    input.Insert(index, element);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else if (currentCommand == "Print")
            {
                int startIndex = 0;

                if (ValidateFormat(commandArgument[1], startIndex))
                {
                    startIndex = int.Parse(commandArgument[1]);
                }
                else
                {
                    throw new FormatException();
                }

                int endIndex = 0;

                if (ValidateFormat(commandArgument[2], endIndex))
                {
                    endIndex = int.Parse(commandArgument[2]);
                }
                else
                {
                    throw new FormatException();
                }

                if (ValidateIndex(input, startIndex) && ValidateIndex(input, endIndex))
                {
                    List<int> newList = new List<int>();
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        newList.Add(input[i]);
                    }
                    Console.WriteLine(string.Join(", ", newList));
                    
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else if (currentCommand == "Show")
            {
                int index = 0;
                if (ValidateFormat(commandArgument[1], index))
                {
                    index = int.Parse(commandArgument[1]);
                }
                else
                {
                    throw new FormatException();
                }

                if (ValidateIndex(input, index))
                {
                    Console.WriteLine(input[index]);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static bool ValidateFormat(string input, int index)
            => int.TryParse(input, out index);


        private static bool ValidateIndex(List<int> input, int index)
            => index <= input.Count - 1 && index >= 0;
    }
}