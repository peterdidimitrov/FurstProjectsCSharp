using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _03.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Fibonacci sequence is quite a famous sequence of numbers.
            //Each member of the sequence is calculated from the sum of the two previous elements.
            //The first two elements are 1, 1.Therefore the sequence goes like 1, 1, 2, 3, 5, 8, 13, 21, 34…
            //The following sequence can be generated with an array, but that’s easy, so your task is to implement recursively.
            //So if the function GetFibonacci(n) returns the n’th Fibonacci number we can express it using GetFibonacci(n) =
            //GetFibonacci(n - 1) + GetFibonacci(n - 2).
            //However, this will never end and in a few seconds, a StackOverflow Exception is thrown.
            //For the recursion to stop it has to have a “bottom”.
            //The bottom of the recursion is GetFibonacci(2) should return 1 and GetFibonacci(1) should return 1.

            int positionInFibonacciSequence = int.Parse(Console.ReadLine());
            int[] fibonacciSequence = new int[50];

            fibonacciSequence[0] = 1;
            fibonacciSequence[1] = 1;

            if (positionInFibonacciSequence > 2)
            {
                for (int i = 2; i < positionInFibonacciSequence; i++)
                {
                    fibonacciSequence[i] = fibonacciSequence[i - 1] + fibonacciSequence[i - 2];
                }
            }
            Console.WriteLine(fibonacciSequence[positionInFibonacciSequence - 1]);
        }
    }
}
