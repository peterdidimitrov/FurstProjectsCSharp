namespace SantasSecretHelper
{
    using System;
    using System.Text.RegularExpressions;
    using System.Text;
    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*!(?<behavior>[G|N])!";
            int n = int.Parse(Console.ReadLine());

            string text;
            while ((text = Console.ReadLine()) != "end")
            {
                StringBuilder message = new StringBuilder();
                for (int i = 0; i <= text.Length - 1; i++)
                {
                    message.Append((char)(text[i] - n));
                }
                Regex regex = new Regex(pattern);
                var match = regex.Match(message.ToString());
                if (match.Groups["behavior"].Value == "G")
                {
                    Console.WriteLine(match.Groups["name"].Value);
                }
            }
        }
    }
}