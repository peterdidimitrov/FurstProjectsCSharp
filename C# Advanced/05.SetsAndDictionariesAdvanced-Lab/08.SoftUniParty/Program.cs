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
            var allGuests = new HashSet<string>();
            var peopleWhoCame = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (Char.IsDigit(command[0]))
                {
                    vip.Add(command);
                    allGuests.Add(command);
                }
                else
                {
                    regular.Add(command);
                    allGuests.Add(command);
                }
            }
            command = String.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                peopleWhoCame.Add(command);
            }
            var peopleWhoNotCame = new List<string>();

            peopleWhoNotCame.Add(vip.ExceptWith(peopleWhoCame).ToString().ToList());

            foreach (var people in vip)
            {
                Console.WriteLine(people);
            }
        }
    }
}
