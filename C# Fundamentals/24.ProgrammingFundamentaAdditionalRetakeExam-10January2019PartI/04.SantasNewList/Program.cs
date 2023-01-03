using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SantasNewList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var namesAmount = new Dictionary<string, int>();
            var presentsAmount = new Dictionary<string, int>();
            string commands;
            while ((commands = Console.ReadLine()) != "END")
            {
                string[] commArg = commands
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);
                if (commArg[0] != "Remove")
                {
                    string name = commArg[0];
                    string present = commArg[1];
                    int amount = int.Parse(commArg[2]);
                    if (!namesAmount.ContainsKey(name))
                    {
                        namesAmount.Add(name, amount);
                    }
                    else
                    {
                        namesAmount[name] += amount;
                    }
                    if (!presentsAmount.ContainsKey(present))
                    {
                        presentsAmount.Add(present, amount);
                    }
                    else
                    {
                        presentsAmount[present] += amount;
                    }
                }
                else
                {
                    string name = commArg[1];
                    namesAmount.Remove(name);
                }
            }
            Console.WriteLine("Children:");

            foreach (var child in namesAmount
                .OrderByDescending(ch => ch.Value).ThenBy(ch => ch.Key))
            {
                string name = child.Key;
                int amount = child.Value;
                Console.WriteLine($"{name} -> {amount}");
            }
            Console.WriteLine("Presents:");
            foreach (var present in presentsAmount)
            {
                string currPresent = present.Key;
                int amount = present.Value;
                Console.WriteLine($"{currPresent} -> {amount}");
            }
        }
    }
}
