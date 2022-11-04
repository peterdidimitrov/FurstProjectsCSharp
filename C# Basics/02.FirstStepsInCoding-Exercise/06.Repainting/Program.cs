using System;

namespace _06._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double naylonQuontyty = double.Parse(Console.ReadLine());
            double paintQuontyty = double.Parse(Console.ReadLine());
            double tinerQuontyty = double.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double sum = (naylonQuontyty + 2) * 1.50 + (paintQuontyty * 1.10) * 14.50 + (tinerQuontyty * 5) + 0.40;
            double totalSum = sum + (sum * 0.30) * hours;


            Console.WriteLine(totalSum);
        }
    }
}