using System;
using System.Linq;

namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int bestSequenceSum = 0;
            int longestSequence = 0;
            int bestSequenceIndex = -1;
            string[] bestDNA = new string[length];
            string sequences;
            while ((sequences = Console.ReadLine()) != "Clone them")
            {
                int[] elements = sequences
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int sum = 0;
                for (int i = 0; i < elements.Length; i++)
                {
                    int currSeq = 0;
                    if (elements[i] == 1)
                    {
                        sum++;
                        currSeq++;
                        longestSequence = currSeq;
                    }
                    else
                    {
                        currSeq = 0;
                    }
                    if (sum > bestSequenceSum)
                    {
                        bestSequenceSum = sum;
                    }
                }
            }
            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
        }
    }
}
