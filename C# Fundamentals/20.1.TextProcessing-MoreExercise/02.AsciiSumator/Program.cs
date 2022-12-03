using System;
using System.Text;
namespace _02.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            int first = (int)firstChar;
            int second = (int)secondChar;
            
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > first && text[i] < second)
                {
                    sum += (int)text[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
