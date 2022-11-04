using System;

namespace _03.Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numRows = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            
            for (int i = 0; i < numRows; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    p1++;
                }
                else if (num >= 200 && num < 400)
                {
                    p2++;
                }
                else if (num >= 400 && num < 600)
                {
                    p3++;
                }
                else if (num >= 600 && num < 800)
                {
                    p4++;
                }
                else if (num >= 800)
                {
                    p5++;
                }
            }
            double persentP1 = p1 / numRows * 100;
            double persentP2 = p2 / numRows * 100;
            double persentP3 = p3 / numRows * 100;
            double persentP4 = p4 / numRows * 100;
            double persentP5 = p5 / numRows * 100;
            Console.WriteLine($"{persentP1:f2}%");
            Console.WriteLine($"{persentP2:f2}%");
            Console.WriteLine($"{persentP3:f2}%");
            Console.WriteLine($"{persentP4:f2}%");
            Console.WriteLine($"{persentP5:f2}%");
        }
    }
}
