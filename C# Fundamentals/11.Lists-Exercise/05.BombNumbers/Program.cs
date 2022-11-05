using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] commandArg = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int bombNum = commandArg[0];
            int bombPower = commandArg[1];
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];
                if (currentNum == bombNum)
                {
                    for (int j = 1; j <= bombPower; j++)
                    {
                        if (i - j < 0)
                        {
                            break;
                        }
                        else
                        {
                            numbers[i - j] = 0;
                        }
                    }

                    for (int j = 1; j <= bombPower; j++)
                    {
                        if (i + j > numbers.Count - 1)
                        {
                            break;
                        }
                        else
                        {
                            numbers[i + j] = 0;
                        }
                    }

                    numbers[i] = 0;
                }
            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}