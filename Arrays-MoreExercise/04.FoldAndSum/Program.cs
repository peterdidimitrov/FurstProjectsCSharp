using System;
using System.Linq;
namespace _04.FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read an array of 4 * k integers,
            //fold it like shown below, and print the sum of the upper and
            //lower two rows(each holding 2 * k integers):
            // Hints
            //•	Create the first row after folding:
            //the first k numbers reversed, followed by the last k numbers reversed.
            //•	Create the second row after folding: the middle 2 * k numbers.
            //•	Sum the first and the second rows.

            int[] inputArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int k = inputArray.Length / 4;
            int[] newArr = new int[2 * k];
 
            for (int i = 0; i < k; i++)
            {
                newArr[i] = inputArray[k - (i + 1)] + inputArray[k + i];
                newArr[newArr.Length - 1 - i] = inputArray[newArr.Length - 1 - i + k] + inputArray[(newArr.Length - 1 - i) + (k+2*i+1)];
            }
            Console.WriteLine(string.Join(" ", newArr));
              
        
        }
    }
}
