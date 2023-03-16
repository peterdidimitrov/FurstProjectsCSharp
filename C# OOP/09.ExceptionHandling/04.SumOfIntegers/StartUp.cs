using System.Numerics;

namespace SumOfIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(' '); // Don't use StringSplitOption.RemoveEmptyEntries. Judge didn't expect it.

            BigInteger sum = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                try
                {
                    if (int.Parse(elements[i]) < int.MinValue || int.Parse(elements[i]) > int.MaxValue)
                    {
                        throw new OverflowException();
                    }

                    int num = int.Parse(elements[i]);

                    sum += num;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{elements[i]}' processed - current sum: {sum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}