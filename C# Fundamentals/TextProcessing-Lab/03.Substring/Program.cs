using System;

namespace _03.Substring
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();

            int index;
            while ((index = text.IndexOf(key)) != -1)
            {
                text = text.Remove(index, key.Length);
            }
            Console.Write(text);
        }
    }
}
