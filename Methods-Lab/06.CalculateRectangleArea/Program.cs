using System;

namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());
            double area = GetRectangleArea(width, hight);
            Console.WriteLine(area);
        }

        static double GetRectangleArea(double width, double hight)
        {
            return width * hight;
        }
    }
}