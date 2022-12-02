using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(::|\*\*)(?<name>[A-Z][a-z]{2,})\1";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);
            BigInteger coolThreshold = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    coolThreshold *= int.Parse(input[i].ToString());
                }
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (Match match in matches)
            {
                BigInteger cool = 0;
                var name = match.Groups["name"].Value;
                for (int i = 0; i < name.Length; i++)
                {
                    cool += (BigInteger)name[i];
                }
                if (cool >= coolThreshold)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
