using System;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculateTheSum(Console.ReadLine(), int.Parse(Console.ReadLine()));
        }

        static void CalculateTheSum(string product, int quantity)
        {
            double sum = 0;
            switch (product)
            {
                case "coffee":
                    sum += quantity * 1.5;
                    break;
                case "water":
                    sum += quantity * 1;
                    break;
                case "coke":
                    sum += quantity * 1.4;
                    break;
                case "snacks":
                    sum += quantity * 2;
                    break;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}