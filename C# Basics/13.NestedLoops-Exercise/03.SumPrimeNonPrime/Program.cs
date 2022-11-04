using System;

namespace Temp
{
    class Program
    {
        public static bool IsPrime(int number)
        {
            // Object finding if number Prime or Not!!
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0 && i != number)
                {
                    return false;
                }
            }

            return true;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            // Variables and booleans for acumolation of the prime and non prime numbers
            int primeNum = 0;
            int nonPrimeNum = 0;
            // a loop to colect unspecified number of digits
            while (input != "stop")
            {
                int numbers = int.Parse(input);
                // Prime non  Prime separation check
                if (IsPrime(numbers))
                {
                    if (numbers >= 0)
                    {
                        primeNum += numbers;
                    }
                }
                else
                {
                    if (numbers >= 0)
                    {
                        nonPrimeNum += numbers;
                    }
                }
                input = Console.ReadLine();

                if (numbers < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeNum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNum}");
        }
    }
}