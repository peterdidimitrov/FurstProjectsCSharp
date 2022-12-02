using System;
using System.Text;
using System.Linq;

namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder activationKey = new StringBuilder(input);

            string commands;
            while ((commands = Console.ReadLine()) != "Generate")
            {
                string[] commArg = commands
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];
                if (currCommand == "Contains")
                {
                    string substring = commArg[1];
                    if (activationKey.ToString().Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (currCommand == "Flip")
                {
                    string typeOfCase = commArg[1];
                    int startIndex = int.Parse(commArg[2]);
                    int endIndex = int.Parse(commArg[3]);

                    if (typeOfCase == "Upper")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            activationKey.Insert(i, activationKey[i]
                                .ToString()
                                .ToUpper());
                            activationKey.Remove(i + 1, 1);
                        }
                        Console.WriteLine(activationKey);
                    }
                    else if (typeOfCase == "Lower")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            activationKey.Insert(i, activationKey[i]
                                .ToString()
                                .ToLower());
                            activationKey.Remove(i + 1, 1);
                        }
                        Console.WriteLine(activationKey);
                    }
                }
                else if (currCommand == "Slice")
                {
                    int startIndex = int.Parse(commArg[1]);
                    int endIndex = int.Parse(commArg[2]);
                    activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
