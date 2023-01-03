using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pieces = new Dictionary<string, List<string>>();
            int numberOfPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] piecesArg = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string pieceName = piecesArg[0];
                string composer = piecesArg[1];
                string key = piecesArg[2];

                pieces.Add(pieceName, new List<string>());
                pieces[pieceName].Add(composer);
                pieces[pieceName].Add(key);
            }
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commArg = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];
                string currPiece = commArg[1];

                if (currCommand == "Add")
                {
                    string currComposer = commArg[2];
                    string currKey = commArg[3];
                    if (!pieces.ContainsKey(currPiece))
                    {
                        pieces.Add(currPiece, new List<string>());
                        pieces[currPiece].Add(currComposer);
                        pieces[currPiece].Add(currKey);
                        Console.WriteLine($"{currPiece} by {currComposer} in {currKey} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{currPiece} is already in the collection!");
                    }
                }
                else if (currCommand == "Remove")
                {
                    if (!pieces.ContainsKey(currPiece))
                    {
                        Console.WriteLine($"Invalid operation! {currPiece} does not exist in the collection.");
                    }
                    else
                    {
                        pieces.Remove(currPiece);
                        Console.WriteLine($"Successfully removed {currPiece}!");
                    }
                }
                else if (currCommand == "ChangeKey")
                {
                    string newKey = commArg[2];
                    if (!pieces.ContainsKey(currPiece))
                    {
                        Console.WriteLine($"Invalid operation! {currPiece} does not exist in the collection.");
                    }
                    else
                    {
                        pieces[currPiece].RemoveAt(1);
                        pieces[currPiece].Add(newKey);
                        Console.WriteLine($"Changed the key of {currPiece} to {newKey}!");
                    }
                }
            }
            foreach (var item in pieces)
            {
                string piece = item.Key;
                string composer = item.Value[0];
                string key = item.Value[1];


                Console.WriteLine($"{piece} -> Composer: {composer}, Key: {key}");
            }
        }
    }
}
