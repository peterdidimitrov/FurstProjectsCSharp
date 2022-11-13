namespace _06.ReplaceRepeatingChars
{
    using System;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            output.Append(input[0]);

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] != input[i + 1])
                {
                    output.Append(input[i + 1]);
                }
            }

            Console.WriteLine(output);
        }
    }
}