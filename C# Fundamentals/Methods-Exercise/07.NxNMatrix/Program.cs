using System;

namespace _07.NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            GetMatrix(number);
        }

        private static void GetMatrix(int number)
        {
            for (int row = 1; row <= number; row++)
            {
                for (int collum = 1; collum <= number; collum++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
