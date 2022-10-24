using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> statusOfPirateShip = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();
            List<int> statusOfWarShip = Console.ReadLine()
                 .Split('>')
                 .Select(int.Parse)
                 .ToList();

            int sectionMax = int.Parse(Console.ReadLine());
            bool isThePirateSchipSunken = false;

            string commands;
            while ((commands = Console.ReadLine()) != "Retire")
            {
                string[] comArg = commands.Split(' ');

                string currentCommand = comArg[0];

                if (currentCommand == "Fire")
                {
                    int index = int.Parse(comArg[1]);
                    int damage = int.Parse(comArg[2]);

                    if (index >= 0 && index <= statusOfWarShip.Count - 1)
                    {
                        statusOfWarShip[index] = statusOfWarShip[index] - damage;

                        if (statusOfWarShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCommand == "Defend")
                {
                    int startIndex = int.Parse(comArg[1]);
                    int endIndex = int.Parse(comArg[2]);
                    int damage = int.Parse(comArg[3]);

                    if (startIndex >= 0 && startIndex <= statusOfPirateShip.Count - 1
                        && endIndex >= 0 && endIndex <= statusOfPirateShip.Count - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            statusOfPirateShip[i] = statusOfPirateShip[i] - damage;
                            if (statusOfPirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                isThePirateSchipSunken = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCommand == "Repair")
                {
                    int index = int.Parse(comArg[1]);
                    int health = int.Parse(comArg[2]);

                    if (index >= 0 && index <= statusOfPirateShip.Count - 1)
                    {
                        statusOfPirateShip[index] = statusOfPirateShip[index] + health;

                        if (statusOfPirateShip[index] > sectionMax)
                        {
                            statusOfPirateShip[index] = sectionMax;
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (currentCommand == "Status")
                {
                    double minHealthCapacity = sectionMax * 0.2;
                    int counter = 0;

                    for (int i = 0; i < statusOfPirateShip.Count - 1; i++)
                    {
                        if (statusOfPirateShip[i] <= minHealthCapacity)
                        {
                            counter++;
                        }
                    }
                    Console.WriteLine($"{counter} sections need repair.");
                }
            }
            int pirateShipSum = statusOfPirateShip.Sum();
            int warShipSum = statusOfWarShip.Sum();

            if (!isThePirateSchipSunken)
            {
                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warShipSum}");
            }

        }
    }
}
