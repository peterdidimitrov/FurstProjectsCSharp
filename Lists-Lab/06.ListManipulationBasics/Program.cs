using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isCommandActivated = false;
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] currentCommand = command.Split();
                if (currentCommand[0] == "Add")
                {
                    isCommandActivated = true;
                    numbers.Add(int.Parse(currentCommand[1]));
                }
                else if (currentCommand[0] == "Remove")
                {
                    isCommandActivated = true;
                    numbers.Remove(int.Parse(currentCommand[1]));
                }
                else if (currentCommand[0] == "RemoveAt")
                {
                    isCommandActivated = true;
                    numbers.RemoveAt(int.Parse(currentCommand[1]));
                }
                else if (currentCommand[0] == "Insert")
                {
                    isCommandActivated = true;
                    numbers.Insert(int.Parse(currentCommand[2]), int.Parse(currentCommand[1]));
                }
                else if (currentCommand[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(currentCommand[1])))
                    {
                        Console.WriteLine("Yes");
                        continue;
                    }
                    Console.WriteLine("No such number");
                }
                else if (currentCommand[0] == "PrintEven")
                {
                    Console.Write(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                    Console.WriteLine();
                }
                else if (currentCommand[0] == "PrintOdd")
                {
                    Console.Write(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                    Console.WriteLine();
                }
                else if (currentCommand[0] == "GetSum")
                {
                    Console.Write(string.Join(" ", numbers.Sum()));
                    Console.WriteLine();
                }
                else if (currentCommand[0] == "Filter")
                {
                    if (currentCommand[1] == "<")
                    {
                        Console.Write(string.Join(" ", numbers.Where(n => n < int.Parse(currentCommand[2]))));
                        Console.WriteLine();
                    }
                    else if (currentCommand[1] == ">")
                    {
                        Console.Write(string.Join(" ", numbers.Where(n => n > int.Parse(currentCommand[2]))));
                        Console.WriteLine();
                    }
                    else if (currentCommand[1] == ">=")
                    {
                        Console.Write(string.Join(" ", numbers.Where(n => n >= int.Parse(currentCommand[2]))));
                        Console.WriteLine();
                    }
                    else if (currentCommand[1] == "<=")
                    {
                        Console.Write(string.Join(" ", numbers.Where(n => n <= int.Parse(currentCommand[2]))));
                        Console.WriteLine();
                    }
                }
            }
            if (isCommandActivated == true)
            {
                Console.Write(string.Join(" ", numbers));
            }
        }
    }
}
