using System;
using System.Linq;
namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();

            bool isLengthValid = IsPasswordLengthValid(inputPassword);
            bool isPassAlphanumeric = IsPasswordAlphaNumeric(inputPassword);
            bool hasTwoDigits = IsPasswordContaingAtLeastTwoDigits(inputPassword);

            if (!isLengthValid)
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
            }

            if (!isPassAlphanumeric)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!hasTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isLengthValid && isPassAlphanumeric && hasTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool IsPasswordLengthValid(string inputText)
        {
            bool isValid = inputText.Length >= 6 && inputText.Length <= 10;
            return isValid;
        }

        static bool IsPasswordAlphaNumeric(string inputText)
        {
            if (!inputText.All(char.IsLetterOrDigit))
            {
                return false;
            }
            return true;
        }

        static bool IsPasswordContaingAtLeastTwoDigits(string password)
        {
            int digitsCnt = 0;
            foreach (char ch in password)
            {
                if (Char.IsDigit(ch))
                {
                    digitsCnt++;
                }
            }

            return digitsCnt >= 2;
        }
    }
}