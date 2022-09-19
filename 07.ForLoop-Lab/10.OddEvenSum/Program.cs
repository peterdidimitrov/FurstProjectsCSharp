using System;

namespace _10.OddEvenSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numNumber = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < numNumber; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i % 2 == 1)
                {
                    sumOdd += number;
                }
                else
                {
                    sumEven += number;
                }
            }
            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven - sumOdd)}");
            }
        }
    }
}
