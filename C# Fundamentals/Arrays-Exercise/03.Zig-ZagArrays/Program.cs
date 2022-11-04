using System;
using System.Linq;
namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            string[] firstArray = new string[numOfLines];
            string[] secondArray = new string[numOfLines];
            

            for (int i = 0; i < numOfLines; i++)
            {
                string[] thirdArray = Console.ReadLine()
                        .Split(" ")
                        .ToArray();
                for (int j = 0; j < thirdArray.Length; j++)
                {
                    
                    if (i % 2 == 0)
                    {
                        if (j == 0)
                        {
                            firstArray[i] = thirdArray[0];
                        }
                        else
                        {
                            secondArray[i] = thirdArray[1];
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            firstArray[i] = thirdArray[1];
                        }
                        else
                        {
                            secondArray[i] = thirdArray[0];
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}
