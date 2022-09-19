using System;

namespace _09._Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());
            double persent = double.Parse(Console.ReadLine());

            double volume = (lenght * width * hight) / 1000;

            double litters = volume * (1 - persent / 100);



            Console.WriteLine(litters);
        }
    }
}
