using System;

namespace _01.Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int houers = 0; houers < 24; houers++)
            {
                for (int minets = 0;  minets < 60;  minets++)
                {
                    Console.WriteLine($"{houers}:{minets}");
                }
            }
        }
    }
}
