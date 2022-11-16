namespace _02.Race
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var regexName = @"(?<name>[A-Za-z])";
            var regexDistance = @"(?<distance>\d+)";
            
            var sumOfDigits = 0;
            
            var racersInfo = new Dictionary<string, int>();
            List<string> names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                var matchedNames = Regex.Matches(input, regexName);
                var matchedDigits = Regex.Matches(input, regexDistance);

                string currentName = string.Join("", matchedNames);
                string currentDistance = string.Join("", matchedDigits);

                sumOfDigits = 0;
                for (int i = 0; i < currentDistance.Length; i++)
                {
                    sumOfDigits += int.Parse(currentDistance[i].ToString());
                }
                if (names.Contains(currentName))
                {
                    if (!racersInfo.ContainsKey(currentName))
                    {
                        racersInfo.Add(currentName, sumOfDigits);
                    }
                    else
                    {
                        racersInfo[currentName] += sumOfDigits;
                    }
                } 
            }
            var winners = racersInfo.OrderByDescending(x => x.Value).Take(3);
            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x => x.Value)
                .Take(2).OrderBy(x => x.Value)
                .Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);

            foreach (var firstName in firstPlace)
            {
                Console.WriteLine($"1st place: {firstName.Key}");
            }
            foreach (var secondName in secondPlace)
            {
                Console.WriteLine($"2nd place: {secondName.Key}");
            }
            foreach (var thirdName in thirdPlace)
            {
                Console.WriteLine($"3rd place: {thirdName.Key}");
            }
        }
    }
}