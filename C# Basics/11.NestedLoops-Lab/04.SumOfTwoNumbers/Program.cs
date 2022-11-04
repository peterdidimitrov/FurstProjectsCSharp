using System;

namespace _04.SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int combinationNum = 0;
            for (int i = firstNum; i <= secondNum; i++)
            {
                
                for (int j = firstNum; j <= secondNum; j++)
                {
                    combinationNum++;
                    if (i + j == magicNum)
                    {
                        
                        Console.WriteLine($"Combination N:{combinationNum} ({i} + {j} = {magicNum})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{combinationNum} combinations - neither equals {magicNum}");
        }
    }
}
