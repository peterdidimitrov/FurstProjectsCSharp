using System;
using System.Linq;
using System.Collections.Generic;
namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int capacity = int.Parse(Console.ReadLine());

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandSplit = command.Split();
                if (commandSplit[0] == "Add" && int.Parse(commandSplit[1]) <= capacity)
                {
                    wagons.Add(int.Parse(commandSplit[1]));
                }
                else if (int.Parse(commandSplit[0]) <= capacity)
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (int.Parse(commandSplit[0]) + wagons[i] <= capacity)
                        {
                            wagons[i] = int.Parse(commandSplit[0]) + wagons[i];
                            break;
                        }

                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
