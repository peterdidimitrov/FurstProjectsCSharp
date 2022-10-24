using System;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double furstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            double result = (double)GetFactorial(furstNum) / (double)GetFactorial(secondNum);
            Console.WriteLine($"{result:f2}");
        }
        static double GetFactorial(double number)
        {
            double n = number;
            for (double i = number - 1; i > 0; i--)
            {
                n *= i;
            }
            return n;
        }
    }
}