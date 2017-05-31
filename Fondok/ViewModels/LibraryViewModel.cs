using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fondok.Models;
using System.ComponentModel;
using System.Windows.Input;
using Fondok.Commands;

namespace Fondok.ViewModels
{
    class LibraryViewModel : INotifyPropertyChanged
    {
        private BookRepository rep;
        private BookContext db;
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
            db = new BookContext();
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
            get { return deleteCommand; }
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
            get { return updateCommand; }
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
            get { return createCommand; }
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
