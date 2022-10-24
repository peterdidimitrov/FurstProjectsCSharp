using System;

namespace _12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            int currentNum = 0;
            bool isSpecialNum = false;

            for (int number = 1; number <= input; number++)
            {
                currentNum = number;
                while (number > 0)
                {
                    sum += number % 10;
                    number = number / 10;
                }
                isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", currentNum, isSpecialNum);
                sum = 0;
                number = currentNum;
            }

        }
    }
}
