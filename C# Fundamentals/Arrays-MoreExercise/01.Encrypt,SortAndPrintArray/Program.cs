using System;
using System.Linq;
using System.Text;

namespace _01.Encrypt_SortAndPrintArray
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Write a program that reads a sequence of strings from the console. Encrypt every string by summing:
            //•	The code of each vowel multiplied by the string length
            //•	The code of each consonant divided by the string length
            //Sort the number sequence in ascending order and print it on the console.
            //On the first line, you will always receive the number of strings you have to read.

            int stringNum = int.Parse(Console.ReadLine());
            int[] arrayOfSums = new int[stringNum];

            for (int i = 0; i < stringNum; i++)
            {
                int sum = 0;
                string strings = Console.ReadLine();


                byte[] asciiBytes = Encoding.ASCII.GetBytes(strings);
                for (int j = 0; j < asciiBytes.Length; j++)
                {
                    if (asciiBytes[j] == 65 || asciiBytes[j] == 69 || asciiBytes[j] == 73 || asciiBytes[j] == 79 || asciiBytes[j] == 85 ||
                        asciiBytes[j] == 97 || asciiBytes[j] == 101 || asciiBytes[j] == 105 || asciiBytes[j] == 111 || asciiBytes[j] == 117)
                    {
                        sum += asciiBytes[j] * strings.Length;
                    }
                    else
                    {
                        sum += asciiBytes[j] / strings.Length;
                    }
                }
                arrayOfSums[i] = sum;
            }
            Array.Sort(arrayOfSums);
            for (int i = 0; i < arrayOfSums.Length; i++)
            {
                Console.WriteLine(arrayOfSums[i]);
            }
            Array.Reverse(arrayOfSums);
            for (int k = 0; k < arrayOfSums.Length; k++)
            {
                Console.WriteLine(arrayOfSums[k]);
            }
        }
    }
}
