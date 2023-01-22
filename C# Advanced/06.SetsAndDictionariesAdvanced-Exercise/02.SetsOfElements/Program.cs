using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int firstSize = size[0];
            int secondSize = size[1];

            HashSet<string> firstSet = new HashSet<string>();
            HashSet<string> secondSet = new HashSet<string>();

            for (int i = 0; i < firstSize; i++)
            {
                firstSet.Add(Console.ReadLine());
            }
            for (int i = 0; i < secondSize; i++)
            {
                secondSet.Add(Console.ReadLine());
            }
            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
