using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine()
                .Split("|")
                .ToList();

            int totalHealth = 100;
            int totalBitCoins = 0;
            int roomCounter = 0;

            for (int i = 0; i < rooms.Count; i++)
            {
                string[] command = rooms[i].Split();

                string comArg = command[0];
                int value = int.Parse(command[1]);

                roomCounter++;

                if (comArg == "potion")
                {
                    int amount = 100 - totalHealth;
                    totalHealth += value;

                    if (totalHealth > 100)
                    {
                        totalHealth = 100;
                        Console.WriteLine($"You healed for {amount} hp.");
                        Console.WriteLine($"Current health: {totalHealth} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {value} hp.");
                        Console.WriteLine($"Current health: {totalHealth} hp.");
                    }
                }
                else if (comArg == "chest")
                {
                    totalBitCoins += value;
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    totalHealth -= value;
                    if (totalHealth <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {comArg}.");
                        Console.WriteLine($"Best room: {roomCounter}");
                        return;
                    }
                    else if (totalHealth >= 0)
                    {
                        Console.WriteLine($"You slayed {comArg}.");
                    }
                }
            }
            if (roomCounter == rooms.Count)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {totalBitCoins}");
                Console.WriteLine($"Health: {totalHealth}");
            }
        }
    }
}
