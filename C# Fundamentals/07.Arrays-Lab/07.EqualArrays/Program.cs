using System;
using System.Linq;
namespace _07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] arrayTwo = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int sum = 0;
            bool isEqual = false;

            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    isEqual = true;
                    sum += arrayOne[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            if (isEqual == true)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
