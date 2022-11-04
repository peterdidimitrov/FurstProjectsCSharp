using System;

namespace _03.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numOne = double.Parse(Console.ReadLine());
            double numTwo = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            bool isNumEqual = false;

            double subtraction = Math.Abs(numOne - numTwo);
            if (subtraction >= eps)
            {
                isNumEqual = false;
            }
            else
            {
                isNumEqual = true;
            }
            Console.WriteLine(isNumEqual);
        }
    }
}
