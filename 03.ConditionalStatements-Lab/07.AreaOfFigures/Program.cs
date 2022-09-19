using System;

namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;
            switch (figure)
            {
                case "square":
                    double side = double.Parse(Console.ReadLine());
                    area = side * side;

                    break;
                case "rectangle":
                    double sideA = double.Parse(Console.ReadLine());
                    double sideB = double.Parse(Console.ReadLine());
                    area = sideA * sideB;
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    area = Math.PI * Math.Pow(radius, 2);
                    break;
                case "triangle":
                    double basse = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    area = 0.5 * basse * height;
                    break;
            }
            Console.WriteLine("{0:F2}", area);
        }
    }
}