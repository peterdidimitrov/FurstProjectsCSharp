using System;

namespace _02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {

                string input = Console.ReadLine();
                string stringBeforeSpace = input.Substring(0, input.IndexOf(" "));
                string stringAfterSpace = input.Substring(input.IndexOf(" ") + 1);

                long numLeft = long.Parse(stringBeforeSpace);
                long numRight = long.Parse(stringAfterSpace);

                long sum = 0;

                if (numLeft >= numRight)
                {
                    numLeft = Math.Abs(numLeft);
                    while (numLeft != 0)
                    {
                        sum += numLeft % 10;
                        numLeft /= 10;
                    }
                }
                else if (numLeft <= numRight)
                {
                    numRight = Math.Abs(numRight);
                    while (numRight != 0)
                    {
                        sum += numRight % 10;
                        numRight /= 10;
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }
}
