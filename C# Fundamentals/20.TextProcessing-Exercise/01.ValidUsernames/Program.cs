namespace _01.ValidUsernames
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                bool isLengthValid = IsUserNameLengthValid(input[i]);
                bool isUserNameContaingValidSymbols = IsUserNameContaingOnlyValidSymbols(input[i]);

                if (isLengthValid && isUserNameContaingValidSymbols)
                {
                    Console.WriteLine(input[i]);
                }
            }
        }

        static bool IsUserNameLengthValid(string userName)
        {
            bool isValid = userName.Length >= 3 && userName.Length <= 16;
            return isValid;
        }

        static bool IsUserNameContaingOnlyValidSymbols(string userName)
        {
            int digitsCnt = 0;
            foreach (char ch in userName)
            {
                if (ch == '-' || ch == '_' || char.IsDigit(ch) || char.IsLetter(ch))
                {
                    digitsCnt++;
                }
            }
            return digitsCnt == userName.Length;
        }
    }
}