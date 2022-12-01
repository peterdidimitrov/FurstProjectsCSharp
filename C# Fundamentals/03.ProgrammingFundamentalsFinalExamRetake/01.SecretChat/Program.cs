using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder();
            message.Append(Console.ReadLine());
            string command;

            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] commArg = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];

                if (currCommand == "InsertSpace")
                {
                    int index = int.Parse(commArg[1]);

                    message.Insert(index, ' ');

                    Console.WriteLine(message);
                }
                else if (currCommand == "Reverse")
                {
                    string substring = commArg[1];
                    if (message.ToString().Contains(substring))
                    {
                        int startIndex = message.ToString().IndexOf(substring);
                        
                        message.Remove(startIndex, substring.Length);
                        char[] charArray = substring.ToCharArray();
                        Array.Reverse(charArray);
                      
                        message.Append(new string(charArray));

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (currCommand == "ChangeAll")
                {
                    string substring = commArg[1];
                    string replacement = commArg[2];

                    message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
