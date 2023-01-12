namespace _06.SongsQueue
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ");

            var songs = new Queue<string>(input);

            while (songs.Any())
            {
                string[] commArg = Console.ReadLine()
                    .Split();

                string currCommand = commArg[0];

                if (currCommand == "Play")
                {
                    songs.Dequeue();
                }
                else if (currCommand == "Add")
                {
                    string newSong = string.Join(" ", commArg.Skip(1));

                    if (!songs.Contains(newSong))
                    {
                        songs.Enqueue(newSong);
                    }
                    else
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                }
                else if (currCommand == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}