using System;

namespace _01.SignOfIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SineOfIntegerNumbers();
        }

        private static void SineOfIntegerNumbers()
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero. ");
            }
            else if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
        }
    }
}
