using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> finalDestinations = new List<string>();

            string pattern = @"(=|/)(?<destination>[A-Z][A-Za-z]{2,})\1";
            int travelPoints = 0;
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection destinations = regex.Matches(input);
            

            foreach (Match match in destinations)
            {
                string destination = match.Groups["destination"].Value;
                
                travelPoints += destination.Length;
                finalDestinations.Add(destination);
            }
            Console.WriteLine($"Destinations: {string.Join(", ", finalDestinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
