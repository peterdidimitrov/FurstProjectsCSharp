using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUniKaraoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = new Dictionary<string, List<string>>();
            string[] participants = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string[] availableSongs = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string commands;

            while ((commands = Console.ReadLine()) != "dawn")
            {
                string[] commArg = commands
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string name = commArg[0];
                string song = commArg[1];
                string award = commArg[2];

                if (participants.Contains(name) && availableSongs.Contains(song))
                {
                    if (!names.ContainsKey(name))
                    {
                        names.Add(name, new List<string>());
                        names[name].Add(award);
                    }
                    else
                    {
                        if (!names[name].Contains(award))
                        {
                            names[name].Add(award);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            foreach (var name in names.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                string participant = name.Key;
                int awardCount = name.Value.Count;
                List<string> awards = name.Value;


                Console.WriteLine($"{participant}: {awardCount} awards");
                foreach (var award in awards.OrderBy(y => y))
                {
                    Console.WriteLine($"--{award}");
                }
            }
            if (names.Count == 0)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
