using System;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int newHeadsets = 0;
            int newMousesets = 0;
            int newKeyboard = 0;
            int newDisplays = 0;


            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    newHeadsets++;
                }
                if (i % 3 == 0)
                {
                    newMousesets++;
                }
                if (i % 6 == 0)
                {
                    newKeyboard++;
                }
                if (i % 12 == 0)
                {
                    newDisplays++;
                }
            }
            
            double totalSum = (newHeadsets * headsetPrice) + (newMousesets * mousePrice) + (newKeyboard * keyboardPrice) + (newDisplays * displayPrice);

            Console.WriteLine($"Rage expenses: {totalSum:f2} lv.");
        }
    }
}
