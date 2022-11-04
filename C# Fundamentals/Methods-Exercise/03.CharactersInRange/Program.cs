using System;

namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char furstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            if (furstChar > secondChar)
            {
                char copyChar = furstChar;
                furstChar = secondChar;
                secondChar = copyChar;
            }

            string chars = GetCharsBetweenTwoChars(furstChar, secondChar);
            Console.WriteLine(chars);

        }

        static string GetCharsBetweenTwoChars(char furstChar, char secondChar)
        {
            string chars = string.Empty;
            for (int i = (int)furstChar + 1; i < (int)secondChar; i++)
            {
                chars += (char)i + " ";
            }
            return chars;
        }
    }
}