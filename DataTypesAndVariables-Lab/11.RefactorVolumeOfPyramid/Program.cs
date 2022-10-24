using System;

namespace _11.RefactorVolumeOfPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length, width, hight = 0;

            length = double.Parse(Console.ReadLine());
            width = double.Parse(Console.ReadLine());
            hight = double.Parse(Console.ReadLine());

            Console.Write("Length: ");
            Console.Write("Width: ");
            Console.Write("Height: ");

            double volume = (length * width * hight) / 3;

            Console.WriteLine($"Pyramid Volume: {volume:f2}");
        }
    }
}
