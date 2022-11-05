using System;

namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = Math.Abs(int.Parse(Console.ReadLine()));
            int evenSum = GetSumOfEvenDigits(input);
            int oddSum = GetSumOfOddDigits(input);
            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);
            Console.WriteLine(result);
        }
        static int GetSumOfEvenDigits(int input)
        {
            int sum = 0;
            int digits = input;
            while (digits > 0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 == 0)
                {
                    sum += currentDigit;
                }
                digits = digits / 10;
            }

            return sum;
        }
        static int GetSumOfOddDigits(int input)
        {
            int sum = 0;
            int digits = input;
            while (digits > 0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 != 0)
                {
                    sum += currentDigit;
                }
                digits = digits / 10;
            }

            return sum;
        }
        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
