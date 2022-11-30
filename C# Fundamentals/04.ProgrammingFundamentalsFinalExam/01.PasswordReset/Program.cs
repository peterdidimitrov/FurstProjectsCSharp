using System;
using System.Text;

namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder password = new StringBuilder();
            password.Append(input);

            string commands;

            while ((commands = Console.ReadLine()) != "Done")
            {
                string[] commArg = commands
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currComm = commArg[0];

                if (currComm == "TakeOdd")
                {
                    StringBuilder newPassword = new StringBuilder();
                    for (int i = 1; i < password.Length; i++)
                    {
                        char letter = password[i];
                        if (i % 2 == 1)
                        {
                            newPassword.Append(letter);
                        }
                    }
                    password = newPassword;
                    Console.WriteLine(password);
                }
                else if (currComm == "Cut")
                {
                    int startIndex = int.Parse(commArg[1]);
                    int length = int.Parse(commArg[2]);

                    password.Remove(startIndex, length);

                    Console.WriteLine(password);
                }
                else if (currComm == "Substitute")
                {
                    string substring = commArg[1];
                    string substitute = commArg[2];

                    if (password.ToString().Contains(substring))
                    {
                        password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
