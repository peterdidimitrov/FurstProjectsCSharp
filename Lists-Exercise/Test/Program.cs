using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                    .Split()
                    .ToList();
            List<string> newListOfGuests = new List<string>();
            newListOfGuests.Add("Petyr");
            newListOfGuests.Add("Dimo");

            for (int i = 0; i < guests.Count; i++)
            {
                if (newListOfGuests.Contains(guests[i]))
                {
                    newListOfGuests.(guests[i]);
                }

            }
            Console.WriteLine(string.Join(Environment.NewLine, newListOfGuests));
        }
    }
}
