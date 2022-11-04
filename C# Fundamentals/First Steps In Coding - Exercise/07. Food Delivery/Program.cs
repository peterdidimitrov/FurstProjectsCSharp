using System;

namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double chickenMenu = double.Parse(Console.ReadLine());
            double fichMenu = double.Parse(Console.ReadLine());
            double vegiMenu = double.Parse(Console.ReadLine());

            double sum = chickenMenu * 10.35 + fichMenu * 12.40 + vegiMenu * 8.15;
            double desert = sum * 0.20;
            double totalSum = sum + desert + 2.50;

            Console.WriteLine(totalSum);
        }
    }
}
