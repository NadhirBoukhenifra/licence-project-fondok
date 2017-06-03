
using Fondok.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fondok.Views;
using Fondok.Views.Windows;
using Fondok.Context;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using Fondok.Commands;
using System.Windows;

namespace Fondok.ViewModels
{
    class InvoiceViewModel : INotifyPropertyChanged
    {

        public InvoiceViewModel() : this(null) { }
        public InvoiceViewModel(Invoice Invoice)
        {
            EditInvoice = Invoice;
        }
        private Invoice _editInvoice;
        public Invoice EditInvoice
        {
            get
            {
                return _editInvoice;
            }
            set
            {
                _editInvoice = value;
                NotifyPropertyChanged("EditInvoice");
            }
        }
        public bool Run()
        {
            InvoiceWindow sw = new InvoiceWindow();
            sw.DataContext = this;
            if (sw.ShowDialog() == true)
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





    class InvoiceRepository
    {

        DatabaseContext db = new DatabaseContext();
        public InvoiceRepository(DatabaseContext _db)
        {
            db = _db;
            db.Invoices.Load();
        }
        public System.ComponentModel.BindingList<Invoice> GetAllInvoices()
        {
            return db.Invoices.Local.ToBindingList();
        }
        public void AddInvoice(Invoice Invoice)
        {
            db.Invoices.Add(Invoice);
            db.SaveChanges();
        }
        public Invoice GetInvoice(int id)
        {
            return db.Invoices.Where(b => b.InvoiceID.Equals(id)).First();
        }
        public void UpdateInvoice(int InvoiceID, string InvoiceDateTime, string InvoiceNumber)
        {
            Invoice Invoice = GetInvoice(InvoiceID);
            Invoice.InvoiceDateTime = InvoiceDateTime;
            Invoice.InvoiceNumber = InvoiceNumber;

            db.SaveChanges();
        }
        public void UpdateInvoice(Invoice b)
        {
            UpdateInvoice(b.InvoiceID, b.InvoiceDateTime, b.InvoiceNumber);
        }
        public void DeleteInvoice(int id)
        {
            db.Invoices.Remove(GetInvoice(id));
            db.SaveChanges();
        }
    }













    class InvoiceLibraryViewModel : INotifyPropertyChanged
    {
        private InvoiceRepository rep;
        private DatabaseContext db;
        private BindingList<Invoice> _Invoices;
        public BindingList<Invoice> Invoices
        {
            get
            {
                return _Invoices;
            }
            set
            {
                _Invoices = value;
                NotifyPropertyChanged("Invoices");
            }
        }
        private Invoice _selectedInvoice;
        public Invoice SelectedInvoice
        {
            get
            {
                return _selectedInvoice;
            }
            set
            {
                _selectedInvoice = value;
                NotifyPropertyChanged("SelectedInvoice");
            }
        }
        public InvoiceLibraryViewModel()
        {
            db = new DatabaseContext();
            rep = new InvoiceRepository(db);
            Invoices = rep.GetAllInvoices();
            deleteCommand = new DelegateCommand(DeleteInvoice);
            updateCommand = new DelegateCommand(UpdateInvoice);
            createCommand = new DelegateCommand(CreateInvoice);
        }
        public bool IsSelected()
        {
            return SelectedInvoice != null;
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        public void DeleteInvoice()
        {
            if (!IsSelected())
            {
                return;
            }
            rep.DeleteInvoice(SelectedInvoice.InvoiceID);
        }
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        public void UpdateInvoice()
        {
            if (!IsSelected())
            {
                return;
            }
            InvoiceViewModel bwvm = new InvoiceViewModel(SelectedInvoice);
            if (bwvm.Run())
            {
                rep.UpdateInvoice(SelectedInvoice);
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
        public void CreateInvoice()
        {
            Invoice bk = new Invoice();
            InvoiceViewModel bwvm = new InvoiceViewModel(bk);
            if (bwvm.Run()/* && bk.Duration > 0 && bk.Price > 0*/)
            {
                rep.AddInvoice(bk);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}