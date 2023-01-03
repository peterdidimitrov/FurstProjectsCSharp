using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[a-z]{5,}[1-9]+)P@\$";
            var regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    Console.WriteLine("Registration was successful");
                    counter++;
                    string username = match.Groups[1].Value;
                    string password = match.Groups[2].Value;
                    Console.WriteLine($"Username: {username}, Password: {password}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }

            }

            Console.WriteLine($"Successful registrations: {counter}");
        }
    }
}
