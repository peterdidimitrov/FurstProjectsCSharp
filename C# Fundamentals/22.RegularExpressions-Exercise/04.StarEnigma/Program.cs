namespace _04.StarEnigma
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var regex = @"@(?<name>[A-z]+)[^\@\-\!\:\>]*:(?<population>[\d]+)[^\@\-\!\:\>]*!(?<type>[A,D])![^\@\-\!\:\>]*->(?<count>[\d]+)";

            int numOfMassages = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < numOfMassages; i++)
            {
                string encryptedMessages = Console.ReadLine();
                int sum = encryptedMessages.ToLower().Count(x => x == 's' || x == 't' || x == 'a' || x == 'r');

                string decryptedMassage = string.Empty;

                foreach (var symbol in encryptedMessages)
                {
                    decryptedMassage += (char)(symbol - sum);
                }

                var matches = Regex.Match(decryptedMassage, regex);

                if (matches.Success)
                {
                    string planetName = matches.Groups["name"].Value;
                    char type = char.Parse(matches.Groups["type"].Value);

                    if (type != 'A')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                    else
                    {
                        attackedPlanets.Add(planetName);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.OrderBy(x => x).ToList().ForEach(planetName => Console.WriteLine($"-> {planetName}"));
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.OrderBy(x => x).ToList().ForEach(planetName => Console.WriteLine($"-> {planetName}"));
        }
    }
}