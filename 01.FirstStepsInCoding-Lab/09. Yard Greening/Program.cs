using System;

namespace _09._Yard_Greening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            double sum = area * 7.61;
            double discount = sum * 0.18;
            double totalSum = sum - discount;

            Console.WriteLine($"The final price is: {totalSum} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
