using System.Numerics;

namespace SumOfIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            BigInteger sum = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                int num;
                try
                {
                    if (int.Parse(elements[i]) < int.MinValue || int.Parse(elements[i]) > int.MaxValue)
                    {
                        throw new OverflowException();
                    }
                    if (!int.TryParse(elements[i], out num))
                    {
                        throw new FormatException();
                    }
                    num = int.Parse(elements[i]);

                    sum += num;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is out of range!");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is in wrong format!");
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