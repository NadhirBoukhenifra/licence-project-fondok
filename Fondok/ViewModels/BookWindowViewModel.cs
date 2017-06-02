using Fondok.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fondok.Views;
using Fondok.Context;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using Fondok.Commands;

namespace Fondok.ViewModels
{
    class BookWindowViewModel : INotifyPropertyChanged
    {
        public BookWindowViewModel() : this(null) { }
        public BookWindowViewModel(Book book)
        {
            EditBook = book;
        }
        private Book _editBook;
        public Book EditBook
        {
            get
            {
                return _editBook;
            }
            set
            {
                _editBook = value;
                NotifyPropertyChanged("EditBook");
            }
        }
        public bool Run()
        {
            BookWindow bw = new BookWindow();
            bw.DataContext = this;
            if (bw.ShowDialog() == true)
            {
                return true;
            }
            return false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }





    class BookRepository
    {
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













    class LibraryViewModel : INotifyPropertyChanged
    {
        private BookRepository rep;
        private DatabaseContext db;
        private BindingList<Book> _books;
        public BindingList<Book> Books
        {
            get
            {
                return _books;
            }
            set
            {
                _books = value;
                NotifyPropertyChanged("Books");
            }
        }
        private Book _selectedBook;
        public Book SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
                NotifyPropertyChanged("SelectedBook");
            }
        }
        public LibraryViewModel()
        {
            db = new DatabaseContext();
            rep = new BookRepository(db);
            Books = rep.GetAllBooks();
            deleteCommand = new DelegateCommand(DeleteBook);
            updateCommand = new DelegateCommand(UpdateBook);
            createCommand = new DelegateCommand(CreateBook);
        }
        public bool IsSelected()
        {
            return SelectedBook != null;
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        public void DeleteBook()
        {
            if (!IsSelected())
            {
                return;
            }
            rep.DeleteBook(SelectedBook.id);
        }
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        public void UpdateBook()
        {
            if (!IsSelected())
            {
                return;
            }
            BookWindowViewModel bwvm = new BookWindowViewModel(SelectedBook);
            if (bwvm.Run())
            {
                rep.UpdateBook(SelectedBook);
            }
        }
        private DelegateCommand createCommand;
        public ICommand CreateCommand
        {
            get
            {
                return createCommand;
            }
        }
        public void CreateBook()
        {
            Book bk = new Book();
            BookWindowViewModel bwvm = new BookWindowViewModel(bk);
            if (bwvm.Run() && bk.edition > 0 && bk.count > 0 && bk.pages > 0)
            {
                rep.AddBook(bk);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}