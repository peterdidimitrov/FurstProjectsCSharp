namespace _03.WordSynonyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            var words = new Dictionary<string, List<string>>();

            for (int i = 0; i < numOfLines; i++)
            {
                string word = Console.ReadLine();
                string synonum = Console.ReadLine();


                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                }
                words[word].Add(synonum);
            }
            foreach (var currWord in words)
            {
                Console.WriteLine($"{currWord.Key} - {string.Join(", ", currWord.Value)}");
            }
        }
    }
}