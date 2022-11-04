using System;

namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double totalSpend = 0;

            double outFall = 39.99;
            double cS = 15.99;
            double zplinter = 19.99;
            double honored = 59.99;
            double roverWatch = 29.99;
            double roverWatchOriginsEdition = 39.99;


            string command;
            while ((command = Console.ReadLine()) != "Game Time")
            {
                    switch (command)
                    {
                        case "OutFall 4":
                            if (currentBalance >= outFall)
                            {
                                currentBalance -= outFall;
                                totalSpend += outFall;
                                Console.WriteLine($"Bought {command}");
                            }
                            else 
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "CS: OG":
                            if (currentBalance >= cS)
                            {
                                currentBalance -= cS;
                                totalSpend += cS;
                                Console.WriteLine($"Bought {command}");
                            }
                            else 
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "Zplinter Zell":
                            if (currentBalance >= zplinter)
                            {
                                currentBalance -= zplinter;
                                totalSpend += zplinter;
                                Console.WriteLine($"Bought {command}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "Honored 2":
                            if (currentBalance >= honored)
                            {
                                currentBalance -= honored;
                                totalSpend += honored;
                                Console.WriteLine($"Bought {command}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "RoverWatch":
                            if (currentBalance >= roverWatch)
                            {
                                currentBalance -= roverWatch;
                                totalSpend += roverWatch;
                                Console.WriteLine($"Bought {command}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "RoverWatch Origins Edition":
                            if (currentBalance >= roverWatchOriginsEdition)
                            {
                                currentBalance -= roverWatchOriginsEdition;
                                totalSpend += roverWatchOriginsEdition;
                                Console.WriteLine($"Bought {command}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        default:
                            Console.WriteLine("Not Found");
                            break;
                    }
                
        }
            //double difference = currentBalance - totalSpend;
            if (currentBalance > 0)
            {
                Console.WriteLine($"Total spent: ${totalSpend:f2}. Remaining: ${currentBalance:f2}");
            }
            else
            {
                Console.WriteLine("Out of money!");
            }
        }
    }
}
