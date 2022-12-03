using System;
using System.Text.RegularExpressions;

namespace _01.ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string patternForName = @"\@(?<name>[A-Za-z]+)\|";
            string patternForAge = @"\#(?<age>\d+)\*";

            Regex patternForNameRegex = new Regex(patternForName);
            Regex patternForAgeRegex = new Regex(patternForAge);

            for (int i = 0; i < lines; i++)
            {
                string text = Console.ReadLine();
                Match match = patternForNameRegex.Match(text);
                Match match1 = patternForAgeRegex.Match(text);

                string name = match.Groups["name"].Value;
                string age = match1.Groups["age"].Value;
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
