namespace _03.MatchDates
{
    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})(?<separator>[-.\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})\b";

            MatchCollection mathchedDates = Regex.Matches(input, pattern);

            foreach (Match date in mathchedDates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}