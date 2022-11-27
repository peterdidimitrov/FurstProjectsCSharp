using System;
using System.Collections.Generic;
using System.Text;

namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            StringBuilder decryptedMessage = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                decryptedMessage.Append(message[i]);
            }

            string commands;
            while ((commands = Console.ReadLine()) != "Decode")
            {
                string[] commandArg = commands
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                if (commandArg[0] == "Move")
                {
                    for (int i = 0; i < int.Parse(commandArg[1]); i++)
                    {
                        decryptedMessage = decryptedMessage.Append(decryptedMessage[i]);
                    }
                    decryptedMessage = decryptedMessage.Remove(0, int.Parse(commandArg[1]));
                }
                else if (commandArg[0] == "Insert")
                {
                    decryptedMessage = decryptedMessage.Insert(int.Parse(commandArg[1]), commandArg[2]);
                }
                else if (commandArg[0] == "ChangeAll")
                {
                    decryptedMessage = decryptedMessage.Replace(commandArg[1], commandArg[2]);
                }
            }
            Console.WriteLine($"The decrypted message is: {decryptedMessage}");
        }
    }
}
