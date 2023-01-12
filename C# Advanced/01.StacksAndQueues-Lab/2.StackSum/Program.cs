namespace _2.StackSum
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var output = new Stack<int>();

            foreach (var number in numbers)
            {
                output.Push(number);
            }
            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = commArg[0];

                if (currentCommand == "add")
                {
                    output.Push(int.Parse(commArg[1]));
                    output.Push(int.Parse(commArg[2]));
                }
                else if (currentCommand == "remove")
                {
                    if (int.Parse(commArg[1]) > numbers.Length)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < int.Parse(commArg[1]); i++)
                        {
                            output.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {output.Sum()}");
        }
    }
}