using System;
using System.Linq;

namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int diff = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                string currentString = input;
                if (currentString[i] == '>')
                {
                    int strength = currentString[i + 1] - '0';
                    if (diff != 0)
                    {
                        strength += diff;
                        diff = 0;
                    }
                    if (strength > (input.Length - 1 - i))
                    {
                        strength = ((input.Length - 1 - i));
                    }
                    int counter = 0;

                    for (int j = 0; j < strength; j++)
                    {
                        counter++;

                        if (currentString[i + j + 1] == '>')
                        {
                            counter = j;
                            break;
                        }
                    }
                    diff = strength - counter;
                    currentString = input.Remove(i + 1, counter);
                }
                input = currentString;
            }
            Console.WriteLine(input);
        }
    }
}
