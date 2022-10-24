using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> num = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] comArg = command.Split();
                if (comArg[0] == "Add")
                {
                    num.Add(int.Parse(comArg[1]));
                }
                else if (comArg[0] == "Insert")
                {
                    if (int.Parse(comArg[2]) < 0 || int.Parse(comArg[2]) >= num.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    num.Insert(int.Parse(comArg[2]), int.Parse(comArg[1]));
                }
                else if (comArg[0] == "Remove")
                {
                    if (int.Parse(comArg[1]) < 0 || int.Parse(comArg[1]) >= num.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    num.RemoveAt(int.Parse(comArg[1]));
                }
                else if (comArg[0] == "Shift")
                {
                    if (comArg[1] == "left")
                    {
                        for (int i = 0; i < int.Parse(comArg[2]); i++)
                        {
                            int firstNumber = num[0]; //Always take first number
                            num.RemoveAt(0); //Remove first number
                            num.Add(firstNumber);
                        }
                    }
                    else if (comArg[1] == "right")
                    {
                        for (int i = 0; i < int.Parse(comArg[2]); i++)
                        {
                            int lastNumber = num[num.Count - 1]; //Always take last number
                            num.RemoveAt(num.Count - 1); //Remove last number
                            num.Insert(0, lastNumber);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", num));
        }
    }
}
