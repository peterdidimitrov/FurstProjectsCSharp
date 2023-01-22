using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, new List<int>());
                    numbers[number].Add(number);
                }
                else
                {
                    numbers[number].Add(number);
                }
            }
            foreach (var number in numbers)
            {
                if (number.Value.Count % 2 == 0)
                {
                    Console.WriteLine(number.Value[0]);
                }
            }
        }
    }
}
