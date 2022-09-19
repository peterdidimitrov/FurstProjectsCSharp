using System;

namespace _10.InvalidNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isNumFalid = (number >= 100 && number <= 200) || number == 0;

            if (!isNumFalid)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}