using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine()
                .Split("|")
                .ToList();
            List<string> stolenItems = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] comArg = command.Split();
                string currentCommand = comArg[0];

                if (currentCommand == "Loot")
                {

                    for (int i = 1; i < comArg.Length; i++)
                    {
                        if (!treasure.Contains(comArg[i]))
                        {
                            treasure.Insert(0, comArg[i]);
                        }
                    }
                }
                else if (currentCommand == "Drop")
                {
                    int index = int.Parse(comArg[1]);
                    if (index < 0 || index > treasure.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        treasure.Add(treasure[index]);
                        treasure.RemoveAt(index);
                    }
                }
                else if (currentCommand == "Steal")
                {
                    int count = int.Parse(comArg[1]);


                    for (int i = treasure.Count - 1; i > (treasure.Count - 1) - count; i--)
                    {
                        stolenItems.Add(treasure[i]);

                    }
                    for (int i = 0; i <= stolenItems.Count - 1; i++)
                    {
                        if (treasure.Contains(stolenItems[i]))
                        {
                            treasure.Remove(stolenItems[i]);

                        }

                    }
                    stolenItems.Reverse();
                    Console.WriteLine(string.Join(", ", stolenItems));
                }
            }
            if (treasure.Count >= 1)
            {
                double averageGain = 0;
                for (int i = 0; i < treasure.Count; i++)
                {
                    averageGain += treasure[i].Count();
                }
                Console.WriteLine($"Average treasure gain: {(averageGain / treasure.Count):f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
