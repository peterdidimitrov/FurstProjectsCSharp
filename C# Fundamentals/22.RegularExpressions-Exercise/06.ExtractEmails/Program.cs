namespace _06.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"(\s)[A-Za-z0-9][\w*\-\.]*[A-Za-z0-9]@[A-za-z]+([.-][A-Za-z]+)+\b";

            string input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            foreach (Match validMail in matches)
            {
                Console.WriteLine(validMail);
            }
        }
    }
}