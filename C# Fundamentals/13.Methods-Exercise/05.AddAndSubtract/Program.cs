using System;

namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int furstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thurdNum = int.Parse(Console.ReadLine());

            int sum = SumTheFurstAndSecondNum(furstNum, secondNum);
            int substract = SubstractTheThurdNumFromSum(sum, thurdNum);
            Console.WriteLine(substract);
        }
        static int SumTheFurstAndSecondNum(int furstNum, int secondNum)
        {
            int sum = furstNum + secondNum;
            return sum;
        }

        static int SubstractTheThurdNumFromSum(int sum, int thurdNum)
        {
            int substract = sum - thurdNum;
            return substract;
        }
    }
}
