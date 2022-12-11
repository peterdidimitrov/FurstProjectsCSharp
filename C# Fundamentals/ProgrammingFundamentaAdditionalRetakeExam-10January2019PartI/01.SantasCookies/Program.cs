
namespace SantasCookies
{
    using System;


    public class Program
    {
        public static void Main(string[] args)
        {
            int batches = int.Parse(Console.ReadLine());

            int singleCookieGrams = 25;
            int cup = 140;
            int smallSpoon = 10;
            int bigSpoon = 20;
            int cookiesPerBox = 5;


            int totalBoxes = 0;

            for (int i = 0; i < batches; i++)
            {
                int totalCookies = 0;
                int flour = int.Parse(Console.ReadLine());
                int sugar = int.Parse(Console.ReadLine());
                int cocoa = int.Parse(Console.ReadLine());

                int flourCups = flour / cup;
                int sugarSpoons = sugar / bigSpoon;
                int cocoaSpoons = cocoa / smallSpoon;
                int total = Math.Min(flourCups, sugarSpoons);
                if (flourCups <= 0 || sugarSpoons <= 0 || cocoaSpoons <= 0)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                    continue;
                }
                else
                {
                    totalCookies = ((cup + smallSpoon + bigSpoon) * Math.Min(total, cocoaSpoons)) / singleCookieGrams;
                    int boxes = totalCookies / cookiesPerBox;
                    Console.WriteLine($"Boxes of cookies: {boxes}");
                    totalBoxes += boxes;
                }
            }
            Console.WriteLine($"Total boxes: {totalBoxes}");
        }
    }
}