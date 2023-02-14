using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> areasOfWhiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ").Select(int.Parse));

            Queue<int> areasOfGreyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ").Select(int.Parse));

            Dictionary<int, string> locations = new Dictionary<int, string>();
            Dictionary<string, int> makedAreas = new Dictionary<string, int>();

            locations.Add(40, "Sink");
            locations.Add(50, "Oven");
            locations.Add(60, "Countertop");
            locations.Add(70, "Wall");
            locations.Add(0, "Floor");

            while (areasOfWhiteTiles.Any() && areasOfGreyTiles.Any())
            {
                if (areasOfWhiteTiles.Peek() == areasOfGreyTiles.Peek())
                {
                    int sumOfQuantities = areasOfWhiteTiles.Peek() + areasOfGreyTiles.Peek();
                    if (locations.ContainsKey(sumOfQuantities))
                    {
                        string currLocation = locations[sumOfQuantities];
                        if (!makedAreas.ContainsKey(currLocation))
                        {
                            makedAreas.Add(currLocation, 1);
                        }
                        else
                        {
                            makedAreas[currLocation]++;
                        }
                        areasOfGreyTiles.Dequeue();
                        areasOfWhiteTiles.Pop();
                    }
                    else
                    {
                        string currLocation = locations[0];
                        if (!makedAreas.ContainsKey(currLocation))
                        {
                            makedAreas.Add(currLocation, 1);
                        }
                        else
                        {
                            makedAreas[currLocation]++;
                        }
                        areasOfGreyTiles.Dequeue();
                        areasOfWhiteTiles.Pop();
                    }
                }
                else
                {
                    int splitedTile = areasOfWhiteTiles.Pop() / 2;
                    areasOfWhiteTiles.Push(splitedTile);

                    int temp = areasOfGreyTiles.Dequeue();
                    areasOfGreyTiles.Enqueue(temp);
                }
            }


            if (!areasOfWhiteTiles.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", areasOfWhiteTiles)}");
            }
            if (!areasOfGreyTiles.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", areasOfGreyTiles)}");
            }
            foreach (var area in makedAreas.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                string name = area.Key;
                int count = area.Value;
                Console.WriteLine($"{name}: {count}");
            }
        }
    }
}
