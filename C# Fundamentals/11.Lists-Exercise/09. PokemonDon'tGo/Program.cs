using System;
using System.Linq;
using System.Collections.Generic;

namespace P08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> distances = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToList();

            int numOfIterations = distances.Count;
            decimal sumOfRemovedDistances = 0;

            while (distances.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    decimal delitedDistance = distances[0];
                    sumOfRemovedDistances += distances[0];
                    distances.RemoveAt(0);
                    distances.Insert(0, distances[distances.Count - 1]);

                    for (int j = 0; j < distances.Count; j++)
                    {
                        if (distances[j] <= delitedDistance)
                        {
                            distances[j] += delitedDistance;
                        }
                        else
                        {
                            distances[j] -= delitedDistance;
                        }
                    }
                }
                if (index > distances.Count - 1)
                {
                    decimal delitedDistance = distances[distances.Count - 1];
                    sumOfRemovedDistances += distances[distances.Count - 1];
                    distances.RemoveAt(distances.Count - 1);
                    distances.Add(distances[0]);

                    for (int j = 0; j < distances.Count; j++)
                    {
                        if (distances[j] <= delitedDistance)
                        {
                            distances[j] += delitedDistance;
                        }
                        else
                        {
                            distances[j] -= delitedDistance;
                        }
                    }
                }

                if (index >= 0 && index <= distances.Count - 1)
                {
                    decimal delitedDistance = distances[index];
                    sumOfRemovedDistances += distances[index];

                    distances.RemoveAt(index);
                    for (int j = 0; j < distances.Count; j++)
                    {
                        if (distances[j] <= delitedDistance)
                        {
                            distances[j] += delitedDistance;
                        }
                        else
                        {
                            distances[j] -= delitedDistance;
                        }
                    }
                }
            }
            Console.WriteLine(sumOfRemovedDistances);
        }
    }
}