namespace _05.MultiplyBigNumber
{
    using System;
    using System.Numerics;

    public class Program
    {
        static void Main(string[] args)
        {
            var veryBigNumber = BigInteger.Parse(Console.ReadLine());
            byte smallNumber = byte.Parse(Console.ReadLine());

            BigInteger product = veryBigNumber * smallNumber;

            Console.WriteLine(product);
        }
    }
}