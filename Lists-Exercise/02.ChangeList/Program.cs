using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandSplit = command.Split();
                if (commandSplit[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(commandSplit[1]));
                }
                else if (commandSplit[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandSplit[2]), int.Parse(commandSplit[1]));
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
