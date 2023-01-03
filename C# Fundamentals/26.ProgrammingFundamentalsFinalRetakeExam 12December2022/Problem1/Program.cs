using System;
using System.Text;
using System.Linq;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            var decipheredSkill = new StringBuilder(skill);

            string commands;
            while ((commands = Console.ReadLine()) != "For Azeroth")
            {
                string[] commArg = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];
                if (currCommand == "GladiatorStance" || currCommand == "DefensiveStance"
                    || currCommand == "Dispel" || currCommand == "Target")
                {
                    if (currCommand == "GladiatorStance")
                    {
                        for (int i = 0; i < decipheredSkill.Length; i++)
                        {
                            if (Char.IsLetter(decipheredSkill[i]))
                            {
                                decipheredSkill.Replace(decipheredSkill[i], char.ToUpper(decipheredSkill[i]));
                            }
                        }
                        Console.WriteLine(decipheredSkill);
                    }
                    else if (currCommand == "DefensiveStance")
                    {
                        for (int i = 0; i < decipheredSkill.Length; i++)
                        {
                            if (Char.IsLetter(decipheredSkill[i]))
                            {
                                decipheredSkill.Replace(decipheredSkill[i], char.ToLower(decipheredSkill[i]));
                            }
                        }
                        Console.WriteLine(decipheredSkill);
                    }
                    else if (currCommand == "Dispel")
                    {
                        int index = int.Parse(commArg[1]);
                        char letter = char.Parse(commArg[2]);

                        if (index >= 0 && index <= decipheredSkill.Length - 1)
                        {
                            decipheredSkill.Replace(decipheredSkill[index], letter, index, 1);
                            Console.WriteLine("Success!");
                        }
                        else
                        {
                            Console.WriteLine("Dispel too weak.");
                        }
                    }
                    else if (currCommand == "Target")
                    {
                        string type = commArg[1];
                        if (type == "Change")
                        {
                            string first = commArg[2];
                            string second = commArg[3];

                            if (decipheredSkill.ToString().Contains(first))
                            {
                                decipheredSkill.Replace(first, second);

                                Console.WriteLine(decipheredSkill);
                            }
                            else
                            {
                                Console.WriteLine(decipheredSkill);
                            }
                        }
                        else if (type == "Remove")
                        {
                            string substring = commArg[2];
                            if (decipheredSkill.ToString().Contains(substring))
                            {
                                int index = decipheredSkill.ToString().IndexOf(substring);
                                decipheredSkill.Remove(index, substring.Length);
                                
                                Console.WriteLine(decipheredSkill);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }
        }
    }
}
