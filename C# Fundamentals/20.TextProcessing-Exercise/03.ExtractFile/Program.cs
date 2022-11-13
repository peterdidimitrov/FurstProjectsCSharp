namespace _03.ExtractFile
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] separator = { @"\", "." };
            string[] input = Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"File name: {input[input.Length - 2]}");
            Console.WriteLine($"File extension: {input[input.Length - 1]}");
        }
    }
}