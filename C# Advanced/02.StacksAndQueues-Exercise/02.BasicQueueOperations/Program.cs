namespace _02.BasicQueueOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArg = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int n = inputArg[0];
            int numbersToPop = inputArg[1];
            int numberToLook = inputArg[2];

            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>(numbers);

            for (int i = 0; i < numbersToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numberToLook))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count <= 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}