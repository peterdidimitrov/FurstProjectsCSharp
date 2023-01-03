using System;
using System.Text;
using System.Linq;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            var newPass = new StringBuilder(pass);

            string commands;

            while ((commands = Console.ReadLine()) != "Complete")
            {
                string[] commArg = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];

                if (currCommand == "Make")
                {
                    string type = commArg[1];
                    int index = int.Parse(commArg[2]);

                    if (type == "Upper")
                    {
                        for (int i = 0; i < newPass.Length; i++)
                        {
                            char symbol = newPass[i];
                            char newSymbol = Char.ToUpper(newPass[i]);
                            if (i == index)
                            {
                                newPass.Replace(symbol, newSymbol, index, 1);
                            }
                        }
                        Console.WriteLine(newPass);
                    }
                    else if (type == "Lower")
                    {
                        for (int i = 0; i < pass.Length; i++)
                        {
                            char symbol = newPass[i];
                            char newSymbol = Char.ToLower(newPass[i]);
                            if (i == index)
                            {
                                newPass.Replace(symbol, newSymbol, index, 1);
                            }
                        }
                        Console.WriteLine(newPass);
                    }
                }
                else if (currCommand == "Insert")
                {
                    int index = int.Parse(commArg[1]);
                    if (index >= 0 && index <= newPass.Length - 1)
                    {
                        char ch = char.Parse(commArg[2]);
                        newPass.Insert(index, ch.ToString());
                        Console.WriteLine(newPass);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currCommand == "Replace")
                {
                    char ch = char.Parse(commArg[1]);
                    int value = int.Parse(commArg[2]);

                    if (newPass.ToString().Contains(ch))
                    {
                        int asciiValue = (int)ch;
                        int newValue = asciiValue + value;
                        char newChar = (char)newValue;
                        newPass.Replace(ch, newChar);
                        Console.WriteLine(newPass);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currCommand == "Validation")
                {
                   
                    if (newPass.Length < 8)
                    {
                        Console.WriteLine($"Password must be at least 8 characters long!");
                    }
                    if (newPass.ToString().Any(ch => !char.IsLetterOrDigit(ch) && ch != '_'))
                    {
                        Console.WriteLine($"Password must consist only of letters, digits and _!");
                    }
                    if (!newPass.ToString().Any(char.IsUpper))
                    {
                        Console.WriteLine($"Password must consist at least one uppercase letter!");
                    }
                    if (!newPass.ToString().Any(char.IsLower))
                    {
                        Console.WriteLine($"Password must consist at least one lowercase letter!");
                    }
                    if (!newPass.ToString().Any(char.IsDigit))
                    {
                        Console.WriteLine($"Password must consist at least one digit!");
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
