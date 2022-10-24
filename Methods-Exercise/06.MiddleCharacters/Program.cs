using System;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string chars = GetTheMiddleChars(str);
            Console.WriteLine(chars);
        }
        static string GetTheMiddleChars(string str)
        {
            string chars = string.Empty;

            if (str.Length % 2 == 0)
            {
                chars += str[str.Length / 2 - 1];
                chars += str[str.Length / 2];
            }
            else
            {
                chars += str[(int)(str.Length / 2)];
            }
            return chars;
        }
    }
}
