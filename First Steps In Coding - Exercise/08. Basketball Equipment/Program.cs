using System;

namespace _08._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tax = double.Parse(Console.ReadLine());
            double shoes = tax * 0.60;
            double suit = shoes * 0.80;
            double ball = suit * 0.25;
            double accesoars = ball * 0.20;

            double sum = tax + shoes + suit + accesoars + ball;
            Console.WriteLine(sum);
        }
    }
}
