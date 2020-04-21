using System;
using System.Collections.Generic;

namespace ControlPaper1.Task2
{
    public class Book
    {
        private String title;
        private String author;
        private int year;

        public Book(string title, string author, int year)
        {
            this.title = title ?? throw new ArgumentNullException(nameof(title));
            this.author = author ?? throw new ArgumentNullException(nameof(author));
            this.year = year;
        }

        public override string ToString()
        {
            return String.Format("Book: {0}, {1}, {2}", title, author, year.ToString());
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        public int Year
        {
            get => year;
            set => year = value;
        }

        protected bool Equals(Book other)
        {
            return title == other.title && author == other.author && year == other.year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(title, author, year);
        }

        public static bool operator ==(Book left, Book right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Book left, Book right)
        {
            return !Equals(left, right);
        }
    }
    
    public static class Task2
    {
        public static void Run()
        {
            Console.WriteLine("--- TASK 1 ---");
            Book[] books = new Book[5]
            {
                new Book("Book 1", "Author 1", 2001), 
                new Book("Book 2", "Author 2", 2002), 
                new Book("Book 3", "Author 3", 2003), 
                new Book("Book 4", "Author 4", 2004), 
                new Book("Book 5", "Author 5", 2005), 
            };
            
            Console.Write("Enter title: ");
            String title = Console.ReadLine();
            Console.Write("Enter author: ");
            String author = Console.ReadLine();
            Console.Write("Enter year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Book newBook = new Book(title, author, year);

            foreach (var book in books)
            {
                if (book == newBook)
                {
                    Console.WriteLine("Book is found");
                    break;
                }
            }
            
            Console.Write("Find books after year (enter year): ");
            int afterYear = Convert.ToInt32(Console.ReadLine());
            
            List<Book> filtredBooks = new List<Book>();
            foreach (var book in books)
            {
                if (book.Year > afterYear)
                {
                    filtredBooks.Add(book);
                }
            }

            if (filtredBooks.Count > 0)
            {
                foreach (var book in filtredBooks)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books found");
            }
            Console.WriteLine("=== END TASK 2 ===");
        }
    }
}