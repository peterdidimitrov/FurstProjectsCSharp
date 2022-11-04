using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                if (input.Count == 3)
                {
                    string title = input[0];
                    string content = input[1];
                    string author = input[2];

                    Article article = new Article(title, content, author);

                    Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");

                }
            }
        }
    }
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
