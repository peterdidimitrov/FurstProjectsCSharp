using System;
using System.Linq;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            for (int currentNum = 1; currentNum <= number; currentNum++)
            {
                if (currentNum >= 1 && currentNum <= 16)
                {
                    continue;
                }

                if (IsNumDevisible(currentNum) && IsHoldOneOddDigit(currentNum))
                {
                    Console.WriteLine(currentNum);
                    continue;
                }
            }
        }
        static bool IsNumDevisible(int currentNum)
        {
            bool isNumDevisible = false;
            double sum = 0;

            while (currentNum != 0)
            {
                sum += currentNum % 10;
                currentNum = currentNum / 10;
            }
            if (sum % 8 == 0)
            {
                isNumDevisible = true;
            }
            return isNumDevisible;

        }
        static bool IsHoldOneOddDigit(int currentNum)
        {
            bool isHoldOneOddDigit = false;
            while (currentNum != 0)
            {
                int currentDigit = currentNum % 10;
                currentNum = currentNum / 10;
                if (currentDigit % 2 == 1)
                {
                    isHoldOneOddDigit = true;
                    break;
                }
            }
            return isHoldOneOddDigit;
        }
    }
}
