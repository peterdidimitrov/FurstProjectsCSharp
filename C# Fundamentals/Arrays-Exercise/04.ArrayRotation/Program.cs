using System;
using System.Linq;
namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            int rotations = int.Parse(Console.ReadLine());
            rotations %= array.Length;

            for (int i = 0; i < rotations; i++)
            {
                int furstNum = array[0];
                for (int j = 1; j < array.Length; j++)
                {
                    array[j - 1] = array[j];
                }
                array[array.Length - 1] = furstNum;
            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
