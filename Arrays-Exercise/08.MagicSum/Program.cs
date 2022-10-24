using System;
using System.Linq;
namespace _08.MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions
                .RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            int magicNum = int.Parse(Console.ReadLine());

            int[] uniquePairs = new int[1];

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == magicNum)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]} ");
                    }
                }
            }
        }
    }
}
