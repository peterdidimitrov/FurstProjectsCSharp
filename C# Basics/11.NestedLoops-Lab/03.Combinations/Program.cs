using System;

namespace _03.Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int combination = 0;

            for (int furstNum = 0; furstNum <= number; furstNum++)
            {
                for (int secondNum = 0; secondNum <= number; secondNum++)
                {
                    for (int thirdNum = 0; thirdNum <= number; thirdNum++)
                    {
                        if (furstNum + secondNum + thirdNum == number)
                        {
                            combination++;
                        }
                    }
                }
            }
            Console.WriteLine(combination);
        }
    }
}
