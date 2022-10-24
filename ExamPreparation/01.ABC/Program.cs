using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.ABC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine()
                       .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                       .ToList();

            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] comArg = commands
                    .Split(" - ")
                    .ToArray();
                string currentCom = comArg[0];
                string currentPhone = comArg[1];
                if (currentCom == "Add")
                {
                    if (!phones.Contains(currentPhone))
                    {
                        phones.Add(currentPhone);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCom == "Remove")
                {
                    if (phones.Contains(comArg[1]))
                    {
                        phones.Remove(comArg[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCom == "Bonus phone")
                {

                    string[] oldPhoneNewPhone = comArg[1].Split(":").ToArray();

                    string oldPhone = oldPhoneNewPhone[0];
                    string newPhone = oldPhoneNewPhone[1];

                    for (int i = 0; i < phones.Count; i++)
                    {
                        if (phones[i] == oldPhone)
                        {
                            phones.Insert(i + 1, newPhone);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (currentCom == "Last")
                {
                    string phone = comArg[1];

                    if (!phones.Contains(phone))
                    {
                        continue;
                    }
                    else
                    {
                        phones.Remove(phone);
                        phones.Add(phone);
                    }


                }
            }


            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
