namespace _05.FashionBoutique
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValues = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int capacityOfRack = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(clothesValues);

            int rackCounter = 1;
            int currCapacity = 0;

            int clothesCount = clothesValues.Length;

            for (int i = 0; i < clothesCount; i++)
            {
                if (currCapacity + stack.Peek() <= capacityOfRack)
                {
                    currCapacity += stack.Pop();
                }
                else
                {
                    rackCounter++;
                    currCapacity = 0;
                    currCapacity += stack.Pop();
                }
            }
            Console.WriteLine(rackCounter);
        }
    }
}