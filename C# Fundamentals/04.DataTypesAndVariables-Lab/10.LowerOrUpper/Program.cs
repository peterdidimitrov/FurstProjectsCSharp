using System;

namespace _10.LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            int numLetter = letter;
            if (numLetter >= 65 && numLetter <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (numLetter >= 97 && numLetter <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
