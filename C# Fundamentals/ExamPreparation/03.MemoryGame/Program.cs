using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ")
                .ToList();
            
            int numOfMoves = 0;
            string command;
            
            while ((command = Console.ReadLine()) != "end")
            {
                numOfMoves++;

                int[] indexes = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int furstElem = indexes[0];
                int secondElem = indexes[1];

                if (furstElem == secondElem ||
                    furstElem < 0 || 
                    furstElem > elements.Count - 1 ||
                    secondElem < 0 ||
                    secondElem > elements.Count - 1)
                {
                    string insEl = "-" + numOfMoves + "a";
                    elements.Insert(elements.Count / 2, insEl);
                    elements.Insert(elements.Count / 2, insEl);
                }
            }
        }
    }
}
