using System;
using System.Text;
using System.Linq;

namespace _01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder();

            string input = Console.ReadLine();

            message.Append(input);
            string commands;

            while ((commands = Console.ReadLine()) != "Travel")
            {
                string[] commArg = commands.Split(":", StringSplitOptions.RemoveEmptyEntries);
                if (commands.Contains("Add"))
                {
                    if (int.Parse(commArg[1]) >= 0 && int.Parse(commArg[1]) <= message.Length - 1)
                    {
                        message.Insert(int.Parse(commArg[1]), commArg[2]);
                        Console.WriteLine(message);
                    }
                }
                else if (commands.Contains("Remove"))
                {
                    int startIndex = int.Parse(commArg[1]);
                    int endIndex = int.Parse(commArg[2]);
                    if (startIndex <= endIndex &&
                        startIndex >= 0 &&
                        startIndex <= message.Length - 1 &&
                        endIndex >= 0 &&
                        endIndex <= message.Length - 1)
                    {
                        int length = int.Parse(commArg[2]) - startIndex + 1;
                        message.Remove(startIndex, length);
                    }
                    Console.WriteLine(message);
                }
                else if (commands.Contains("Switch"))
                {
                    string oldString = commArg[1];
                    string newString = commArg[2];
                    
                    if (message.ToString().Contains(oldString))
                    {
                        message.Replace(oldString, newString);
                    }
                    Console.WriteLine(message);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {message}");
        }
    }
}
