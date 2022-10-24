using System;

namespace _4.RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int range = 2; range <= number; range++)
            {
                bool isTheNumPrime = true;
                for (int devider = 2; devider < range; devider++)
                {
                    if (range % devider == 0)
                    {
                        isTheNumPrime = false;
                        break;
                    }
                }
                if (isTheNumPrime == true)
                {
                    Console.WriteLine($"{range} -> true");
                }
                else
                {
                    Console.WriteLine($"{range} -> false");
                }    
                
            }

        }
    }
}
