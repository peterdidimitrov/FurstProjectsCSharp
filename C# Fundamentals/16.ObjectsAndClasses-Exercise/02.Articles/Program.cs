using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string title = input[0];
            string content = input[1];
            string author = input[2];

            int n = int.Parse(Console.ReadLine());

            Article article = new Article(title, content, author);
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string comArg1 = command[0];
                string comArg2 = command[1];

                if (comArg1 == "Edit")
                {
                    article.Edit(article, comArg2);
                }
                else if (comArg1 == "ChangeAuthor")
                {
                    article.ChangeAuthor(article, comArg2);
                }
                else if (comArg1 == "Rename")
                {
                    article.Rename(article, comArg2);
                }
            }
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
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

        public void Edit(Article article, string comArg2)
        {
            article.Content = comArg2;
        }
        public void ChangeAuthor(Article article, string comArg2)
        {
            article.Author = comArg2;
        }
        public void Rename(Article article, string comArg2)
        {
            article.Title = comArg2;
        }
        public void PrintTheArticle(Article article, string input)
        {

        }
    }
}
