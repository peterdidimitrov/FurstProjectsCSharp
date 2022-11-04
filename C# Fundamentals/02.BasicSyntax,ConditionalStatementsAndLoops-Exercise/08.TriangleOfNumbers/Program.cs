using System;

namespace _08.TriangleOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            for (int rows = 1; rows <= number; rows++)
            {
                if (type == "Isosceles")
                {
                    int spacesCount = number - rows;
                    for (int spaces = 1; spaces <= spacesCount; spaces++)
                    {
                        Console.Write(" ");
                    }
                }
                for (int colums = 1; colums <= rows; colums++)
                {
                    Console.Write(rows + " ");    
                }
                        Console.WriteLine();
            }
         }
        }
    }
