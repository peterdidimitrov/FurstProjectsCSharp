using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _04.GrabAndGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integerArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int number = int.Parse(Console.ReadLine());
            
            int index = -1;
            
            for (int i = 0; i < integerArray.Length; i++)
            {
                if (integerArray[i] == number)
                {
                    index = i;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("No occurrences were found!");
            }
            else
            {
                if (index == 0)
                {
                    index = 1;
                }
                long sum = 0;
                for (int z = 0; z < index; z++)
                {
                    sum += integerArray[z];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
