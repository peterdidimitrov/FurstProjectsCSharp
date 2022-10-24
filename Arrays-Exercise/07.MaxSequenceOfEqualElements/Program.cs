using System;
using System.Linq;
namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int counter = 0;
            int winnerCounter = 0;  
            int index = 0;
            string nums = string.Empty;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    if (counter > winnerCounter)
                    {
                        winnerCounter = counter;
                        index = i;
                        nums = numbers[i].ToString();
                    }
                }
                else
                {
                    counter = 0;
                }
            }
            for (int i = 0; i <= winnerCounter; i++)
            {
                Console.Write(nums + " ");
            }
        }
    }
}
