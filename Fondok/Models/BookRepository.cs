using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Fondok.Context;

namespace Fondok.Models
{
    class BookRepository
    {
        //private BookContext db;
        DatabaseContext db = new DatabaseContext();
        public BookRepository(DatabaseContext _db)
        {
            db = _db;
            db.Books.Load();
        }

        public System.ComponentModel.BindingList<Book> GetAllBooks()
        {
            return db.Books.Local.ToBindingList();
        }

        public void AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public Book GetBook(int id)
        {
            return db.Books.Where(b => b.id.Equals(id)).First();
        }

        public void UpdateBook(int id, string name, string author, int pages, int count, int edition)
        {
            Book book = GetBook(id);
            book.name = name;
            book.author = author;
            book.pages = pages;
            book.count = count;
            book.edition = edition;
            db.SaveChanges();
        }
        public void UpdateBook(Book b)
        {
            UpdateBook(b.id, b.name, b.author, b.pages, b.count, b.edition);
        }
        public void DeleteBook(int id)
        {
            db.Books.Remove(GetBook(id));
            db.SaveChanges();
        }
    }
}
