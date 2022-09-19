using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double prcesorPrice = double.Parse(Console.ReadLine());
            double videoCartPrice = double.Parse(Console.ReadLine());
            double ramPrice = double.Parse(Console.ReadLine());
            int ramNum = int.Parse(Console.ReadLine());
            double persent = double.Parse(Console.ReadLine());


            double totalProcesor = (prcesorPrice * 1.57) - ((prcesorPrice * 1.57) * persent);
            double totalVideo = (videoCartPrice * 1.57) - ((videoCartPrice * 1.57) * persent);
            double totalRam = (ramPrice * 1.57) * ramNum;
            double totalAfterDiscont = totalProcesor + totalVideo + totalRam;


            Console.WriteLine($"Money needed - {totalAfterDiscont:F2} leva.");
        }
    }
}
