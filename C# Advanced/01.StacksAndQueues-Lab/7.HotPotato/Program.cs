namespace _7.HotPotato
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(" ");
            int n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(kids);

            int tosses = 1;
            while (queue.Count > 1)
            {
                string currPlayer = queue.Dequeue();

                if (tosses == n)
                {
                    Console.WriteLine($"Removed {currPlayer}");
                    tosses = 1;
                    continue;
                }
                tosses++;
                queue.Enqueue(currPlayer);
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}