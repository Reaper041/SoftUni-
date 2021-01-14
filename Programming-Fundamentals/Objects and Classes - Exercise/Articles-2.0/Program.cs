using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article article = new Article(title, content, author);

                articles.Add(article);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if(command == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
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
}