using System;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfWagos = int.Parse(Console.ReadLine());
            int[] passengers = new int[numOfWagos];
            int sum = 0;

            for (int i = 0; i < numOfWagos; i++)
            {
                passengers[i] = int.Parse(Console.ReadLine());
                sum += passengers[i];
            }
            for (int j = 0; j < passengers.Length; j++)
            {
                Console.Write($"{passengers[j]} ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
