using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@|#])(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();

            var matches = regex.Matches(input);
            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            List<string> mirrorWords = new List<string>();
            foreach (Match match in matches)
            {
                var firstWord = match.Groups["firstWord"].Value;
                var secondWord = match.Groups["secondWord"].Value;

                char[] charArray = secondWord.ToCharArray();
                Array.Reverse(charArray);
                string reversedSecondWord = new string(charArray);

                if (firstWord == reversedSecondWord)
                {
                    mirrorWords.Add($"{firstWord} <=> {secondWord}");
                }
            }
            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
