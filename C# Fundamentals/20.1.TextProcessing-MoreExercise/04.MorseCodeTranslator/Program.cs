using System;
using System.Collections.Generic;
using System.Text;

namespace _04.MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            List<string> mesage = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                StringBuilder word = new StringBuilder();
                
                string[] letters = input[i].Split();
                
                for (int j = 0; j < letters.Length; j++)
                {
                    string currSymbol = letters[j];
                    if (currSymbol == ".-")
                    {
                        word.Append("A");
                    }
                    else if (currSymbol == "-...")
                    {
                        word.Append("B");
                    }
                    else if (currSymbol == "-.-.")
                    {
                        word.Append("C");
                    }
                    else if (currSymbol == "-..")
                    {
                        word.Append("D");
                    }
                    else if (currSymbol == ".")
                    {
                        word.Append("E");
                    }
                    else if (currSymbol == "..-.")
                    {
                        word.Append("F");
                    }
                    else if (currSymbol == "--.")
                    {
                        word.Append("G");
                    }
                    else if (currSymbol == "....")
                    {
                        word.Append("H");
                    }
                    else if (currSymbol == "..")
                    {
                        word.Append("I");
                    }
                    else if (currSymbol == ".---")
                    {
                        word.Append("J");
                    }
                    else if (currSymbol == "-.-")
                    {
                        word.Append("K");
                    }
                    else if (currSymbol == ".-..")
                    {
                        word.Append("L");
                    }
                    else if (currSymbol == "--")
                    {
                        word.Append("M");
                    }
                    else if (currSymbol == "-.")
                    {
                        word.Append("N");
                    }
                    else if (currSymbol == "---")
                    {
                        word.Append("O");
                    }
                    else if (currSymbol == ".--.")
                    {
                        word.Append("P");
                    }
                    else if (currSymbol == "--.-")
                    {
                        word.Append("Q");
                    }
                    else if (currSymbol == ".-.")
                    {
                        word.Append("R");
                    }
                    else if (currSymbol == "...")
                    {
                        word.Append("S");
                    }
                    else if (currSymbol == "-")
                    {
                        word.Append("T");
                    }
                    else if (currSymbol == "..-")
                    {
                        word.Append("U");
                    }
                    else if (currSymbol == "...-")
                    {
                        word.Append("V");
                    }
                    else if (currSymbol == ".--")
                    {
                        word.Append("W");
                    }
                    else if (currSymbol == "-..-")
                    {
                        word.Append("X");
                    }
                    else if (currSymbol == "-.--")
                    {
                        word.Append("Y");
                    }
                    else if (currSymbol == "--..")
                    {
                        word.Append("Z");
                    }
                }
                mesage.Add(word.ToString());
            }

            Console.WriteLine(string.Join(" ", mesage));
        }
    }
}
