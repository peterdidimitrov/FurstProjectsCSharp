using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[@#]+(?<color>[a-z]{3,})[@#]+\W*\/+(?<amount>[0-9]+)\/+";
            
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            var matches = regex.Matches(input);
            foreach (Match eggs in matches)
            {
                var color = eggs.Groups["color"].Value;
                var amount = eggs.Groups["amount"].Value;
                Console.WriteLine($"You found {amount} {color} eggs!");
            }
        }
    }
}
