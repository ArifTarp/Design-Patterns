using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book{Isbn = "12345", Title = "BOOK TITLE",Author = "BOOK AUTHOR"};
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateMemento();

            book.Title = "new book title";
            book.Author = "new book author";
            book.Isbn = "54321";
            book.ShowBook();

            book.RestoreFromMemento(history.Memento);
            book.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;

        public string Title
        {
            get {return _title;}
            set
            {
                _title = value;
                SetLastEdited();
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();
            }
        }

        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0}, {1}, {2}, Edited : {3}",_isbn,_title,_author,_lastEdited);
        }

        public Memento CreateMemento()
        {
            return new Memento(_title,_author,_isbn,_lastEdited);
        }

        public void RestoreFromMemento(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string author, string isbn, DateTime lastEdited)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
