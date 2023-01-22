using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> uniqueCompounds = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicalCompounds = Console.ReadLine()
                    .Split();

                for (int j = 0; j < chemicalCompounds.Length; j++)
                {
                    uniqueCompounds.Add(chemicalCompounds[j]);
                }
            }
            Console.WriteLine(string.Join(" ", uniqueCompounds.OrderBy(e => e)));
        }
    }
}
