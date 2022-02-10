using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P05_Book_Library
{
    class Book
    {
        public string Title { get; set; }
        public string Autor { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
    
        public Book(string title, string autor, string publisher, DateTime releaseDate, string isbn, decimal price)
        {
            Title = title;
            Autor = autor;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            Isbn = isbn;
            Price = price;
        }
    }
    
    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    
        public Library(string name)
        {
            Name = name;
            Books = new List<Book>();
        }
    }

    class Book_Library
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Library library = new Library ("Saglasie");
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ');

                string title = input[0];
                string autor = input[1];
                string publisher = input[2];
                DateTime releaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string isbn = input[4];
                decimal price = decimal.Parse(input[5]);

                Book book = new Book(title, autor, publisher, releaseDate, isbn, price);

                library.Books.Add(book);
            }

            Dictionary<string, decimal> booksPrice = new Dictionary<string, decimal>();
            
            foreach (var item in library.Books)
            {
                if (!booksPrice.ContainsKey(item.Autor))
                {
                    booksPrice[item.Autor] = item.Price;
                }
                else
                {
                    booksPrice[item.Autor] += item.Price;
                }
            }

            foreach (var item in booksPrice.OrderByDescending(p=>p.Value).ThenBy(a=>a.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
        }
    }
}
