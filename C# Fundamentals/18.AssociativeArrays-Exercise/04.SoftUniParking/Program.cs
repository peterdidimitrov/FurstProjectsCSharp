using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, string>();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArg[0];
                string userName = commandArg[1];

                if (command == "register")
                {
                    string licensePlateNumber = commandArg[2];
                    if (!users.ContainsKey(userName))
                    {
                        users.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        if (users.ContainsValue(licensePlateNumber))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {users[userName]}");
                        }
                    }
                }
                else
                {
                    if (!users.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        users.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
