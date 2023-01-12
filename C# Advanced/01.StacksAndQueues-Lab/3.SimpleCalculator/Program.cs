namespace _3.SimpleCalculator
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var output = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                output.Push(input[i]);

                if (output.Count == 3)
                {
                    int first = int.Parse(output.Pop());
                    var sign = output.Pop();
                    int second = int.Parse(output.Pop());
                    int result = 0;

                    if (sign == "+")
                    {
                        result = first + second;
                    }
                    if (sign == "-")
                    {
                        result = second - first;
                    }
                    output.Push(result.ToString());
                }
            }

            Console.WriteLine(output.Pop());
        }
    }
}