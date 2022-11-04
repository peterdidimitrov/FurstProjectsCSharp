using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Numerics;
namespace _02.ManipulateArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will receive an array of strings and you have to execute some command upon it.
            //You can receive three types of commands:
            //•	Reverse – reverse the array
            //•	Distinct – delete all non - unique elements from the array
            //•	Replace {index} {string} – replace the element at the given index with the string, which will be given to you

            //Input
            //•	On the first line, you will receive the string array
            //•	On the second line, you will receive n – the number of lines, which will follow
            //•	On the next n lines – you will receive commands

            //Output
            //At the end print the array in the following format:
            //   { 1st element}, { 2nd element}, { 3rd element} … { nth element}

            //Constraints
            //•	For separator will be used only single whitespace
            //•	n will be integer in the interval[1…100]

            string[] stringArray = Console.ReadLine()
                .Split(' ');
            

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ');
                if (command[0] == "Reverse")
                {
                    Array.Reverse(stringArray);
                }
                else if (command[0] == "Distinct")
                {
                    stringArray = stringArray
                        .Distinct()
                        .ToArray();
                }
                else
                {
                    stringArray[int.Parse(command[1])] = command[2];
                }
            }
            Console.WriteLine(string.Join(", ", stringArray));
        }
    }
}
