﻿using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }
                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"    {country.Key} -> ");

                    for (int i = 0; i < country.Value.Count; i++)
                    {
                        if (i != 0)
                        {
                            Console.Write(", ");
                        }

                        Console.Write($"{country.Value[i]}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
