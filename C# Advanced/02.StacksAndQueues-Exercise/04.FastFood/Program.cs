namespace _04.FastFood
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>(orders);

            int orderedFood = 0;

            Console.WriteLine(queue.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                if (quantity >= orderedFood + queue.Peek())
                {
                    orderedFood += queue.Peek();
                    queue.Dequeue();
                }
                else
                {
                    continue;
                }
            }
            if (queue.Count() > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}