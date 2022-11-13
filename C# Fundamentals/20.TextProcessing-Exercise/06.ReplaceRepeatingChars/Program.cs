namespace _06.ReplaceRepeatingChars
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.Write(input[0]);

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] != input[i + 1])
                {
                    Console.Write(input[i + 1]);
                }
            }
        }
    }
}