namespace _6.Supermarket
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var names = new Queue<string>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (names.Any())
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(input);
                }
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}