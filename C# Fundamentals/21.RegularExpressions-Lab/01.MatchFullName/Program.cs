using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patern = @"\b[A-Z][a-z]+[ ][A-Z][a-z]+\b";

            MatchCollection mathchedNames = Regex.Matches(input, patern);

            foreach (Match name in mathchedNames)
            {
                Console.Write(name.Value + " ");
            }
        }
    }
}
