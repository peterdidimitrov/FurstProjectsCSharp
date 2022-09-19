using System;

namespace _05._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pensNum = double.Parse(Console.ReadLine());
            double markersNum = double.Parse(Console.ReadLine());
            double litters = double.Parse(Console.ReadLine());
            double persentDiscount = double.Parse(Console.ReadLine());

            double sum = pensNum * 5.80 + markersNum * 7.20 + litters * 1.20;
            double totalSum = sum - sum * persentDiscount / 100;
            Console.WriteLine(totalSum);
        }
    }
}
