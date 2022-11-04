using System;
using System.Linq;
namespace _03.SafeManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] stringArray = Console.ReadLine()
                .Split();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] currentCommand = command.Split();
                if (currentCommand[0] == "Reverse")
                {
                    Array.Reverse(stringArray);
                }
                else if (currentCommand[0] == "Distinct")
                {
                    stringArray = stringArray
                        .Distinct()
                        .ToArray();
                }
                else if (currentCommand[0] == "Replace")
                {
                    int index = int.Parse(currentCommand[1]);
                    if (index < stringArray.Length && index >= 0)
                    {
                        stringArray[int.Parse(currentCommand[1])] = currentCommand[2];
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else 
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            Console.WriteLine(string.Join(", ", stringArray));
        }
    }
}
