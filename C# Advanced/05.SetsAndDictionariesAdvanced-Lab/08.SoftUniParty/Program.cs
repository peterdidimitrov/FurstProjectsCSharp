namespace _08.SoftUniParty
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var regular = new HashSet<string>();
            var vip = new HashSet<string>();
            var peopleWhoCame = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (Char.IsDigit(command[0]))
                {
                    vip.Add(command);
                }
                else
                {
                    regular.Add(command);
                }
            }
            command = String.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                peopleWhoCame.Add(command);
            }
            var peopleWhoNotCame = new List<string>();

            vip.ExceptWith(peopleWhoCame);
            regular.ExceptWith(peopleWhoCame);

            foreach (var people in vip)
            {
                peopleWhoNotCame.Add(people);
            }
            foreach (var people in regular)
            {
                peopleWhoNotCame.Add(people);
            }
            Console.WriteLine(peopleWhoNotCame.Count);
            foreach (var people in peopleWhoNotCame)
            {
                Console.WriteLine(people);
            }
        }
    }
}
