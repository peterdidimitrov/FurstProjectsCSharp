using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double average = numbers.Average();
            Console.WriteLine(average);

            List<int> newLineOfNumbers = new List<int>();

            int counter = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    counter++;
                    newLineOfNumbers.Add(numbers[i]);
                }
            }

            newLineOfNumbers.Sort();
            newLineOfNumbers.Reverse();

            if (numbers.Count == 1 || counter == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                if (newLineOfNumbers.Count > 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(newLineOfNumbers[i] + " ");
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(" ", newLineOfNumbers));
                }
            }
        }
    }
}
