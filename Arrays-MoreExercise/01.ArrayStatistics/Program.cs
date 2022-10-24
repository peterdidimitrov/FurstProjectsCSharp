using System;
using System.Linq;
namespace _01.ArrayStatistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a program which receives array of integers(space-separated) and prints the minimum and maximum number,
            //the sum of the elements and the average value.

            int[] integers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int min = int.MaxValue;
            int max = int.MinValue;

            int sum = 0;

            for (int i = 0; i < integers.Length; i++)
            {
                if (integers[i] < min)
                {
                    min = integers[i];
                }
                if (integers[i] > max)
                {
                    max = integers[i];
                }
                sum += integers[i];
            }
            double avg = (double)sum / integers.Length;

            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {avg}");
        }
    }
}
