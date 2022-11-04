using System;

namespace _02.PrintNumbersInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());
            // Print the elements from the last to the first
            for (int i = n - 1; i >= 0; i--)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
