using System;
using System.Linq;
using System.Numerics;

namespace _02.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] numbers = Console.ReadLine()
                .Split()
                .Select(BigInteger.Parse)
                .ToArray();

            string commands;
            while ((commands = Console.ReadLine()) != "end")
            {
                string[] comArg = commands
                    .Split()
                    .ToArray();
                string currentCommand = comArg[0];

                if (currentCommand == "swap")
                {
                    int indexOne = int.Parse(comArg[1]);
                    int indexTwo = int.Parse(comArg[2]);

                    BigInteger tempswap = numbers[indexOne];
                    numbers[indexOne] = numbers[indexTwo];
                    numbers[indexTwo] = tempswap;
                }
                else if (currentCommand == "multiply")
                {
                    int indexOne = int.Parse(comArg[1]);
                    int indexTwo = int.Parse(comArg[2]);

                    numbers[indexOne] = numbers[indexOne] * numbers[indexTwo];
                }
                else if (currentCommand == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
