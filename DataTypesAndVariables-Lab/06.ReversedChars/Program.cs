using System;

namespace _06.ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char inputOne = char.Parse(Console.ReadLine());
            char inputTwo = char.Parse(Console.ReadLine());
            char inputThree = char.Parse(Console.ReadLine());

            Console.Write($"{inputThree} {inputTwo} {inputOne}");
        }
    }
}