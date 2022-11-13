namespace _04.CaesarCipher
{
    using System;
    using System.Text;
    using System.Runtime;

    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder crypted = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                crypted.Append(Convert.ToChar(input[i] + 3));
            }

            Console.WriteLine(crypted);
        }
    }
}