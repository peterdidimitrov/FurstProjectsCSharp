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
            char[] separators = { ',', ' ' };
            List<string> names = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var regexName = @"(?<name>[A-Za-z])";
            var regexDistance = @"(?<distance>\d+)";

            var racersInfo = new Dictionary<string, int>();
            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                var existedNames = Regex.Matches(input, regexName);
                var existedDistance = Regex.Matches(input, regexDistance);

                string currentName = "";
                string currentDistance = "";

                foreach (Match item in existedNames)
                {
                    var name = item.Groups["name"].Value;
                    currentName += name;
                }
                foreach (Match item in existedDistance)
                {
                    var distance = item.Groups["distance"].Value;
                    currentDistance += distance;
                }
                if (names.Contains(currentName))
                {
                    if (!racersInfo.ContainsKey(currentName))
                    {
                        racersInfo.Add(currentName, int.Parse(currentDistance));
                    }
                    else
                    {
                        racersInfo[currentName] += int.Parse(currentDistance);
                    }
                }
            }
            List<string> finalists = new List<string>();

            foreach (var item in racersInfo.OrderByDescending(key => key.Value))
            {
                //Console.WriteLine($"{item.Key} -> {item.Value}");
                finalists.Add(item.Key);
            }

            Console.WriteLine($"1st place: {finalists[0]}");
            Console.WriteLine($"2nd place: {finalists[1]}");
            Console.WriteLine($"3rd place: {finalists[2]}");
        }
    }
}