using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.AB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToList();

            string commands;
            while ((commands = Console.ReadLine()) != "Finish")
            {
                string[] comArg = commands
                    .Split(" ")
                    .ToArray();
                string currentCom = comArg[0];
                if (currentCom == "Add")
                {
                    int value = int.Parse(comArg[1]);
                    numbers.Add(value);
                }
                else if (currentCom == "Remove")
                {
                    int value = int.Parse(comArg[1]);
                    if (numbers.Contains(value))
                    {
                        numbers.Remove(value);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCom == "Replace")
                {
                    int value = int.Parse(comArg[1]);
                    int replasement = int.Parse(comArg[2]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == value)
                        {
                            numbers.Insert(i, replasement);
                            numbers.RemoveAt(i + 1);
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }

                }
                else if (currentCom == "Collapse")
                {
                    int value = int.Parse(comArg[1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] < value)
                        {
                            numbers.RemoveAt(i);
                            i = -1;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
            }


            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
