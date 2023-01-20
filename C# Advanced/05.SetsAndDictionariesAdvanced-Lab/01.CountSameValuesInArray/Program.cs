namespace _01.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split().Select(double.Parse).ToArray();

            var dictionary = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currNum = numbers[i];

                int count = 0;

                if (!dictionary.ContainsKey(currNum))
                {
                    dictionary.Add(currNum, 1);
                }
                else
                {
                    count++;
                    dictionary[currNum]++;
                }
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}