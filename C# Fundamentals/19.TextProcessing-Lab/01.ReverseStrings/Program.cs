using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ReverseStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string word;
            while ((word = Console.ReadLine()) != "end")
            {
                string reversedWord = Reverse(word);
                Console.WriteLine($"{word} = {reversedWord}");
            }
        }

        static string Reverse(string word)
        {
            char[] cArray = word.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}

