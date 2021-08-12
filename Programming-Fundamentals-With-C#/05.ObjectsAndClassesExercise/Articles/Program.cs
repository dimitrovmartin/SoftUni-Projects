
using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] articleData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string title = articleData[0];
                string content = articleData[1];
                string author = articleData[2];

                Article article = new Article(title, content, author);

                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                articles = articles.OrderBy(a => a.Title).ToList();
            }
            else if (criteria == "content")
            {
                articles = articles.OrderBy(a => a.Content).ToList();
            }
            else
            {
                articles = articles.OrderBy(a => a.Author).ToList();
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
}
