using System;

namespace _04.TextFilter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char[] separators = new char[] { ' ', ',', '.' };
            string[] banWords = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var banWord in banWords)
            {
                if (text.Contains(banWord))
                {
                    text = text.Replace(banWord, new string('*', banWord.Length));
                }
            }
            Console.Write(text);
        }
    }
}
