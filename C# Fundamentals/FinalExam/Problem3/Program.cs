using System;
using System.Collections.Generic;

namespace Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heroes = new Dictionary<string, List<string>>();
            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commArg = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];
                string name = commArg[1];
                if (currCommand == "Enroll")
                {
                    if (!heroes.ContainsKey(name))
                    {
                        heroes[name] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already enrolled.");
                    }
                }
                else if (currCommand == "Learn")
                {
                    string spellName = commArg[2];
                    if (!heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        if (!heroes[name].Contains(spellName))
                        {
                            heroes[name].Add(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{name} has already learnt {spellName}.");
                        }
                    }
                }
                else if (currCommand == "Unlearn")
                {
                    string spellName = commArg[2];
                    if (!heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        if (!heroes[name].Contains(spellName))
                        {
                            Console.WriteLine($"{name} doesn't know {spellName}.");
                        }
                        else
                        {
                            heroes[name].Remove(spellName);
                        }
                    }
                }
            }
            Console.WriteLine("Heroes:");
            foreach (var heroe in heroes)
            {
                var name = heroe.Key;
                
                Console.WriteLine($"== {name}: {string.Join(", ", heroe.Value)}");              
            }
        }
    }
}
