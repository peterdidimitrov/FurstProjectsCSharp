using System;

namespace _05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            
            string decriptedWord = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                char letters = char.Parse(Console.ReadLine());
                char curentChar = (char)((int)letters + key);
                decriptedWord += curentChar;

            }
            Console.WriteLine(decriptedWord);
        }
    }
}
