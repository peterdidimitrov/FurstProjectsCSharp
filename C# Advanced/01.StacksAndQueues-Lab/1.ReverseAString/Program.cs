namespace _1.ReverseAString
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var output = new Stack<char>();

            foreach (var ch in input)
            {
                output.Push(ch);
            }
            while (output.Count > 0)
            {
                Console.Write(output.Pop());
            }
            Console.WriteLine();
        }
    }
}