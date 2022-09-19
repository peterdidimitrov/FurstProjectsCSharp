using System;

namespace _02.MaidenParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double maidenPartyPrice = double.Parse(Console.ReadLine());
            int numLoveLetter = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int keys = int.Parse(Console.ReadLine());
            int pic = int.Parse(Console.ReadLine());
            int luckSup = int.Parse(Console.ReadLine());
          
            double allArtic = numLoveLetter + roses + keys + pic + luckSup;
            double totalLoveLetter = numLoveLetter * 0.60;
            double totalRoses = roses * 7.20;
            double totalPic = pic * 18.20;
            double totalKeys = keys * 3.60;
            double totalLuckSup = luckSup * 22;

            double sum = totalLoveLetter + totalRoses + totalPic + totalKeys + totalLuckSup;

            if (allArtic > 25)
            {
                sum = sum * 0.65;
            }

            double totalSum = sum * 0.90;


            double diff = Math.Abs(maidenPartyPrice - totalSum);

            if (totalSum >= maidenPartyPrice)
            {
                Console.WriteLine($"Yes! {diff:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {diff:F2} lv needed.");
            }
        }
    }
}
