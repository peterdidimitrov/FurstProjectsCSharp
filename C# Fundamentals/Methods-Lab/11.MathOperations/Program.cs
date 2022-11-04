using System;

namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            double result = Calculate(a, @operator, b);
            Console.WriteLine(result);
            
        }
        static double Calculate(int a, string @operator, int b)
        {
            double result = 0;
            switch (@operator)
            {
                case "/":
                    result += a / b;
                    break;
                case "*":
                    result += a * b;
                    break;
                case "+":
                    result += a + b;
                    break;
                case "-":
                    result += a - b;
                    break;
            }
            return result;
        }
    }
}
