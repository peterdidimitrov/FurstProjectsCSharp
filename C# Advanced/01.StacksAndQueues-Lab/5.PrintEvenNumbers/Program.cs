namespace _5.PrintEvenNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var evenNumbers = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNumbers.Enqueue(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}