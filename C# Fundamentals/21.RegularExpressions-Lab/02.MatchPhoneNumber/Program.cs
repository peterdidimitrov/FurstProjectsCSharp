namespace _02.MatchPhoneNumber
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var regex = @"\+359(?<separator>[ |-])2\k<separator>\d{3}\k<separator>\d{4}\b";
            string phones = Console.ReadLine();

            var phoneMathches = Regex.Matches(phones, regex);
            var mathchedPhones = phoneMathches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.Write(string.Join(", ", mathchedPhones));
        }
    }
}
