using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCarts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayerCarts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (firstPlayerCarts[0] > secondPlayerCarts[0])
                {
                    firstPlayerCarts.Add(secondPlayerCarts[0]);
                    firstPlayerCarts.Add(firstPlayerCarts[0]);
                }
                else if (firstPlayerCarts[0] < secondPlayerCarts[0])
                {
                    secondPlayerCarts.Add(firstPlayerCarts[0]);
                    secondPlayerCarts.Add(secondPlayerCarts[0]);
                }

                firstPlayerCarts.Remove(firstPlayerCarts[0]);
                secondPlayerCarts.Remove(secondPlayerCarts[0]);

                if (firstPlayerCarts.Count == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {secondPlayerCarts.Sum()}");
                    break;
                }
                if (secondPlayerCarts.Count == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {firstPlayerCarts.Sum()}");
                    break;
                }
            }
        }
    }
}
