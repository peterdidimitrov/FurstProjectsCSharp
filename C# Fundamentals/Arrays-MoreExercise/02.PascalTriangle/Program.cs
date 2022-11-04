using System;
using System.Linq;
namespace _02.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*The triangle may be constructed in the following manner: In row 0(the topmost row), there is a unique nonzero entry 
            1.Each entry of each subsequent row is constructed by adding the number above and to the left with the number above and to the right, 
            treating blank entries as 0.For example, the initial number in the first(or any other) row is 1(the sum of 0 and 1), 
            whereas the numbers 1 and 3 in the third row are added to produce the number 4 in the fourth row.
            If you want more info about it: https://en.wikipedia.org/wiki/Pascal's_triangle
            Print each row element separated with whitespace.*/

            int numberOfRows = int.Parse(Console.ReadLine());

            Console.WriteLine(1);

            if (numberOfRows == 1)
            {
                return;
            }

            int[] initialArray = new int[] { 1, 1 };
            Console.WriteLine(string.Join(" ", initialArray));

            if (numberOfRows == 2)
            {
                return;
            }

            else
            {
                for (int i = 0; i < initialArray.Length + 1; i++)
                {
                    int[] array = new int[initialArray.Length + 1];
                    array[0] = 1;
                    array[array.Length - 1] = 1;

                    for (int j = 1; j < array.Length - 1; j++)
                    {
                        array[j] = initialArray[j - 1] + initialArray[j];
                    }
                    Console.WriteLine(string.Join(" ", array));

                    initialArray = array;

                    if (initialArray.Length == numberOfRows)
                    {
                        break;
                    }
                }
            }
        }
    }
}
