using System;
using System.Collections.Generic;

namespace _03.P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var townPopulation = new Dictionary<string, int>();
            var townGold = new Dictionary<string, int>();

            string cities;
            while ((cities = Console.ReadLine()) != "Sail")
            {
                string[] citiesInfo = cities
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);
                string town = citiesInfo[0];
                int population = int.Parse(citiesInfo[1]);
                int gold = int.Parse(citiesInfo[2]);
                if (townPopulation.ContainsKey(town))
                {
                    townPopulation[town] += population;
                    townGold[town] += gold;
                }
                else
                {
                    townPopulation[town] = population;
                    townGold[town] = gold;

                }
            }
            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commArg = commands
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];
                string town = commArg[1];

                if (currCommand == "Plunder")
                {
                    int people = int.Parse(commArg[2]);
                    int gold = int.Parse(commArg[3]);

                    townPopulation[town] -= people;
                    townGold[town] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (townPopulation[town] == 0 || townGold[town] == 0)
                    {
                        townGold.Remove(town);
                        townPopulation.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (currCommand == "Prosper")
                {
                    int gold = int.Parse(commArg[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        townGold[town] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {townGold[town]} gold.");
                    }

                }
            }
            if (townGold.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {townGold.Count} wealthy settlements to go to:");
                foreach (var kvp in townPopulation)
                {
                    string town = kvp.Key;
                    int population = kvp.Value;
                    int gold = townGold[town];
                    Console.WriteLine($"{town} -> Population: {population} citizens, Gold: {gold} kg");
                }
            }
        }
    }
}
