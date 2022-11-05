using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int sumOfEvenNum = 0;
            int sumOfOddNum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumOfEvenNum += numbers[i];
                }
                else
                {
                    sumOfOddNum += numbers[i];
                }
            }
            int difference = sumOfEvenNum - sumOfOddNum;
            Console.WriteLine(difference);
        }
    }
}
