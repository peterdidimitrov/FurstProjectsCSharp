using System;

namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThre = int.Parse(Console.ReadLine());
            int min = GetTheSmalestNum(numberOne, numberTwo, numberThre);
            Console.WriteLine(min);
        }
        static int GetTheSmalestNum(int a, int b, int c)
        {
            int min = int.MaxValue;

            if (a < min)
            {
                min = a;
            }
            if (b < min)
            {
                min = b;
            }
            if (c < min)
            {
                min = c;
            }
            return min;
        }
    }
}
