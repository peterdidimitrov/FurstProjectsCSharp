using System;

namespace _03.ExactSumOfRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNum = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 1; i <= countOfNum; i++)
            {
                decimal currentNum = decimal.Parse(Console.ReadLine());
                sum = sum + currentNum;
            }

            Console.WriteLine($"{sum}");
        }
    }
}
