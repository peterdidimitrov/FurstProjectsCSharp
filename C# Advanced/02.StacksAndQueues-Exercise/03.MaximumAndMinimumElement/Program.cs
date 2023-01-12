namespace _03.MaximumAndMinimumElement
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                if (input[0] == "1")
                {
                    int addNum = int.Parse(input[1]);

                    stack.Push(addNum);
                }
                else if (input[0] == "2" && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (input[0] == "3" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (input[0] == "4" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}