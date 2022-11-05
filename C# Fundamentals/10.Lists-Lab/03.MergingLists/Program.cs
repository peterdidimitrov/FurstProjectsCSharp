using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> furstList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();
            int n = Math.Min(furstList.Count, secondList.Count);
           
                for (int i = 0; i < n; i++)
                {
                    result.Add(furstList[i]);
                    result.Add(secondList[i]);
                }
            if (furstList.Count > secondList.Count)
            {
                for (int i = n; i < furstList.Count; i++)
                {
                    result.Add(furstList[i]);
                }

            }
            else if (secondList.Count > furstList.Count)
            {
                for (int i = n; i < secondList.Count; i++)
                {
                    result.Add(secondList[i]);
                }
            }
            
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
