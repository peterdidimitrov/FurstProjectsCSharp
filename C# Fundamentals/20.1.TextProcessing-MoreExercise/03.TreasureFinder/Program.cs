using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternType = @"\&(?<type>[A-Za-z]+)\&";
            string patternCoordinates = @"\<(?<coordinates>\w+)\>";
            int[] key = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string text;
            while ((text = Console.ReadLine()) != "find")
            {
                StringBuilder decryptedMessage = new StringBuilder();
                int secondIndex = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (secondIndex == key.Length)
                    {
                        secondIndex = 0;
                    }
                    char currentChar = (char)((int)text[i] - key[secondIndex]);
                    decryptedMessage.Append(currentChar);
                    secondIndex++;
                }
                Regex regexType = new Regex(patternType);
                Regex regexCoordinates = new Regex(patternCoordinates);
                
                Match match = regexType.Match(decryptedMessage.ToString());
                Match match1 = regexCoordinates.Match(decryptedMessage.ToString());

                string type = match.Groups["type"].Value;
                string coordinates = match1.Groups["coordinates"].Value;
                
                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
